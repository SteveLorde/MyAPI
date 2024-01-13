using AutoMapper;
using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.Models;

namespace MyAPI.Services.AutoMapper;

public class EShopMappingProfile : Profile
{
    public EShopMappingProfile()
    {
        CreateMap<NewsDTO,News>();
        CreateMap<ProductDTO,Product>();
        CreateMap<PurchaseLogDTO,PurchaseLog>();
    }
}