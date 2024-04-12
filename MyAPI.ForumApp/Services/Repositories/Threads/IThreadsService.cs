using MyAPI.ForumApp.Data.DTOs.Requests;
using MyAPI.ForumApp.Data.DTOs.Responses;

namespace MyAPI.ForumApp.Services.Repositories.Threads;

public interface IThreadsService
{
    public Task<SubCategoryResponseDTO> GetSubCategoryThreads(string subcatid);
    public Task<ThreadResponseDTO> GetThread(string threadid);
    public Task<bool> AddThread(AddThreadRequestDTO threadtoadd);
    public Task<bool> AddPost(AddPostRequestDTO posttoadd);
}