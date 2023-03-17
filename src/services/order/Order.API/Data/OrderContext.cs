using Order.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Order.API.Data;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> opt) : base(opt)
    {
    }

    public DbSet<OrderEntity> Orders { get; set; }
}