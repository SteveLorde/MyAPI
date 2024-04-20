using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MyAPI.ForumApp.Data;
using MyAPI.ForumApp.Data.Models;

namespace MyAPI.ForumApp.Services.Repositories.Users;

class UsersRepository : IUsersRepository
{
    private readonly ForumAppDbContext _db;
    private DbSet<User> _usersdb;
    private readonly IWebHostEnvironment _webhostenv;

    public UsersRepository(ForumAppDbContext db, IWebHostEnvironment webhostenv)
    {
        _db = db;
        _usersdb = _db.forumapp_users;
        _webhostenv = webhostenv;
    }
    
    public async Task<bool> AddNewUser(User newuser)
    {
        await _usersdb.AddAsync(newuser);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<List<User>> GetUsers()
    {
        return await _usersdb.ToListAsync();
    }

    public async Task<User?> GetUser(string userid)
    {
        return await _usersdb.FindAsync(Guid.Parse(userid));
    }

    public async Task CreateUsersFolders()
    {
        List<User> allusers = await _db.forumapp_users.ToListAsync();
        foreach (User user in allusers)
        {
            string storagePath = Path.Combine(_webhostenv.ContentRootPath, "Storage", "ForumApp", user.Id.ToString());
            Directory.CreateDirectory(storagePath);
        }
    }
    
}