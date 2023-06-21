using AutoMapper;
using Customer.MicroService.Entities;
using Customer.MicroService.Models;

namespace Customer.MicroService.Profiles;

public class CustomerProfile:Profile 
{
    public CustomerProfile()
    {
        CreateMap<CustomerEntity, CustomerReadModel>();
        CreateMap<CustomerCreateModel, CustomerEntity>();
    }
}