using System.Collections.Generic;
using Order.MicroService.Entities;

namespace Order.MicroService.Repositories;

public interface IOrderRepository
{
    // Order specific functionality
    IEnumerable<OrderEntity> GetAllOrders();
    OrderEntity GetOrderByID(int orderID);
    OrderEntity DeleteOrderById(int orderID);
    void AddOrder(OrderEntity newOrder);
    void UpdateOrder(int orderID, OrderEntity updatedOrder);
    bool SaveChanges();
}