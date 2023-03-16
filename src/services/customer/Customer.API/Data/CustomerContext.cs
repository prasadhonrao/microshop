using Customer.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer.API.Data;

public class CustomerContext : DbContext
{
    public CustomerContext(DbContextOptions<CustomerContext> opt) : base(opt)
    {
    }

    public DbSet<CustomerEntity> Customers { get; set; }
}