using Order.MicroService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Order.MicroService.Data;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> opt) : base(opt)
    {
    }

    public DbSet<OrderEntity> Orders { get; set; }
}