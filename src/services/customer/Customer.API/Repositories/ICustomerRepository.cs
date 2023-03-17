using System.Collections.Generic;
using Customer.API.Entities;

namespace Customer.API.Repositories;

public interface ICustomerRepository
{
    IEnumerable<CustomerEntity> GetAll();
    CustomerEntity GetById(int id);
    CustomerEntity DeleteById(int id);
    void Add(CustomerEntity newCustomer);
    void Update(int id, CustomerEntity updatedCustomer);

    bool SaveChanges();

}