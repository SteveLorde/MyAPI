using MyAPI.ForumApp.Data.DTOs;
using MyAPI.ForumApp.Data.DTOs.Requests;
using MyAPI.ForumApp.Data.DTOs.Responses;
using MyAPI.ForumApp.Data.Models;
using Thread = MyAPI.ForumApp.Data.Models.Thread;

namespace MyAPI.ForumApp.Services.Repositories.Forum;

public interface IForumService : IGenericRepository<Thread>
{
    public Task<List<CategoryResponseDTO>> GetMainCategories();


    public Task<UserResponseDTO> GetUser(string userid);
}