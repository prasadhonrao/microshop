using System;
using System.Collections.Generic;
using System.Linq;
using Product.MicroService.Data;
using Product.MicroService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Product.MicroService.Repositories;

#nullable disable
public class ProductRepository : IProductRepository
{
    private readonly ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        _context = context;
    }
    public async void AddProduct(ProductEntity newProduct)
    {
        if (newProduct == null) throw new ArgumentNullException(nameof(newProduct));
        await _context.Products.AddAsync(newProduct);
        await _context.SaveChangesAsync();
        // return result.Entity;
    }

    public async void DeleteProduct(int id)
    {
        var product = _context.Products.FirstOrDefault(c => c.ProductID == id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException(nameof(id));
        }
    }

    public async Task<IEnumerable<ProductEntity>> GetAllProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<ProductEntity> GetProductById(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(c => c.ProductID == id);
    }

    // public bool SaveChanges()
    // {
    //     return _context.SaveChanges() >= 0;
    // }

    public Task<ProductEntity> UpdateProduct(int id, ProductEntity updatedProduct)
    {
        throw new NotImplementedException();
    }
}