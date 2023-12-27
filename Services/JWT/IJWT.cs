namespace MyAPI.Services.JWT;

public interface IJWT
{
    public string CreateToken();
    public bool VerifyToken();
}