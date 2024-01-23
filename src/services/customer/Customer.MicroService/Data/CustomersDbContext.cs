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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerEntity>().HasData(
                       new CustomerEntity
                       {
                           Id = 1,
                           CompanyName = "Dummy Company 1",
                           ContactName = "John Doe",
                           ContactTitle = "CEO",
                           Address = "123 Main St",
                           City = "New York",
                           Region = "NY",
                           PostalCode = "10001",
                           Country = "USA",
                           Phone = "123-456-7890",
                           Fax = "123-456-7891"
                       },
                        new CustomerEntity
                        {
                            Id = 2,
                            CompanyName = "Dummy Company 2",
                            ContactName = "Jane Doe",
                            ContactTitle = "CEO",
                            Address = "456 Main St",
                            City = "New York",
                            Region = "NY",
                            PostalCode = "10001",
                            Country = "USA",
                            Phone = "123-456-7890",
                            Fax = "123-456-7891"
                        },
                        new CustomerEntity
                        {
                            Id = 3,
                            CompanyName = "Dummy Company 3",
                            ContactName = "John Smith",
                            ContactTitle = "CEO",
                            Address = "789 Main St",
                            City = "New York",
                            Region = "NY",
                            PostalCode = "10001",
                            Country = "USA",
                            Phone = "123-456-7890",
                            Fax = "123-456-7891"
                        }
          );
    }

}