using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MyAPI.Data.DTOs;
using MyAPI.ForumApp.Data.DTOs;
using MyAPI.ForumApp.Data.Models;
using MyAPI.ForumApp.Services.Authentication.Model;

namespace MyAPI.Services.JWT;

class Jwt : IJWT
{
    private IConfiguration _config;

    private string jwtseckey;

    public Jwt(IConfiguration config)
    {
        _config = config;
        jwtseckey = _config["secretkey"];
    }

    public string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.username),
            new Claim("userid", user.Id.ToString()),
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtseckey));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var tokendata = new JwtSecurityToken(
            claims: claims,
            issuer: "",
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