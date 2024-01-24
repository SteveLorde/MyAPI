using AutoMapper;
using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.Models;
using MyAPI.Services.JWT.DTO;

namespace MyAPI.Services.AutoMapper;

public class EShopMappingProfile : Profile
{
    public EShopMappingProfile()
    {
        //MODEL TO DTO
        CreateMap<User, JWTRequestDTO>();
        CreateMap<Product,ProductDTO>();
        CreateMap<DiscountEvent,DiscountEventDTO>();
        
        //DTO to MODEL
        CreateMap<DiscountEventDTO,DiscountEvent>();
        CreateMap<ProductDTO,Product>();
        CreateMap<PurchaseLogDTO,PurchaseLog>();
    }
}