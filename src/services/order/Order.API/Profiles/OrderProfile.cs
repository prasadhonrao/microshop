using AutoMapper;
using Order.API.Entities;
using Order.API.Models;

namespace Order.API.Profiles;

public class OrderProfile:Profile 
{
    public OrderProfile()
    {
        // Source -> Target
        CreateMap<OrderEntity, OrderReadModel>();
        CreateMap<OrderCreateModel, OrderEntity>();
    }
}