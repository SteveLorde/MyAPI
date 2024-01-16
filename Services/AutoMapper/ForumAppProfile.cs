using AutoMapper;
using MyAPI.ForumApp.Data.DTOs;
using MyAPI.ForumApp.Data.DTOs.Requests;
using MyAPI.ForumApp.Data.DTOs.Responses;
using MyAPI.ForumApp.Data.Models;
using Thread = MyAPI.ForumApp.Data.Models.Thread;

namespace MyAPI.Services.AutoMapper;

public class ForumAppProfile : Profile
{
    public ForumAppProfile()
    {
        CreateMap<AddPostRequestDTO,Post>();
        CreateMap<AddThreadRequestDTO,Thread>();
        
        CreateMap<Category,CategoryResponseDTO>();
        CreateMap<SubCategory,SubCategoryResponseDTO>();
        CreateMap<Thread,ThreadResponseDTO>();
        CreateMap<Post,PostResponseDTO>();
        CreateMap<User,UserResponseDTO>();
        
    }
    
}