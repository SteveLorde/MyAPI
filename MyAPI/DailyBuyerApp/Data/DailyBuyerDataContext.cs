using Microsoft.EntityFrameworkCore;
using MyAPI.DailyBuyerApp.Data.Models;

namespace MyAPI.DailyBuyerApp.Data;

public class DailyBuyerDataContext : DbContext
{

    public DailyBuyerDataContext(IConfiguration configenv)
    {

    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source=dailybuyerdata.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
    
    public DbSet<Purchase> Purchases { get; set; }
    
    
}