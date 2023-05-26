using Customer.MicroService.Entities;
using Customer.MicroService.Models;
using System.Linq.Expressions;

namespace Customer.MicroService.Services
{
    public interface ICustomerService
    {
        Task<CustomerEntity?> GetAsync(int id);
        Task<IEnumerable<CustomerEntity>> GetAllAsync();
        void Add(CustomerEntity entity);
        void Update(int id, CustomerEntity entity);
        void Patch(int id, CustomerEntity entity);
        void Delete(int entity);
        Task<IEnumerable<CustomerEntity>> FindAsync(Expression<Func<CustomerEntity, bool>> predicate);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<OrderReadModel>?> GetOrders(int customerId);
        public Task<bool> CustomerExistsAsync(int id);
    }
}
