using AutoMapper;
using Customer.MicroService.Entities;
using Customer.MicroService.Models;

namespace Customer.MicroService.Profiles;

public class CustomerProfile:Profile 
{
    public CustomerProfile()
    {
        // Source -> Target
        CreateMap<CustomerEntity, CustomerReadModel>()
            .ForMember(c => c.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));


        CreateMap<CustomerCreateModel, CustomerEntity>()
           .ConstructUsing(c => new CustomerEntity(c.FirstName, c.LastName));
    }
}