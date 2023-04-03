using System.Collections.Generic;
using System.Linq;
using Order.MicroService.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Order.MicroService.Data;

public static class OrderContextInitializer 
{
    public static void PrepareData(IApplicationBuilder builder) 
    {
        using(var scope = builder.ApplicationServices.CreateScope()) 
        {
            SeedData(scope.ServiceProvider.GetService<OrderContext>());
        }
    }

    private static void SeedData(OrderContext context) 
    {
        // In memory data
        if (!context.Orders.Any())
        {
            System.Console.WriteLine("Populating in memory Order data");
            List<OrderEntity> Orders = new List<OrderEntity>();
            Orders.Add(new OrderEntity() { OrderID = 1, CustomerID = 1, OrderDate = DateTime.Now });
            Orders.Add(new OrderEntity() { OrderID = 3, CustomerID = 2, OrderDate = DateTime.Now });
            Orders.Add(new OrderEntity() { OrderID = 2, CustomerID = 2, OrderDate = DateTime.Now });
            Orders.Add(new OrderEntity() { OrderID = 4, CustomerID = 3, OrderDate = DateTime.Now });
            context.Orders.AddRange(Orders);
            context.SaveChanges(); 
        }
        else
        {
            System.Console.WriteLine("We already have Order data");
        }
    }
}