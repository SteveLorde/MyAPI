using Microsoft.EntityFrameworkCore;
using MyAPI.ForumApp.Data.Models;
using Thread = System.Threading.Thread;

namespace MyAPI.ForumApp.Data;

public class ForumAppDbContext : DbContext
{
    private readonly IConfiguration _configenv;
    private readonly IWebHostEnvironment _hostenv;

    public ForumAppDbContext(IConfiguration configenv, IWebHostEnvironment hostenv)
    {
        _configenv = configenv;
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

    //Forum App Tables
    public DbSet<Category> forumapp_categories { get; set; }
    public DbSet<SubCategory> forumapp_subcategories { get; set; }
    public DbSet<Post> forumapp_posts { get; set; }
    public DbSet<Thread> forumapp_threads { get; set; }
    public DbSet<User> forumapp_users { get; set; }
}