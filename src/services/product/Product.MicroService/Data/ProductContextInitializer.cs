using System.Collections.Generic;
using System.Linq;
using Product.MicroService.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Product.MicroService.Data;

public static class ProductContextInitializer 
{
    public static void PrepareData(IApplicationBuilder builder) 
    {
        using(var scope = builder.ApplicationServices.CreateScope()) 
        {
            SeedData(scope.ServiceProvider.GetService<ProductContext>());
        }
    }

    private static void SeedData(ProductContext context) 
    {
        // Populate in-memory data
        if (!context.Products.Any())
        {
            System.Console.WriteLine("Populating in memory Product data");

            context.Products.AddRange(
                new ProductEntity() { ProductID = 1, ProductName = "P1" },
                new ProductEntity() { ProductID = 2,ProductName = "P2" },
                new ProductEntity() { ProductID = 3,ProductName = "P3" }
            );

            context.SaveChanges(); 
        }
        else
        {
            System.Console.WriteLine("We already have Product data");
        }
    }
}