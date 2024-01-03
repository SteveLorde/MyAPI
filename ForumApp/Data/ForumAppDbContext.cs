using Microsoft.EntityFrameworkCore;
using MyAPI.ForumApp.Data.Models;
using Thread = MyAPI.ForumApp.Data.Models.Thread;

namespace MyAPI.ForumApp.Data;

public class ForumAppDbContext : DbContext
{
    private readonly IWebHostEnvironment _hostenv;

    public ForumAppDbContext(IConfiguration configenv, IWebHostEnvironment hostenv)
    {
        _hostenv = hostenv;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var webbasedconnectionstring = Path.Combine(_hostenv.ContentRootPath, "ForumApp" ,"Data", "database.db");
        optionsBuilder.UseSqlite($"Data Source={webbasedconnectionstring}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
    
    public DbSet<Category> forumapp_categories { get; set; }
    public DbSet<SubCategory> forumapp_subcategories { get; set; }
    public DbSet<Post> forumapp_posts { get; set; }
    public DbSet<Thread> forumapp_threads { get; set; }
    public DbSet<User> forumapp_users { get; set; }
}