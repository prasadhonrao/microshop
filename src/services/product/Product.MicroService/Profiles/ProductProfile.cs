using AutoMapper;
using Product.MicroService.Entities;
using Product.MicroService.Models;

namespace Product.MicroService.Profiles;

public class ProductProfile:Profile 
{
    public ProductProfile()
    {
        CreateMap<ProductEntity, ProductReadModel>(); // Read
        CreateMap<ProductCreateModel, ProductEntity>(); // Create
    }
}