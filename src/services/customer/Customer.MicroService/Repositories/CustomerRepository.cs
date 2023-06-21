using Customer.MicroService.Data;
using Customer.MicroService.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Customer.MicroService.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomersDbContext context;

    public CustomerRepository(CustomersDbContext context)
    {
        this.context = context;
    }

    public void Add(CustomerEntity customer)
    {
        if (customer == null) throw new ArgumentNullException(nameof(customer));
        context.Add(customer);
    }

    public void Update(int id, CustomerEntity customer)
    {
        var existingCustomer = context.Customers.FirstOrDefault(c => c.Id == id);
        if (existingCustomer == null) throw new ArgumentNullException(nameof(existingCustomer));

        existingCustomer.CompanyName = customer.CompanyName;
        existingCustomer.ContactName = customer.ContactName;
        existingCustomer.ContactTitle = customer.ContactTitle;
        existingCustomer.Address = customer.Address;
        existingCustomer.City = customer.City;
        existingCustomer.Region = customer.Region;
        existingCustomer.PostalCode = customer.PostalCode;
        existingCustomer.Country = customer.Country;
        existingCustomer.Phone = customer.Phone;
        existingCustomer.Fax = customer.Fax;

        context.Entry(existingCustomer).State = EntityState.Modified;
    }

    public void Patch(int id, CustomerEntity customer)
    {
        var existingCustomer = context.Customers.FirstOrDefault(c => c.Id == id);
        if (existingCustomer == null) throw new ArgumentNullException(nameof(existingCustomer));

        context.Entry(existingCustomer).Property("Id").IsModified = false;
        context.Entry(existingCustomer).CurrentValues.SetValues(customer);
        context.Entry(existingCustomer).State = EntityState.Modified;
    }

    public void Delete(CustomerEntity customer)
    {
        if (customer == null) throw new ArgumentNullException(nameof(customer));
        context.Remove(customer);
    }

    public async Task<IEnumerable<CustomerEntity>> FindAsync(Expression<Func<CustomerEntity, bool>> predicate)
    {
        return await context.Customers.Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        return await context.Customers.ToListAsync();
    }

    public async Task<CustomerEntity> GetAsync(int id)
    {
        return await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await context.SaveChangesAsync() > 0);
    }

    public async Task<bool> CustomerExistsAsync(int id)
    {
        return await context.Customers.AnyAsync(c => c.Id == id);
    }

}