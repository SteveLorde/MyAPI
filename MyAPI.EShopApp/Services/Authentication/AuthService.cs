using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyAPI.EShopApp.Data;
using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.DTOs.Requests;
using MyAPI.EShopApp.Data.Models;
using MyAPI.Services.JWT;
using MyAPI.Services.JWT.DTO;
using MyAPI.Services.PasswordHash;

namespace MyAPI.EShopApp.Services.Authentication;

class AuthService : IAuthService
{
    private readonly EShopDataContext _db;
    private readonly IPasswordHash _hashservice;
    private readonly IJWT _jwtservice;
    private readonly IMapper _mapper;

    public AuthService(EShopDataContext db, IPasswordHash hashservice, IJWT jwtservice, IMapper mapper)
    {
        _db = db;
        _hashservice = hashservice;
        _jwtservice = jwtservice;
        _mapper = mapper;
    }
    
    
    public async Task<string> Login(LoginRequestDTO loginreq)
    {
        string token = "token x";
        //1st, check username in database
        bool checkuser = await _db.Users.AnyAsync(x => x.username == loginreq.username);
        if (!checkuser)
        {
            return "user not found";
        }
        else
        {
            var loginuser = await _db.Users.FirstAsync(x => x.username == loginreq.username);
            JWTRequestDTO userjwtreq = _mapper.Map<JWTRequestDTO>(loginuser);
            //2nd verify password
            bool checkpassword = await VerifyPassword(loginreq.password, loginuser.hashedpassword) ;
            if (checkpassword)
            {
                token  = _jwtservice.CreateToken(userjwtreq);
                return token;
            }
            else
            {
                return "wrong password";
            }
        }
    }

    public async Task<bool> Register(RegisterRequestDTO registerreq)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDTO> GetUser(string userid)
    {
        return await _db.Users.Include(user => user.PurchaseLogs).ProjectTo<UserDTO>(_mapper.ConfigurationProvider).FirstAsync(user => user.Id == Guid.Parse(userid));
    }
    
    private async Task<bool> VerifyPassword(string passwordtoverify, string hashedpassword)
    {
        //1-extract salt from database user hashedpassword, pass string pattern SALT.HASHEDPASSWORD
        var extractedsavedpassword = hashedpassword.Split(".");
        var extractedsalt = extractedsavedpassword[0];
        var extractedhashedpass = extractedsavedpassword[1];
        //2-generate hashed password with given salt
        var passwordtotest = _hashservice.HashPasswordWithGivenSalt(passwordtoverify, extractedsalt);
        Console.WriteLine("hashed password to test is: " + passwordtotest + "  VERSUS  " + extractedhashedpass);
        //3-compare
        if (passwordtotest == extractedhashedpass)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}