using Microsoft.EntityFrameworkCore;

namespace MyAPI.Data;

public class DataContext : DbContext
{
    
    private readonly IConfiguration _configenv;

    public DataContext(IConfiguration configenv)
    {
        _configenv = configenv;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configenv["DatabaseConnection"]);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

}