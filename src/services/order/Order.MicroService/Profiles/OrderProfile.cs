using AutoMapper;
using Order.MicroService.Entities;
using Order.MicroService.Models;

namespace Order.MicroService.Profiles;

public class OrderProfile:Profile 
{
    public OrderProfile()
    {
        // Source -> Target
        CreateMap<OrderEntity, OrderReadModel>();
        CreateMap<OrderCreateModel, OrderEntity>();
    }
}