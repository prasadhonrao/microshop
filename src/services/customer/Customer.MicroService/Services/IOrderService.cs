using Customer.MicroService.Models;

namespace Customer.MicroService.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderReadModel>> GetOrders(int customerId);
    Task PublishOrder(OrderPublishModel order);
}
