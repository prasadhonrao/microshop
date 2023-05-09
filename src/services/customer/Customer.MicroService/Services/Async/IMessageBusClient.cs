using Customer.MicroService.Models;

namespace Customer.MicroService.Services.Async;

public interface IMessageBusClient {
    void CreateNewOrder(OrderCreateModel order);
}