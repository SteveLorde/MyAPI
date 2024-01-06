using Microsoft.EntityFrameworkCore;
using MyAPI.ForumApp.Data;
using MyAPI.ForumApp.Data.Models;

namespace MyAPI.ForumApp.Services.Repositories.Users;

class UsersRepository : IUsersRepository
{
    private readonly ForumAppDbContext _db;
    private DbSet<User> _usersdb;

    public UsersRepository(ForumAppDbContext db)
    {
        _db = db;
        _usersdb = _db.forumapp_users;
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
    
}