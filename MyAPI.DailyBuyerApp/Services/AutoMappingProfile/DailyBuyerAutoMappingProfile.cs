using AutoMapper;
using MyAPI.DailyBuyerApp.Data.DTO;
using MyAPI.DailyBuyerApp.Data.Models;

namespace MyAPI.DailyBuyerApp.Services.AutoMappingProfile;

public class DailyBuyerAutoMappingProfile : Profile
{

    public DailyBuyerAutoMappingProfile()
    {
        //Model To DTO
        CreateMap<Purchase, PurchaseResponseDto>();
        //DTO to Model
        CreateMap<PurchaseRequestDto, Purchase>();
    }

}