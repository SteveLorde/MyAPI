using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAPI.ForumApp.Data;
using MyAPI.ForumApp.Data.DTOs;
using MyAPI.ForumApp.Data.DTOs.Requests;
using MyAPI.ForumApp.Data.DTOs.Responses;
using MyAPI.ForumApp.Data.Models;
using Thread = MyAPI.ForumApp.Data.Models.Thread;

namespace MyAPI.ForumApp.Services.Repositories.Forum;

class ForumService : GenericRepository<Thread>, IForumService
{
    public ForumService(ForumAppDbContext db, IMapper mapper, IWebHostEnvironment hostingEnvironment) : base(db,
        mapper, hostingEnvironment)
    {

    }
    
    public async Task<List<CategoryResponseDTO>> GetMainCategories()
    {
        var queriedcategories = await _db.forumapp_categories.Include(c => c.subcategories).ThenInclude(s => s.threads).ThenInclude(t => t.posts).ToListAsync();
        List<CategoryResponseDTO> categoriesresponse = new List<CategoryResponseDTO>();
        foreach (var cat in queriedcategories)
        {
            CategoryResponseDTO catresponse = _mapper.Map<CategoryResponseDTO>(cat);
            categoriesresponse.Add(catresponse);
        }
        foreach (var catresponse in categoriesresponse)
        {
            foreach (var subcat in catresponse.subcategories)
            {
                subcat.numofthreads = subcat.threads.Count;
            }
        }
        categoriesresponse.OrderBy(cat => cat.orderingid);
        return categoriesresponse;
    }



    public async Task<UserResponseDTO> GetUser(string userid)
    {
        UserResponseDTO userResponseDto = _mapper.Map<UserResponseDTO>(await _db.forumapp_users.FirstAsync(u => u.Id == Guid.Parse(userid)));
        return userResponseDto;
    }
    
}