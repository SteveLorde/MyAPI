using MyAPI.ForumApp.Services.Authentication.Model;

namespace MyAPI.Services.PasswordHash;

public interface IPasswordHash
{
    public Task<Hash> CreatePassword(string password);
}