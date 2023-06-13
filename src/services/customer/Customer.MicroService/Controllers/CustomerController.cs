using AutoMapper;
using Customer.MicroService.Entities;
using Customer.MicroService.Models;
using Customer.MicroService.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Customer.MicroService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService customerService;
    private readonly IMapper mapper;
    private readonly ILogger<CustomerController> logger;

    public CustomerController(
        ICustomerService customerService,
        IMapper mapper,
        ILogger<CustomerController> logger)
    {
        this.customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet(Name = "GetAllCustomers")]
    [ProducesResponseType(typeof(IEnumerable<CustomerReadModel>), 200)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetAllCustomers()
    {
        try
        {
            logger.LogInformation("Getting all customers");
            var customers = await customerService.GetAllAsync();
            return Ok(mapper.Map<IEnumerable<CustomerReadModel>>(customers));
        }
        catch (InvalidOperationException ex)
        {
            logger.LogError(ex, $"Invalid operation exception occurred while getting all customer information");
            return StatusCode(500, "An error occurred while retrieving customer information. Please try again later.");
        }
    }

    [HttpGet("{id}", Name = "GetCustomerById")]
    [ProducesResponseType(typeof(CustomerReadModel), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetCustomerById([FromRoute] int id)
    {
        try
        {
            ValidateId(id);

            logger.LogInformation($"Getting single customer data with id: {id}");
            var customer = await customerService.GetAsync(id);

            if (customer == null)
            {
                logger.LogInformation($"No customer found with id: {id}");
                return NotFound($"No customer found with id: {id}");
            }

            return Ok(mapper.Map<CustomerReadModel>(customer));
        }
        catch (ArgumentException ex)
        {
            logger.LogError(ex, $"Invalid customer id: {id}");
            return BadRequest($"Invalid customer id: {id}");
        }
        catch (Exception ex)
        {
            logger.LogCritical(ex, $"Exception occurred while retrieving customer with id: {id}");
            return StatusCode(500, $"An error occurred while handling your request for customer with id: {id}");
        }
    }

    // TODO: Split this method into two parts - order summary and order details
    [HttpGet("{id}/orders", Name = "GetCustomerOrders")]
    [ProducesResponseType(typeof(IEnumerable<OrderReadModel>), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetCustomerOrders([FromRoute] int id)
    {
        try
        {
            ValidateId(id);

            logger.LogInformation($"Checking if customer with id: {id} exists in the database");

            bool customerExists = await customerService.CustomerExistsAsync(id);

            if (!customerExists)
            {
                logger.LogInformation($"No customer found with id: {id}");
                return NotFound($"No customer found with id: {id}");
            }

            logger.LogInformation($"Getting all orders for customer id: {id} ");
            var orders = await customerService.GetOrders(id);
            return Ok(orders);
        }
        catch (ArgumentException ex)
        {
            logger.LogError(ex, $"Invalid customer id: {id}");
            return BadRequest($"Invalid customer id: {id}");
        }
        catch (Exception ex)
        {
            logger.LogCritical(ex, $"Exception occurred while retrieving customer with id: {id}");
            return StatusCode(500, $"An error occurred while handling your request for customer with id: {id}");
        }
    }

    [HttpPost(Name = "CreateCustomer")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateModel model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                logger.LogInformation("Customer object sent from client is null");
                return BadRequest("Customer object is null");
            }

            logger.LogInformation("Creating a new customer ", model);
            var customer = mapper.Map<CustomerEntity>(model);
            customerService.Add(customer);
            await customerService.SaveChangesAsync();

            var addedCustomer = mapper.Map<CustomerReadModel>(customer);
            return CreatedAtRoute(nameof(GetCustomerById),
                new { id = addedCustomer.Id }, addedCustomer);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while creating a new customer");
            return StatusCode(500, "An error occurred while creating a new customer. Please try again later.");
        }
    }

    [HttpPut("{id}", Name = "UpdateCustomer")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> UpdateCustomer([FromRoute] int id, [FromBody] CustomerCreateModel model)
    {
        try
        {
            ValidateId(id);

            bool customerExists = await customerService.CustomerExistsAsync(id);

            if (!customerExists)
            {
                logger.LogInformation($"No customer found with id: {id}");
                return NotFound($"No customer found with id: {id}");
            }

            if (!ModelState.IsValid)
            {
                logger.LogInformation("Customer object sent from client is invalid");
                return BadRequest("Customer object is invalid");
            }

            logger.LogInformation($"Updating single customer with id: {id}");

            var customer = mapper.Map<CustomerEntity>(model);
            customerService.Update(id, customer);
            await customerService.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"An error occurred while updating customer with ID: {id}");
            return StatusCode(500, "An error occurred while updating the customer. Please try again later.");
        }
    }

    [HttpPatch("{id}", Name = "PatchCustomer")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PatchCustomer([FromRoute] int id,
     JsonPatchDocument<CustomerUpdateModel> patchDocument)
    {
        try
        {
            ValidateId(id);

            var existingCustomer = await customerService.GetAsync(id);
            if (existingCustomer == null)
            {
                logger.LogInformation($"No customer found with id: {id}");
                return NotFound($"No customer found with id: {id}");
            }

            if (!ModelState.IsValid)
            {
                logger.LogInformation("Customer object sent from client is invalid");
                return BadRequest("Customer object is invalid");
            }

            var patchModel = new CustomerUpdateModel(existingCustomer.FirstName,
                                existingCustomer.LastName);

            patchDocument.ApplyTo(patchModel, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // This is required to ensure that the model validation is done on the patched model
            if (!TryValidateModel(patchModel))
            {
                return BadRequest(ModelState);
            }

            logger.LogInformation($"Patching single customer with id: {id}");

            existingCustomer.FirstName = patchModel.FirstName;
            existingCustomer.LastName = patchModel.LastName;

            var customer = mapper.Map<CustomerEntity>(existingCustomer);
            customerService.Patch(id, customer);
            await customerService.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"An error occurred while patching customer with ID: {id}");
            return StatusCode(500, "An error occurred while patching the customer. Please try again later.");
        }
    }

    [HttpDelete("{id}", Name = "DeleteCustomerById")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> DeleteCustomerById([FromRoute] int id)
    {
        try
        {
            ValidateId(id);

            logger.LogInformation($"Deleting single customer with id: {id}");
            customerService.Delete(id);
            await customerService.SaveChangesAsync();
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            logger.LogError(ex, $"Invalid customer id: {id}");
            return BadRequest($"Invalid customer id: {id}");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"An error occurred while deleting customer with ID: {id}");
            return StatusCode(500, "An error occurred while deleting the customer. Please try again later.");
        }
    }

    //GET /api/customers/search? FirstName = John & LastName = Doe

    [HttpGet("search")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> SearchCustomers([FromQuery] CustomerSearchParametersModel searchParameters)
    {
        try
        {
            Expression<Func<CustomerEntity, bool>> predicate = GenerateSearchPredicate(searchParameters);

            var customers = await customerService.FindAsync(predicate);

            return Ok(customers);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while searching customers.");
            return StatusCode(500, "An error occurred while searching customers. Please try again later.");
        }
    }

    private Expression<Func<CustomerEntity, bool>> GenerateSearchPredicate(CustomerSearchParametersModel searchParameters)
    {
        Expression<Func<CustomerEntity, bool>> predicate = c =>
            (string.IsNullOrEmpty(searchParameters.FirstName) || c.FirstName == searchParameters.FirstName) &&
            (string.IsNullOrEmpty(searchParameters.LastName) || c.LastName == searchParameters.LastName);

        return predicate;
    }

    private void ValidateId(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException($"Invalid customer id: {id}");
        }
    }

}