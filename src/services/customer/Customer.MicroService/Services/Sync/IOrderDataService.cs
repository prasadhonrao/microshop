namespace Customer.MicroService.Services.Sync;

public interface IOrderDataService {
    Task<string?> GetOrders();
}