using AutoMapper;
using Order.API.Entities;
using Order.API.Repositories;
using Order.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace Order.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;

    public OrderController(IOrderRepository repository, IMapper mapper )
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<OrderReadModel>> Get() 
    {
        Console.WriteLine("Getting all orders data...");
        var orders = _repository.GetAll();
        return Ok(_mapper.Map<IEnumerable<OrderReadModel>>(orders));
    }

    [HttpGet("{id}", Name = "GetById")]
    public ActionResult<OrderReadModel> GetById(int id)
    {
        Console.WriteLine("Getting single order data with id: " + id);
        var orders = _repository.GetById(id);

        if (orders != null)
            return Ok(_mapper.Map<OrderReadModel>(orders));
            
        return NotFound("Order not found");
    }

    [HttpPost]
    public ActionResult<OrderReadModel> Create(OrderCreateModel model) 
    {
        Console.WriteLine("Creating new order ", model);

        var order = _mapper.Map<OrderEntity>(model);

        _repository.Add(order);
        _repository.SaveChanges();

        var addedOrder = _mapper.Map<OrderReadModel>(order);
        return CreatedAtRoute(nameof(GetById), new { Id = addedOrder.OrderID }, addedOrder);
    }
}