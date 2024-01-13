using MyAPI.ForumApp.Data.DTOs;
using MyAPI.ForumApp.Data.DTOs.Requests;
using MyAPI.ForumApp.Data.DTOs.Responses;
using MyAPI.ForumApp.Data.Models;
using Thread = MyAPI.ForumApp.Data.Models.Thread;

namespace MyAPI.ForumApp.Services.Repositories.Forum;

public interface IForumService : IGenericRepository<Thread>
{
    public Task<List<CategoriesResponseDTO>> GetMainCategories();
    public Task<SubCategoryResponseDTO> GetSubCategoryThreads(string subcatid);
    public Task<ThreadResponseDTO> GetThread(string threadid);
    public Task<bool> AddThread(string userid, AddThreadRequestDTO threadtoadd);
    public Task<bool> AddPost(string userid, AddPostRequestDTO posttoadd);
    public Task<UserResponseDTO> GetUser(string userid);
}