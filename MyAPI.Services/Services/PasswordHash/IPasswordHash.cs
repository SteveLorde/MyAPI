
namespace MyAPI.Services.PasswordHash;

public interface IPasswordHash
{
    public string CreateHashedPassword(string password);
    public string HashPasswordWithGivenSalt(string password, string salt);
}