using Customer.API.Data;
using Customer.API.Entities;

namespace Customer.API.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerContext _context;

    public CustomerRepository(CustomerContext context)
    {
        _context = context;
    }
    public void Add(CustomerEntity newCustomer)
    {
        if (newCustomer == null) throw new ArgumentNullException(nameof(newCustomer));
        _context.Customers.Add(newCustomer);
    }

    public CustomerEntity DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<CustomerEntity> GetAll()
    {
        return (IEnumerable<CustomerEntity>)_context.Customers.ToList();
    }

    public CustomerEntity GetById(int id)
    {
        return _context.Customers.FirstOrDefault(c => c.CustomerID == id);
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() >= 0;
    }

    public void Update(int id, CustomerEntity updatedCustomer)
    {
        throw new NotImplementedException();
    }
}