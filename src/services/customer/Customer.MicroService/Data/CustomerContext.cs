using Customer.MicroService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer.MicroService.Data;

public class CustomerContext : DbContext
{
    public CustomerContext(DbContextOptions<CustomerContext> opt) : base(opt)
    {
    }

    public DbSet<CustomerEntity> Customers { get; set; }
}