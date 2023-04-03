using System.Collections.Generic;
using Customer.MicroService.Entities;

namespace Customer.MicroService.Repositories;

public interface ICustomerRepository
{
    IEnumerable<CustomerEntity> GetAll();
    CustomerEntity GetById(int id);
    // IEnumerable<CustomerEntity> GetByIds(int[] ids);
    CustomerEntity DeleteById(int id);
    void Add(CustomerEntity newCustomer);
    void Update(int id, CustomerEntity updatedCustomer);

    // This method is required by EF Core
    bool SaveChanges();

}