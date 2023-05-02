using Product.MicroService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Product.MicroService.Data;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> opt) : base(opt)
    {
    }

    public DbSet<ProductEntity> Products { get; set; }
}