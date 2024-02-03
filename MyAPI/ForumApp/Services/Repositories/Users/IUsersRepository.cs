using MyAPI.ForumApp.Data.Models;

namespace MyAPI.ForumApp.Services.Repositories.Users;

public interface IUsersRepository
{
    public Task<bool> AddNewUser(User newuser);
    public Task<List<User>> GetUsers();
    public Task<User?> GetUser(string userid);
}