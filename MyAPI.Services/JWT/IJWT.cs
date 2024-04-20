using MyAPI.Services.JWT.DTO;

namespace MyAPI.Services.JWT;

public interface IJWT
{
    public string CreateToken(JWTRequestDTO userjwtreq);
    //public bool VerifyToken(string token);
}