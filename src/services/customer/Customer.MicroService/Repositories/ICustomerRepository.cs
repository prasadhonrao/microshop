using System.Collections.Generic;
using System.Linq.Expressions;
using Customer.MicroService.Entities;

namespace Customer.MicroService.Repositories;

public interface ICustomerRepository
{
    Task<CustomerEntity?> GetAsync(int id);
    Task<IEnumerable<CustomerEntity>> GetAllAsync();
    void Add(CustomerEntity entity);
    void Update(int id, CustomerEntity entity);
    void Patch(int id, CustomerEntity entity);
    void Delete(CustomerEntity entity);
    Task<IEnumerable<CustomerEntity>> FindAsync(Expression<Func<CustomerEntity, bool>> predicate);
    Task<bool> SaveChangesAsync();
    public Task<bool> CustomerExistsAsync(int id);

}