using Customer.MicroService.Models;

namespace Customer.MicroService.Services.Sync;

public interface IOrderDataService {
    Task<IEnumerable<OrderReadModel>> GetOrders(int customerId);
}