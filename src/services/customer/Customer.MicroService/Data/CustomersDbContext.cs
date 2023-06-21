using Customer.MicroService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer.MicroService.Data;

public class CustomersDbContext : DbContext
{
    public CustomersDbContext(DbContextOptions<CustomersDbContext> opt) : base(opt)
    {
    }

    public DbSet<CustomerEntity> Customers { get; set; } = null!;
    public DbSet<OrderEntity> Orders { get; set; } = null!;
    
}