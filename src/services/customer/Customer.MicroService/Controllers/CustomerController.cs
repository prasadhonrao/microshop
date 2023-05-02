using AutoMapper;
using Customer.MicroService.Entities;
using Customer.MicroService.Repositories;
using Customer.MicroService.Models;
using Customer.MicroService.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customer.MicroService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _repository;
    private readonly IOrderDataService _orderDataService;

    private readonly IProductDataService _productDataService;
    private readonly IMapper _mapper;
    private readonly ILogger<CustomerController> _logger;


    public CustomerController(
        ICustomerRepository repository, 
        IOrderDataService orderDataService,
        IProductDataService productDataService,
        IMapper mapper,
        ILogger<CustomerController> logger
    ) 
    {
        _repository = repository;
        _orderDataService = orderDataService;
        _productDataService = productDataService;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerReadModel>>> Get() 
    {
        _logger.LogInformation("Getting all customers ...");
        var customers = _repository.GetAll();

        // TODO: This is for demo only. Get all orders synchronously
        var orders = await _orderDataService.GetOrders();
        Console.WriteLine(orders);

        var products = await _productDataService.GetProducts();
        System.Console.WriteLine("Products: " + products);
        foreach (var p in products)
        {
            _logger.LogInformation(p.ProductName);
        }

        return Ok(_mapper.Map<IEnumerable<CustomerReadModel>>(customers));
    }

    [HttpGet("{id}", Name = "GetById")]
    public ActionResult<CustomerReadModel> GetById(int id)
    {
        _logger.LogInformation("Getting single customer data with id: " + id);
        var customer = _repository.GetById(id);

        if (customer != null)
            return Ok(_mapper.Map<CustomerReadModel>(customer));
        else {    
            _logger.LogWarning($"No customer found with id: {id}");
            return NotFound("Customer not found");
        }
    }

    [HttpPost]
    public ActionResult<CustomerReadModel> Create(CustomerCreateModel model) 
    {
        _logger.LogInformation("Creating new customer ", model);

        var customer = _mapper.Map<CustomerEntity>(model);

        _repository.Add(customer);
        _repository.SaveChanges();

        var addedCustomer = _mapper.Map<CustomerReadModel>(customer);
        return CreatedAtRoute(nameof(GetById), new { Id = addedCustomer.CustomerID }, addedCustomer);
    }
}