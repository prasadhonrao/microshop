using System.Collections.Generic;
using System.Linq;
using Customer.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.API.Data;

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
        // In memory data
        if (!context.Customers.Any())
        {
            System.Console.WriteLine("Populating in memory customer data");
            List<CustomerEntity> customers = new List<CustomerEntity>();
            customers.Add(new CustomerEntity() { ContactName = "Maria Aders" });
            customers.Add(new CustomerEntity() { ContactName = "Thomas Hardy" });
            customers.Add(new CustomerEntity() { ContactName = "Prasad Honrao" });
            context.Customers.AddRange(customers);
            context.SaveChanges(); 
        }
        else
        {
            System.Console.WriteLine("We already have customer data");
        }
    }
}