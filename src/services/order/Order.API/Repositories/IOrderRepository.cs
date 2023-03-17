using System.Collections.Generic;
using Order.API.Entities;

namespace Order.API.Repositories;

public interface IOrderRepository
{
    IEnumerable<OrderEntity> GetAll();
    OrderEntity GetById(int id);
    OrderEntity DeleteById(int id);
    void Add(OrderEntity newOrder);
    void Update(int id, OrderEntity updatedOrder);

    bool SaveChanges();

}