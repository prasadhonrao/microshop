using AutoMapper;
using Customer.MicroService.Controllers;
using Customer.MicroService.Entities;
using Customer.MicroService.Repositories;
//using Customer.MicroService.Services.Async;
using Customer.MicroService.Services.Sync;
using System.Linq.Expressions;

namespace Customer.MicroService.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public void Add(CustomerEntity entity)
        {
            this.customerRepository.Add( entity );
        }

        public void Update(int id, CustomerEntity entity)
        {
            this.customerRepository.Update( id, entity );
        }

        public void Patch(int id, CustomerEntity entity)
        {
            this.customerRepository.Patch(id, entity);
        }

        public void Delete(CustomerEntity entity)
        {
            this.customerRepository.Delete(entity);   
        }

        public Task<IEnumerable<CustomerEntity>> FindAsync(Expression<Func<CustomerEntity, bool>> predicate)
        {
            return this.customerRepository.FindAsync( predicate );
        }

        public Task<IEnumerable<CustomerEntity>> GetAllAsync()
        {
            return customerRepository.GetAllAsync();
        }

        public Task<CustomerEntity?> GetAsync(int id)
        {
            return customerRepository.GetAsync( id );
        }

        public Task<bool> SaveChangesAsync()
        {
            return customerRepository.SaveChangesAsync();
        }
    }
}
