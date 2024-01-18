using Microsoft.EntityFrameworkCore;
using MyAPI.EShopApp.Data.Models;

namespace MyAPI.EShopApp.Data;

public class EShopDataContext : DbContext
{
    private readonly IConfiguration _configenv;
    private readonly IWebHostEnvironment _hostenv;

    public EShopDataContext(IConfiguration configenv, IWebHostEnvironment hostenv)
    {
        _configenv = configenv;
        _hostenv = hostenv;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var webbasedconnectionstring = Path.Combine(_hostenv.ContentRootPath, "EShopApp" ,"Data", "eshopdatabase.db");
        optionsBuilder.UseSqlite($"Data Source={webbasedconnectionstring}");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParentCategory>().HasData(
            new ParentCategory {Id = Guid.Parse("5cd3afb6-9c0f-11ee-8c90-0242ac120002"), name = "Electronics"},
            new ParentCategory {Id = Guid.Parse("6d8e2cc8-9c0f-11ee-8c90-0242ac120002"), name = "Groceries"},
            new ParentCategory {Id = Guid.Parse("733d2eda-9c0f-11ee-8c90-0242ac120002"), name = "Home and Garden"},
            new ParentCategory {Id = Guid.Parse("780fcde6-9c0f-11ee-8c90-0242ac120002"), name = "Beauty and Personal Care"}
        );
        
        modelBuilder.Entity<Category>().HasData(
            new Category {Id = Guid.Parse("ec5e2a09-3785-4b4b-90e6-1353ddb5aee6"), name = "Computer Hardware", ParentCategoryId = Guid.Parse("5cd3afb6-9c0f-11ee-8c90-0242ac120002")},
            new Category {Id = Guid.Parse("92c17ce6-92b8-4515-9fc3-e38fcc51d83e"), name = "Mobiles and Accesories", ParentCategoryId = Guid.Parse("5cd3afb6-9c0f-11ee-8c90-0242ac120002")},
            new Category {Id = Guid.Parse("3ac2239f-3d70-4da0-b81e-bda272847e7c"), name = "Kitchen and Appliances", ParentCategoryId = Guid.Parse("733d2eda-9c0f-11ee-8c90-0242ac120002")},
            new Category {Id = Guid.Parse("ef39fd90-d4fd-46aa-95bf-23672f549756"), name = "Vegetables", ParentCategoryId = Guid.Parse("6d8e2cc8-9c0f-11ee-8c90-0242ac120002")},
            new Category {Id = Guid.Parse("f1c3a402-5e08-4e13-a08f-4d9ab5062a9e"), name = "Video Games", ParentCategoryId = Guid.Parse("5cd3afb6-9c0f-11ee-8c90-0242ac120002")},
            new Category {Id = Guid.Parse("bb2dc742-a510-4a83-a0fa-e454df3a559c"), name = "Tablets", ParentCategoryId = Guid.Parse("5cd3afb6-9c0f-11ee-8c90-0242ac120002")},
            new Category {Id = Guid.Parse("3e80f63e-6866-4a58-a7e7-8151b8c7c199"), name = "Face and Hair", ParentCategoryId = Guid.Parse("780fcde6-9c0f-11ee-8c90-0242ac120002")}
        );
        
        modelBuilder.Entity<Event>().HasData(
            new Event { Id = Guid.Parse("0d8b8ff5-db08-4ee0-ae55-dd0267116b5d"), title = "Christmas Discounts on Electronics", subtitle = null, description = "Desc Test", published = new DateOnly(2024,1,1), image = "newscover.jpg"},
            new Event { Id = Guid.Parse("1a55b12e-65b8-4542-b4c1-6676c30311e7"), title = "Shop Smart, Save Big: Exclusive Year-End Sale with Unbeatable Discounts!", subtitle = null, description = "Desc Test", published = new DateOnly(2024,1,1), image = "newscover.jpg" },
            new Event { Id = Guid.Parse("93097c20-6558-4ed9-a27e-8bf07fb59b8a"), title = "Digital Winter VideoGames Sales", subtitle = null, description = "Desc Test", published = new DateOnly(2024,1,1), image = "newscover.jpg" }
            );
        
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = Guid.Parse("4eaf8297-449c-4aea-a656-a92b8730a201"), name = "PC Build 2024", description = "Description Test", CategoryId = Guid.Parse("ec5e2a09-3785-4b4b-90e6-1353ddb5aee6"), price = 500 ,images = new string[] {"1.jpg", "2.jpg" } },
            new Product { Id = Guid.Parse("4fe905ac-63ae-4e9c-a10f-b6379b594c18"), name = "Face Cosmetic Kit", description = "Description Test", CategoryId = Guid.Parse("3e80f63e-6866-4a58-a7e7-8151b8c7c199"), price = 74,images = new string[] {"1.jpg", "2.jpg" } },
            new Product { Id = Guid.Parse("45ee830f-a1f3-44ad-8112-982ef324dab4"), name = "Hair Care Kit", description = "Description Test", CategoryId = Guid.Parse("3e80f63e-6866-4a58-a7e7-8151b8c7c199"), price = 200,images = new string[] {"1.jpg", "2.jpg" } },
            new Product { Id = Guid.Parse("710df7a2-9cf9-4b80-89d5-20be76a621af"), name = "Body Care Kit", description = "Description Test", CategoryId = Guid.Parse("3e80f63e-6866-4a58-a7e7-8151b8c7c199"), price = 1000,images = new string[] {"1.jpg", "2.jpg" } },
            new Product { Id = Guid.Parse("4679e631-8273-49cd-91a6-fae714ea9d73"), name = "Videogame", description = "Description Test", CategoryId = Guid.Parse("f1c3a402-5e08-4e13-a08f-4d9ab5062a9e"), price = 500,images = new string[] {"1.jpg", "2.jpg" } },
            new Product { Id = Guid.Parse("b199f9b1-cf03-4990-876e-492df1cf69d1"), name = "Playstation 5", description = "Description Test", CategoryId = Guid.Parse("f1c3a402-5e08-4e13-a08f-4d9ab5062a9e"), price = 500,images = new string[] {"1.jpg", "2.jpg" } },
            new Product { Id = Guid.Parse("f741ceca-8eed-40a6-8706-3181886a2e23"), name = "Android Tablet", description = "Description Test", CategoryId = Guid.Parse("92c17ce6-92b8-4515-9fc3-e38fcc51d83e"), price = 500,images = new string[] {"1.jpg", "2.jpg" } },
            new Product { Id = Guid.Parse("f4411dd9-d96a-4104-9d33-30f7beb3ad05"), name = "Air Fryer", description = "Description Test", CategoryId = Guid.Parse("3ac2239f-3d70-4da0-b81e-bda272847e7c"), price = 500,images = new string[] {"1.jpg", "2.jpg" } }
                );

        modelBuilder.Entity<User>().HasData(
            new User
            { Id = Guid.Parse("c0c343f3-a9d0-4ae6-93e4-0d1923b04e60"), username = "testuser", pass_salt = null, hashedpassword = null, usertype = "user", phonenumber = 123456789, email = "test@gmail.com",profileimage = "profile.jpg"}
        );
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<PurchaseLog> PurchaseLogs { get; set; }
    public DbSet<ParentCategory> ParentCategories { get; set; }
    public DbSet<Category> Categories { get; set; }
}