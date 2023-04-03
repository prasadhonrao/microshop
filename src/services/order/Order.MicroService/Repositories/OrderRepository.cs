using System;
using System.Collections.Generic;
using System.Linq;
using Order.MicroService.Data;
using Order.MicroService.Entities;

namespace Order.MicroService.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderContext _context;

    public OrderRepository(OrderContext context)
    {
        _context = context;
    }
    public void AddOrder(OrderEntity newOrder)
    {
        if (newOrder == null) throw new ArgumentNullException(nameof(newOrder));
        _context.Orders.Add(newOrder);
    }

    public OrderEntity DeleteOrderById(int orderID)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<OrderEntity> GetAllOrders()
    {
        return (IEnumerable<OrderEntity>)_context.Orders.ToList();
    }

    public OrderEntity GetOrderByID(int orderID)
    {
        return _context.Orders.FirstOrDefault(c => c.OrderID == orderID);
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() >= 0;
    }

    public void UpdateOrder(int orderID, OrderEntity updatedOrder)
    {
        throw new NotImplementedException();
    }
}