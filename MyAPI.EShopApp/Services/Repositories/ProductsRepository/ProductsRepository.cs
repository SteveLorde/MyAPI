using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Hosting;
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
    
    public async Task<List<ProductDTO>> GetProducts()
    {
        List<ProductDTO> allproductsresponse = new List<ProductDTO>();
        var queriedproducts = await _db.Products.ToListAsync();
        foreach (var product in queriedproducts)
        {
            ProductDTO productdto = _mapper.Map<ProductDTO>(product);
            allproductsresponse.Add(productdto);
        }
        return allproductsresponse;
    }

    public async Task<ProductDTO> GetProduct(string productid)
    {
        var queriedproduct = await _db.Products.Include(p => p.DiscountEvents).Include(p => p.SubCategory).ThenInclude(subcat => subcat.MainCategory).ProjectTo<ProductDTO>(_mapper.ConfigurationProvider).FirstAsync(product => product.Id == Guid.Parse(productid));
        return queriedproduct;
    }

    public async Task<List<MainCategory>> GetParentCategories()
    {
        return await _db.ParentCategories.Include(parentcat => parentcat.SubCategories).ToListAsync();
    }

    public async Task<SubCategoryDTO> GetSubCategory(string subcategoryid)
    {
        return await _db.Categories.Include(subcat => subcat.Products).ProjectTo<SubCategoryDTO>(_mapper.ConfigurationProvider).FirstAsync(subcat => subcat.Id == Guid.Parse(subcategoryid));
    }


    public async Task<List<SubCategory>> GetCategories(string maincategoryid)
    {
        return await _db.ParentCategories.Where(x => x.Id == Guid.Parse(maincategoryid) ).SelectMany(z => z.SubCategories).Include(a => a.MainCategory).ToListAsync();
    }

    public async Task<List<ProductDTO>> GetProductsByCategory(string categoryid)
    {
        var queriedproducts = await _db.Products.Where(product => product.SubCategory.MainCategoryId == Guid.Parse(categoryid) || product.SubCategoryId == Guid.Parse(categoryid) ).ProjectTo<ProductDTO>(_mapper.ConfigurationProvider).ToListAsync();
        return queriedproducts;
    }
    
    public async Task<List<ProductDTO>> GetMostSelling()
    {
        return await _db.Products.OrderByDescending(x => x.Sells).Take(15).ProjectTo<ProductDTO>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task CreateAssetsFolders()
    {
        var productsfoldertocheck = Path.Combine(_hostingenv.ContentRootPath, "Storage", "EShopApp", "Products");
        bool checkdirectory = Directory.Exists(productsfoldertocheck);
        if (!checkdirectory)
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
        else { 
                return;
        }
    }
    
    public async Task<bool> AddProduct(ProductDTO producttoadd)
    {
        Product newproduct = new Product { Id = Guid.NewGuid(),Name = producttoadd.Name , Description = producttoadd.Description, SubCategoryId = producttoadd.SubCategoryId, Price = producttoadd.Price, AddedOn = new DateOnly(2024,1,1)};
        await _db.Products.AddAsync(newproduct);
        var productfoldertocreate = Path.Combine(_hostingenv.ContentRootPath, "Storage", "EShopApp", "Products", $"{newproduct.Id}", "Images");
        Directory.CreateDirectory(productfoldertocreate);
        foreach (var imagefile in producttoadd.Imagefiles)
        {
            Directory.CreateDirectory(productfoldertocreate); 
        }
        await _db.SaveChangesAsync();
        var checkIfAdded = await _db.Products.AnyAsync(product => product.Id == newproduct.Id);
        if (checkIfAdded)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> CheckProduct(string productid)
    {
        Product product = await _db.Products.FirstAsync(p => p.Id == Guid.Parse(productid));
        if (product.Quantity > 0)
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
        Product selectedproduct = await _db.Products.FirstAsync(x => x.Id == producttoupdate.Id);
        _mapper.Map(producttoupdate, selectedproduct);
        await _db.SaveChangesAsync();
    }

    public async Task RemoveProduct(string productid)
    {
        Product removeproduct = await _db.Products.FirstAsync(x => x.Id == Guid.Parse(productid));
        _db.Products.Remove(removeproduct);
        await _db.SaveChangesAsync();
    }
}   