namespace Customer.MicroService.Services;

public interface IOrderDataService {
    Task<string> GetOrders();
}