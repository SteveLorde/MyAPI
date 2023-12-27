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
        var webbasedconnectionstring = Path.Combine(_hostenv.ContentRootPath, "Data", "database.db");
        optionsBuilder.UseSqlite(webbasedconnectionstring);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

}