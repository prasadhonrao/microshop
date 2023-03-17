using System;
using System.Collections.Generic;
using System.Linq;
using Order.API.Data;
using Order.API.Entities;

namespace Order.API.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderContext _context;

    public OrderRepository(OrderContext context)
    {
        _context = context;
    }
    public void Add(OrderEntity newOrder)
    {
        if (newOrder == null) throw new ArgumentNullException(nameof(newOrder));
        _context.Orders.Add(newOrder);
    }

    public OrderEntity DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<OrderEntity> GetAll()
    {
        return (IEnumerable<OrderEntity>)_context.Orders.ToList();
    }

    public OrderEntity GetById(int id)
    {
        return _context.Orders.FirstOrDefault(c => c.OrderID == id);
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() >= 0;
    }

    public void Update(int id, OrderEntity updatedOrder)
    {
        throw new NotImplementedException();
    }
}