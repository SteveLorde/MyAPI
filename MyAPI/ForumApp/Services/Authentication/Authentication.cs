using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.ForumApp.Data;
using MyAPI.ForumApp.Data.DTOs;
using MyAPI.ForumApp.Data.DTOs.Requests;
using MyAPI.ForumApp.Data.Models;
using MyAPI.ForumApp.Services.Authentication.Model;
using MyAPI.ForumApp.Services.Repositories.Users;
using MyAPI.Services.JWT;
using MyAPI.Services.JWT.DTO;
using MyAPI.Services.PasswordHash;

namespace MyAPI.ForumApp.Services.Authentication;

class Authentication : IAuthentication
{
    private readonly ForumAppDbContext _db;
    private readonly IJWT _jwtservice;
    private readonly IMapper _mapper;
    private readonly IPasswordHash _hashservice;
    private readonly IUsersRepository _usersrepo;

    public Authentication(ForumAppDbContext db, IPasswordHash hashservice,IJWT jwtservice, IMapper mapper, IUsersRepository usersrepo)
    {
        _db = db;
        _jwtservice = jwtservice;
        _mapper = mapper;
        _hashservice = hashservice;
        _usersrepo = usersrepo;
    }
    
    public async Task<string> Login(LoginRequestDTO loginreq)
    {
        string token = "token x";
        //1st, check username in database
        bool checkuser = await _db.forumapp_users.AnyAsync(x => x.username == loginreq.username);
        if (!checkuser)
        {
            return "user not found";
        }
        else
        {
            var loginuser = await _db.forumapp_users.FirstAsync(x => x.username == loginreq.username);
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
        //map a new userdto from authrequest
        UserRequestDTO usertohash = _mapper.Map<UserRequestDTO>(registerreq);
        //1-hash password
        string hashedpassword =  _hashservice.CreateHashedPassword(usertohash.password);
        //2-create new user
        User newuser = new User { Id = Guid.NewGuid(), username = usertohash.username, date = DateTime.Now, hashedpassword = hashedpassword, usertype = "user", email = usertohash.email, profileimage = usertohash.profilepicfilename };
        //3-add to database
        return await _usersrepo.AddNewUser(newuser);
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

    public async Task<User> GetUser(string userid)
    {
        return await _db.forumapp_users.FirstAsync(user => user.Id == Guid.Parse(userid));
    }
}