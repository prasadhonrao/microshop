using Customer.MicroService.Data;
using Customer.MicroService.Entities;
using Microsoft.EntityFrameworkCore;

public interface IDataSeeder
{
    Task SeedDataAsync();
}

public class DataSeeder : IDataSeeder
{
    private readonly CustomersDbContext _dbContext;

    public DataSeeder(CustomersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SeedDataAsync()
    {
        if (!await _dbContext.Customers.AnyAsync())
        {
            var customer = new CustomerEntity
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
            };

            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }
    }
}