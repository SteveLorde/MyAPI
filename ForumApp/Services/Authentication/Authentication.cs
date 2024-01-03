using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.ForumApp.Data;
using MyAPI.ForumApp.Data.DTOs;
using MyAPI.ForumApp.Data.Models;
using MyAPI.ForumApp.Services.Authentication.Model;
using MyAPI.Services.JWT;
using MyAPI.Services.PasswordHash;

namespace MyAPI.ForumApp.Services.Authentication;

class Authentication : IAuthentication
{
    private readonly ForumAppDbContext _db;
    private readonly IJWT _jwtservice;
    private readonly IMapper _mapper;
    private readonly IPasswordHash _hashservice;

    public Authentication(ForumAppDbContext db, IPasswordHash hashservice,IJWT jwtservice, IMapper mapper)
    {
        _db = db;
        _jwtservice = jwtservice;
        _mapper = mapper;
        _hashservice = hashservice;
    }
    
    public async Task<string> Login(AuthRequestDTO loginreq)
    {
        string token = " ";
        //1st, check username in database
        bool checkuser = await _db.forumapp_users.AnyAsync(x => x.username == loginreq.username);
        if (checkuser)
        {
            var loginuser = await _db.forumapp_users.FirstAsync(x => x.username == loginreq.username);
            //2nd verify password
            bool checkpassword = await VerifyPassword(loginreq.password,loginuser.hashedpassword) ;
            if (checkpassword)
            {
                token  = _jwtservice.CreateToken(loginuser);
            }
        }
        return token;
    }

    public async Task<bool> Register(AuthRequestDTO registerreq)
    {
        //map a new userdto from authrequest
        UserDTO usertohash = _mapper.Map<UserDTO>(registerreq);
        //1-hash password
        Hash hashedpassword = await _hashservice.CreatePassword(usertohash.password);
        //2-create new user
        User newuser = _mapper.Map<User>(registerreq);
        //3-add to database
        await _db.forumapp_users.AddAsync(newuser);
        return true;
    }

    private async Task<bool> VerifyPassword(string password, string hashedpassword)
    {
        var hash = await _hashservice.CreatePassword(password);
        var passwordtoverify = hash.hash;
        if (passwordtoverify == hashedpassword)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public async Task<User> GetUser(string userid)
    {
        return await _db.forumapp_users.FirstAsync(user => user.Id == Guid.Parse(userid));
    }
}