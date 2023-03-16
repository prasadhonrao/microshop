using AutoMapper;
using Customer.API.Entities;
using Customer.API.Repositories;
using Customer.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerRepository repository, IMapper mapper )
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CustomerReadModel>> Get() 
    {
        Console.WriteLine("Getting all customers data...");
        var customers = _repository.GetAll();
        return Ok(_mapper.Map<IEnumerable<CustomerReadModel>>(customers));
    }

    [HttpGet("{id}", Name = "GetById")]
    public ActionResult<CustomerReadModel> GetById(int id)
    {
        Console.WriteLine("Getting single customers data with id: " + id);
        var customer = _repository.GetById(id);

        if (customer != null)
            return Ok(_mapper.Map<CustomerReadModel>(customer));
            
        return NotFound("Customer not found");
    }

    [HttpPost]
    public ActionResult<CustomerReadModel> Create(CustomerCreateModel model) 
    {
        Console.WriteLine("Creating new customer ", model);

        var customer = _mapper.Map<CustomerEntity>(model);

        _repository.Add(customer);
        _repository.SaveChanges();

        var addedCustomer = _mapper.Map<CustomerReadModel>(customer);
        return CreatedAtRoute(nameof(GetById), new { Id = addedCustomer.CustomerID }, addedCustomer);
    }
}