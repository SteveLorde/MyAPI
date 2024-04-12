using Microsoft.EntityFrameworkCore;

namespace MyAPI.EShopApp.Data.Seeding;

public class EShopCustomSeeding
{
    private EShopDataContext _db;
    
    public EShopCustomSeeding(EShopDataContext db)
    {
        _db = db;
    }

    public async void SeedDiscountsProducts()
    {
        var Event = await _db.DiscountEvents.Include(discountEvent => discountEvent.Products).FirstAsync(e => e.Id == Guid.Parse("0d8b8ff5-db08-4ee0-ae55-dd0267116b5d"));
        if (Event.Products.Count == 0)
        {
            var product1 = await _db.Products.FirstAsync(p => p.Id == Guid.Parse("4eaf8297-449c-4aea-a656-a92b8730a201"));
            var product2 = await _db.Products.FirstAsync(p => p.Id == Guid.Parse("b199f9b1-cf03-4990-876e-492df1cf69d1"));
            Event.Products.AddRange([product1,product2]);
            await _db.SaveChangesAsync();
        }
    }
    

}