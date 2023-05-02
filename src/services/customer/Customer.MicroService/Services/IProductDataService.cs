using Customer.MicroService.Models;

namespace Customer.MicroService.Services;

public interface IProductDataService {
    Task<IEnumerable<ProductReadModel>> GetProducts();
}