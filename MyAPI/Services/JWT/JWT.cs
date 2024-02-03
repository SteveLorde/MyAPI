using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MyAPI.Data.DTOs;
using MyAPI.ForumApp.Data.DTOs;
using MyAPI.ForumApp.Data.Models;
using MyAPI.ForumApp.Services.Authentication.Model;
using MyAPI.Services.JWT.DTO;

namespace MyAPI.Services.JWT;

class JWT : IJWT
{
    private IConfiguration _config;

    private string jwtseckey;
    private readonly IWebHostEnvironment _webenv;
    private readonly IHttpContextAccessor _httpContextAccessor;
    

    public JWT(IConfiguration config, IHttpContextAccessor httpContextAccessor)
    {
        _config = config;
        jwtseckey = _config["secretkey"];
        _httpContextAccessor = httpContextAccessor;
    }

    public string CreateToken(JWTRequestDTO userjwtreq)
    {
        string baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}";

        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userjwtreq.username),
            new Claim("userid", userjwtreq.Id.ToString()),
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtseckey));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var tokendata = new JwtSecurityToken(
            claims: claims,
            issuer: $"{baseUrl}",
            audience: "",
            expires: DateTime.Now.AddDays(2),
            signingCredentials: cred
        );
        var jwt = new JwtSecurityTokenHandler().WriteToken(tokendata);
        return jwt;
    }

    //UNUSED
    /*
    public bool VerifyToken(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretkey = Encoding.UTF8.GetBytes(jwtseckey);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretkey),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero // You may adjust the clock skew as needed
            };

            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

            return true;

        }
        catch (Exception err)
        {
            throw err;
        }
    }
    */
    
    
}