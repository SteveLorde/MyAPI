using AutoMapper;
using MyAPI.ForumApp.Data.DTOs;
using MyAPI.ForumApp.Data.DTOs.Responses;
using MyAPI.ForumApp.Data.Models;
using Thread = MyAPI.ForumApp.Data.Models.Thread;

namespace MyAPI.Services.AutoMapper;

public class ForumAppProfile : Profile
{
    public ForumAppProfile()
    {
        CreateMap<PostResponseDTO,Post>();
        CreateMap<ThreadResponseDTO,Thread>();
        CreateMap<Thread,ThreadResponseDTO>();
        
    }
    
}