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
    
    public async Task<List<CategoriesResponseDTO>> GetMainCategories()
    {
        var queriedcategories = await _db.forumapp_categories.Include(c => c.subcategories).ThenInclude(s => s.threads).ToListAsync();
        List<CategoriesResponseDTO> maincategories = new List<CategoriesResponseDTO>();
        foreach (var cat in queriedcategories)
        {
            CategoriesResponseDTO catdto = new CategoriesResponseDTO();
            foreach (var subcat in cat.subcategories)
            {
                SubCategoryResponseDTO subcatdto = _mapper.Map<SubCategoryResponseDTO>(subcat);
                subcatdto.numofthreads = subcat.threads.Count;
                catdto.subcategories.Add(subcatdto);
            }
            maincategories.Add(catdto);
        }
        return maincategories;
    }

    public async Task<SubCategoryResponseDTO> GetSubCategoryThreads(string subcatid)
    {
        var queriedsubcats = await _db.forumapp_subcategories.Include(subcat => subcat.threads).ThenInclude(t => t.posts).ThenInclude(p => p.userposter).Include(s => s.threads).ThenInclude(t => t.userowner).FirstAsync(subcat => subcat.Id == Guid.Parse(subcatid));
        SubCategoryResponseDTO subcatresponsedto = new SubCategoryResponseDTO();
        foreach (var thread in queriedsubcats.threads)
        {
            ThreadResponseDTO threaddto = _mapper.Map<ThreadResponseDTO>(thread);
            threaddto.lastpost = _mapper.Map<PostResponseDTO>(thread.posts.Last());
            subcatresponsedto.threads.Add(threaddto);
        }
        return subcatresponsedto;
    }

    public async Task<ThreadResponseDTO> GetThread(string threadid)
    {
        var queriedthread = await _db.forumapp_threads.Include(t => t.posts).ThenInclude(p => p.userposter).FirstAsync(t => t.Id == Guid.Parse(threadid));
        ThreadResponseDTO thread = new ThreadResponseDTO();
        //DeSerialize POSTS DELTAS
        foreach (var post in queriedthread.posts)
        {
            PostResponseDTO postresponse = _mapper.Map<PostResponseDTO>(post);
            UserResponseDTO userresponse = _mapper.Map<UserResponseDTO>(post.userposter);
        }
        ThreadResponseDTO threadResponse = _mapper.Map<ThreadResponseDTO>(queriedthread);
        return threadResponse;
    }

    public async Task<bool> AddThread(string userid, AddThreadRequestDTO threadtoadd)
    {
        var subcategory = await _db.forumapp_subcategories.Include(s => s.threads).FirstAsync(s => s.Id == threadtoadd.subcategoryid);
        Thread newthread = _mapper.Map<Thread>(threadtoadd);
        subcategory.threads.Add(newthread);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddPost(string userid, AddPostRequestDTO posttoadd)
    {
        var thread = await _db.forumapp_threads.Include(t => t.posts).FirstAsync(t => t.Id == posttoadd.threadid);
        Post newpost = _mapper.Map<Post>(posttoadd);
        thread.posts.Add(newpost);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<UserResponseDTO> GetUser(string userid)
    {
        UserResponseDTO userResponseDto = _mapper.Map<UserResponseDTO>(await _db.forumapp_users.FirstAsync(u => u.Id == Guid.Parse(userid)));
        return userResponseDto;
    }
    
}