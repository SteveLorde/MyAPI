using Microsoft.EntityFrameworkCore;

namespace MyAPI.Data;

public class DataContext : DbContext
{
    
    private readonly IConfiguration _configenv;
    private readonly IWebHostEnvironment _hostenv;

    public DataContext(IConfiguration configenv, IWebHostEnvironment hostenv)
    {
        _configenv = configenv;
        _hostenv = hostenv;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlite(_configenv["DatabaseConnection"]);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

}