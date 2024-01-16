using AutoMapper;
using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.Models;
using MyAPI.Services.JWT.DTO;

namespace MyAPI.Services.AutoMapper;

public class EShopMappingProfile : Profile
{
    public EShopMappingProfile()
    {
        CreateMap<User, JWTRequestDTO>();
        CreateMap<NewsDTO,News>();
        CreateMap<ProductDTO,Product>();
        CreateMap<PurchaseLogDTO,PurchaseLog>();
    }
}