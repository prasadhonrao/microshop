using AutoMapper;
using Customer.MicroService.Entities;
using Customer.MicroService.Models;
using Customer.MicroService.Services;
using Customer.MicroService.Services.Sync;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Customer.MicroService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService customerService;
    private readonly IOrderDataService orderDataService;
    private readonly IMapper mapper;
    private readonly ILogger<CustomerController> logger;

    public CustomerController(
        ICustomerService customerService,
        IOrderDataService orderDataService,
        IMapper mapper,
        ILogger<CustomerController> logger)
    {
        this.customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        this.orderDataService = orderDataService ?? throw new ArgumentNullException(nameof(orderDataService));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet(Name = "GetAllCustomers")]
    public async Task<IActionResult> GetAllCustomers()
    {
        try
        {
            logger.LogInformation("Getting all customers");
            var customers = await customerService.GetAllAsync();
            return Ok(mapper.Map<IEnumerable<CustomerReadModel>>(customers));
        }
        catch (Exception)
        {
            logger.LogCritical($"Exception while getting all customer information");
            throw;
        }
    }

    [HttpGet("{id}", Name = "GetCustomerById")]
    public async Task<IActionResult> GetCustomerById([FromRoute] int id)
    {
        try
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid customer id {id}");
            }

            logger.LogInformation($"Getting single customer data with id: {id}");
            var customer = await customerService.GetAsync(id);

            if (customer == null)
            {
                logger.LogInformation($"No customer found with id: {id}");
                return NotFound($"No customer found with id: {id}");
            }

            return Ok(mapper.Map<CustomerReadModel>(customer));
        }
        catch (Exception ex)
        {
            logger.LogCritical($"Exception while getting customer with id {id}", ex);
            return StatusCode(500, "A problem occurred while handling your request"); // Do not write stack tract as this informtion goes back to the consumer
        }
    }

    // TODO: Split this method into two parts - order summary and order details
    [HttpGet("{id}/orders", Name = "GetCustomerOrders")]
    public async Task<IActionResult> GetCustomerOrders([FromRoute] int id)
    {
        if (id <= 0)
        {
            return BadRequest($"Invalid customer id {id}");
        }

        logger.LogInformation($"Checking if customer with id: {id} exists in the database");
        var customer = await customerService.GetAsync(id);

        if (customer == null)
        {
            logger.LogInformation($"No customer found with id: {id}");
            return NotFound($"No customer found with id: {id}");
        }

        logger.LogInformation($"Getting all customer orders for customer id: {id} ");
        var orders = await orderDataService.GetOrders(id);
        return Ok(orders);
    }

    [HttpPost(Name = "CreateCustomer")]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateModel model)
    {
        // Validate the model
        if (!ModelState.IsValid)
        {
            logger.LogWarning("Customer object sent from client is null");
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

    [HttpPut("{id}", Name = "UpdateCustomer")]
    public async Task<IActionResult> UpdateCustomer([FromRoute] int id, [FromBody] CustomerCreateModel model)
    {
        if (id <= 0)
        {
            return BadRequest($"Invalid customer id {id}");
        }

        var existingCustomer = await customerService.GetAsync(id);
        if (existingCustomer == null)
        {
            logger.LogWarning($"No customer found with id: {id}");
            return NotFound($"No customer found with id: {id}");
        }

        // Validate the model
        if (!ModelState.IsValid)
        {
            logger.LogWarning("Customer object sent from client is invalid");
            return BadRequest("Customer object is invalid");
        }

        logger.LogInformation($"Updating single customer with id: {id}");
        
        var customer = mapper.Map<CustomerEntity>(model);
        customerService.Update(id, customer);
        await customerService.SaveChangesAsync();

        return CreatedAtRoute(nameof(GetCustomerById),
            new { id = existingCustomer.Id }, customer);
    }

    [HttpPatch("{id}", Name = "PatchCustomer")]
    public async Task<IActionResult> PatchCustomer([FromRoute] int id,
     JsonPatchDocument<CustomerUpdateModel> patchDocument)
    {
        if (id <= 0)
        {
            return BadRequest($"Invalid customer id {id}");
        }

        var existingCustomer = await customerService.GetAsync(id);
        if (existingCustomer == null)
        {
            logger.LogWarning($"No customer found with id: {id}");
            return NotFound($"No customer found with id: {id}");
        }

        // Validate the model
        if (!ModelState.IsValid)
        {
            logger.LogWarning("Customer object sent from client is invalid");
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

    [HttpDelete("{id}", Name = "DeleteCustomerById")]
    public async Task<IActionResult> DeleteCustomerById([FromRoute] int id)
    {
        if (id <= 0)
        {
            return BadRequest($"Invalid customer id {id}");
        }

        var customer = await customerService.GetAsync(id);
        if (customer == null)
        {
            logger.LogWarning($"No customer found with id: {id}");
            return NotFound($"No customer found with id: {id}");
        }

        logger.LogInformation($"Deleting single customer with id: {id}");
        customerService.Delete(customer);
        await customerService.SaveChangesAsync();
        return (Ok());

    }
}