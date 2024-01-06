using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using MyAPI.ForumApp.Data.DataSeed;
using MyAPI.ForumApp.Data.Models;
using MyAPI.ForumApp.Services.Authentication.Model;
using MyAPI.Services.PasswordHash;
using Thread = MyAPI.ForumApp.Data.Models.Thread;

namespace MyAPI.ForumApp.Data;

public class ForumAppDbContext : DbContext
{
    private readonly IWebHostEnvironment _hostenv;
    private readonly IPasswordHash _passwordservice;

    public ForumAppDbContext(IConfiguration configenv, IWebHostEnvironment hostenv, IPasswordHash passwordservice)
    {
        _hostenv = hostenv;
        _passwordservice = passwordservice;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var webbasedconnectionstring = Path.Combine(_hostenv.ContentRootPath, "ForumApp" ,"Data", "database.db");
        optionsBuilder.UseSqlite($"Data Source={webbasedconnectionstring}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ForumDataSeeder.SeedData(modelBuilder);
        modelBuilder.Entity<User>().HasData(
            new User { Id = Guid.Parse("f36d69a4-9c09-4c08-9da4-a315d2093385"),username = "testuser1", hashedpassword = returnhashedpassword("1234") ,date = DateTime.Now, profileimage = "", usertype = "user", email = "testuser1@gmail.com"},
            new User { Id = Guid.Parse("cb89bdb8-348a-4af4-b837-8caa71bd7fb0"), username = "testuser2", hashedpassword = returnhashedpassword("1234") ,date = DateTime.Now, profileimage = "", usertype = "user", email = "testuser2@gmail.com"}
            );
    }
    
    public DbSet<Category> forumapp_categories { get; set; }
    public DbSet<SubCategory> forumapp_subcategories { get; set; }
    public DbSet<Post> forumapp_posts { get; set; }
    public DbSet<Thread> forumapp_threads { get; set; }
    public DbSet<User> forumapp_users { get; set; }
    
    private string returnhashedpassword(string password)
    {
        return _passwordservice.CreateHashedPassword(password);
    }

    
    
}