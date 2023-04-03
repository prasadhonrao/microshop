using System.Collections.Generic;
using System.Linq;
using Customer.MicroService.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.MicroService.Data;

public static class CustomerContextInitializer 
{
    public static void PrepareData(IApplicationBuilder builder) 
    {
        using(var scope = builder.ApplicationServices.CreateScope()) 
        {
            SeedData(scope.ServiceProvider.GetService<CustomerContext>());
        }
    }

    private static void SeedData(CustomerContext context) 
    {
        // Populate in-memory data
        if (!context.Customers.Any())
        {
            System.Console.WriteLine("Populating in memory customer data");

            context.Customers.AddRange(
                new CustomerEntity() { ContactName = "Maria Aders" },
                new CustomerEntity() { ContactName = "Thomas Hardy" },
                new CustomerEntity() { ContactName = "Prasad Honrao" }
            );

            context.SaveChanges(); 
        }
        else
        {
            System.Console.WriteLine("We already have customer data");
        }
    }
}