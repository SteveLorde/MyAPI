using AutoMapper;
using MyAPI.ForumApp.Data.DTOs;
using MyAPI.ForumApp.Data.Models;
using Thread = MyAPI.ForumApp.Data.Models.Thread;

namespace MyAPI.Services.AutoMapper;

public class ForumAppProfile : Profile
{
    public ForumAppProfile()
    {
        CreateMap<PostDTO,Post>();
        CreateMap<ThreadDTO,Thread>();
        
    }
    
}