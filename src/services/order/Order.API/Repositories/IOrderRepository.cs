using System.Collections.Generic;
using Order.API.Entities;

namespace Order.API.Repositories;

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