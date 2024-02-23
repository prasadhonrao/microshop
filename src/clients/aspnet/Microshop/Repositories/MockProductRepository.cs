using Microshop.Models;

namespace Microshop.Repositories;

public class MockProductRepository : IProductRepository
{
    public Task<Product> CreateProductAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProductAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Product>? GetProductByIdAsync(int id)
    {
        var products = await GetProductsAsync();
        return products.FirstOrDefault(p => p.Id == id);
    }

    public Task<IEnumerable<Product>> GetProductsAsync()
    {
        // Mock data
        var products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Description = "A laptop",
                Price = 1000,
                CategoryId = 1
            },
            new Product
            {
                Id = 2,
                Name = "T-shirt",
                Description = "A t-shirt",
                Price = 20,
                CategoryId = 2
            },
            new Product
            {
                Id = 3,
                Name = "Book",
                Description = "A book",
                Price = 10,
                CategoryId = 3
            }
        };

        return Task.FromResult(products.AsEnumerable());
    }

    public Task<Product> UpdateProductAsync(Product product)
    {
        throw new NotImplementedException();
    }
}
