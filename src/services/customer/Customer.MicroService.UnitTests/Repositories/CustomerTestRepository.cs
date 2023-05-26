using Customer.MicroService.Entities;
using Customer.MicroService.Repositories;
using System.Linq.Expressions;

namespace Customer.MicroService.UnitTests.Repositories
{
    public class CustomerTestRepository : ICustomerRepository
    {
        private readonly List<CustomerEntity> customers;

        public CustomerTestRepository()
        {
            customers = new List<CustomerEntity>
            {
                // Add dummy data
                new CustomerEntity(1, "John", "Doe"),
                new CustomerEntity(2, "Jane", "Smith"),
                new CustomerEntity(3, "Alice", "Johnson")
            };
        }

        public void Add(CustomerEntity customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            customers.Add(customer);
        }

        public void Update(int id, CustomerEntity customer)
        {
            var existingCustomer = customers.FirstOrDefault(c => c.Id == id);
            if (existingCustomer == null) throw new ArgumentNullException(nameof(existingCustomer));

            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
        }

        public void Patch(int id, CustomerEntity customer)
        {
            var existingCustomer = customers.FirstOrDefault(c => c.Id == id);
            if (existingCustomer == null) throw new ArgumentNullException(nameof(existingCustomer));

            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
        }

        public void Delete(CustomerEntity customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            customers.Remove(customer);
        }

        public async Task<IEnumerable<CustomerEntity>> FindAsync(Expression<Func<CustomerEntity, bool>> predicate)
        {
            return await Task.FromResult(customers.AsQueryable().Where(predicate.Compile()).ToList());
        }

        public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
        {
            return await Task.FromResult<IEnumerable<CustomerEntity>>(customers);
        }

        public async Task<CustomerEntity?> GetAsync(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(customer);
        }


        public async Task<bool> SaveChangesAsync()
        {
            return await Task.FromResult(true); // In-memory repository does not require saving changes
        }

        public Task<bool> CustomerExistsAsync(int id)
        {
            bool customerExists = customers.Any(c => c.Id == id);
            return Task.FromResult(customerExists);
        }
    }
}
