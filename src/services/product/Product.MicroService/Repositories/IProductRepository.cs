using System.Collections.Generic;
using Product.MicroService.Entities;

namespace Product.MicroService.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<ProductEntity>> GetAllProducts();
    Task<ProductEntity> GetProductById(int id);
    void AddProduct(ProductEntity newProduct);
    Task<ProductEntity> UpdateProduct(int id, ProductEntity updatedProduct);
    void DeleteProduct(int id);

    // This method is required by EF Core
    // bool SaveChanges();

}