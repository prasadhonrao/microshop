using Customer.MicroService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer.MicroService.Data;

public class CustomerContext : DbContext
{
    public CustomerContext(DbContextOptions<CustomerContext> opt) : base(opt)
    {
    }

    public DbSet<CustomerEntity> Customers { get; set; } = null!;
    public DbSet<OrderEntity> Orders { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerEntity>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });


        modelBuilder.Entity<CustomerEntity>().HasData(
            new CustomerEntity(1, "John", "Doe"),
            new CustomerEntity(2, "Jane", "Smith"),
            new CustomerEntity(3, "Michael", "Johnson"),
            new CustomerEntity(4, "Emily", "Brown"),
            new CustomerEntity(5, "Daniel", "Miller"),
            new CustomerEntity(6, "Olivia", "Davis"),
            new CustomerEntity(7, "William", "Garcia"),
            new CustomerEntity(8, "Sophia", "Martinez"),
            new CustomerEntity(9, "Matthew", "Anderson"),
            new CustomerEntity(10, "Isabella", "Thomas")
        );

        modelBuilder.Entity<OrderEntity>().HasData(
            new OrderEntity(1, 1, new DateTime(2020, 1, 1), 100.00m),
            new OrderEntity(2, 1, new DateTime(2020, 2, 1), 200.00m),
            new OrderEntity(3, 2, new DateTime(2020, 3, 1), 300.00m),
            new OrderEntity(4, 2, new DateTime(2020, 4, 1), 400.00m),
            new OrderEntity(5, 3, new DateTime(2020, 5, 1), 500.00m),
            new OrderEntity(6, 3, new DateTime(2020, 6, 1), 600.00m),
            new OrderEntity(7, 4, new DateTime(2022, 7, 1), 700.00m),
            new OrderEntity(8, 5, new DateTime(2022, 8, 1), 800.00m),
            new OrderEntity(9, 5, new DateTime(2022, 9, 1), 900.00m),
            new OrderEntity(10, 9, new DateTime(2022, 12, 21), 1000.00m)
        );

        base.OnModelCreating(modelBuilder);
    }
}