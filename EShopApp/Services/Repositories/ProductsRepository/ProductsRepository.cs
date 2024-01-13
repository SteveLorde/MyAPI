using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAPI.EShopApp.Data;
using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.Models;

namespace MyAPI.EShopApp.Services.Repositories.ProductsRepository;

class ProductsRepository : IProductsRepository
{
    private readonly EShopDataContext _db;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _hostingenv;

    public ProductsRepository(EShopDataContext db, IMapper mapper, IWebHostEnvironment hostingEnvironment)
    {
        _db = db;
        _mapper = mapper;
        _hostingenv = hostingEnvironment;
    }
    
    public async Task<List<Product>> GetProducts()
    {
        return await _db.Products.ToListAsync();
    }

    public async Task<Product> GetProduct(string productid)
    {
        var productguid = Guid.Parse(productid);
        return await _db.Products.FirstAsync(product => product.Id == productguid);
    }

    public async Task<List<ParentCategory>> GetParentCategories()
    {
        return await _db.ParentCategories.Include(parentcat => parentcat.Categories).ToListAsync();
    }

    public async Task<List<Category>> GetCategories(string maincategoryid)
    {
        return await _db.ParentCategories.Where(x => x.Id == Guid.Parse(maincategoryid) ).SelectMany(z => z.Categories).Include(a => a.ParentCategory).ToListAsync();
    }

    public async Task<List<Product>> GetProductsByCategory(string categoryid)
    {
        return await _db.Products.Where(x => x.Category.ParentCategoryId == Guid.Parse(categoryid) || x.CategoryId == Guid.Parse(categoryid) ).ToListAsync();
    }
    
    public async Task<List<Product>> GetMostSelling()
    {
        return await _db.Products.OrderByDescending(x => x.sells).Take(15).ToListAsync();
    }

    public async Task CreateAssetsFolders()
    {
        try
        {
            var productsfoldertocheck = Path.Combine(_hostingenv.ContentRootPath, "Storage", "EShopApp", "Products");
            bool checkdirectory = Directory.Exists(productsfoldertocheck);
            if (checkdirectory)
            {
                List<Product> allproducts = await _db.Products.ToListAsync();
                foreach (Product product in allproducts)
                {
                    var productfoldertocreate = Path.Combine(_hostingenv.ContentRootPath, "Storage", "EShopApp" ,"Products",
                        $"{product.Id}", "Images");
                    Directory.CreateDirectory(productfoldertocreate); 
                }
                Console.WriteLine("EShop: Created Products assets folders successfully");
            }
            else
            {
                return;
            }
        }
        catch (Exception err)
        {
            throw err;
        }
    }
    
    public async Task AddProduct(ProductDTO producttoadd)
    {
        Product newproduct = new Product { Id = Guid.NewGuid(),name = producttoadd.name , description = producttoadd.description, descriptionbullets = producttoadd.descriptionbullets, CategoryId = producttoadd.SubCategoryId, price = producttoadd.price, addedon = new DateOnly(2024,1,1), DiscountEvent = null };
        await _db.Products.AddAsync(newproduct);
        var productfoldertocreate = Path.Combine(_hostingenv.ContentRootPath, "Storage", "EShopApp", "Products", $"{newproduct.Id}", "Images");
        Directory.CreateDirectory(productfoldertocreate);
        foreach (var imagefile in producttoadd.imagefiles)
        {
            Directory.CreateDirectory(productfoldertocreate); 
        }
        await _db.SaveChangesAsync();
    }

    public async Task<bool> CheckProduct(string productid)
    {
        Product product = await _db.Products.FirstAsync(p => p.Id == Guid.Parse(productid));
        if (product.storequantity > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public async Task UpdateProduct(ProductDTO producttoupdate)
    {
        Product selectedproduct = await _db.Products.FirstAsync(x => x.Id == producttoupdate.id);
        _mapper.Map(producttoupdate, selectedproduct);
        await _db.SaveChangesAsync();
    }

    public async Task RemoveProduct(ProductDTO producttoremove)
    {
        Product removeproduct = await _db.Products.FirstAsync(x => x.Id == producttoremove.id);
        _db.Products.Remove(removeproduct);
        await _db.SaveChangesAsync();
    }
}   