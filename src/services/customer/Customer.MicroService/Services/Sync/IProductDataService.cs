using Customer.MicroService.Models;

namespace Customer.MicroService.Services.Sync;

public interface IProductDataService {
    Task<IEnumerable<ProductReadModel>?> GetProducts();
}