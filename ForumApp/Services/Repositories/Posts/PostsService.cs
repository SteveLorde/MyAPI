using AutoMapper;
using MyAPI.ForumApp.Data;
using MyAPI.ForumApp.Data.Models;
using MyAPI.ForumApp.Services.Repositories;

namespace MyAPI.ForumApp.Services.Repositories.Posts;

class PostsService : GenericRepository<Post> , IPostsService
{
    public PostsService(ForumAppDbContext db, IMapper mapper, IWebHostEnvironment hostingEnvironment) : base(db, mapper, hostingEnvironment)
    {

    }
    
    
    
    
}