using AutoMapper;
using Customer.API.Entities;
using Customer.API.Models;

namespace Customer.API.Profiles;

public class CustomerProfile:Profile 
{
    public CustomerProfile()
    {
        // Source -> Target
        CreateMap<CustomerEntity, CustomerReadModel>();
        CreateMap<CustomerCreateModel, CustomerEntity>();
    }
}