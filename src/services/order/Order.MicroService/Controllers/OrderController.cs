using AutoMapper;
using Order.MicroService.Entities;
using Order.MicroService.Repositories;
using Order.MicroService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace Order.MicroService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<OrderController> _logger;
    public OrderController(IOrderRepository repository, 
                            IMapper mapper, ILogger<OrderController> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<OrderReadModel>> Get() 
    {
        _logger.LogInformation("Getting all orders data...");
        var orders = _repository.GetAllOrders();
        return Ok(_mapper.Map<IEnumerable<OrderReadModel>>(orders));
    }

    [HttpGet("{id}", Name = "GetById")]
    public ActionResult<OrderReadModel> GetById(int id)
    {
        _logger.LogInformation("Getting single order data with id: " + id);
        var orders = _repository.GetOrderByID(id);

        if (orders != null)
            return Ok(_mapper.Map<OrderReadModel>(orders));
        else {
            _logger.LogWarning($"Order with {id} not found");
            return NotFound("Order not found");
        }    
    }

    [HttpPost]
    public ActionResult<OrderReadModel> Create(OrderCreateModel model) 
    {
        _logger.LogInformation("Creating new order ", model);

        var order = _mapper.Map<OrderEntity>(model);

        _repository.AddOrder(order);
        _repository.SaveChanges();

        var addedOrder = _mapper.Map<OrderReadModel>(order);
        return CreatedAtRoute(nameof(GetById), new { Id = addedOrder.OrderID }, addedOrder);
    }
}