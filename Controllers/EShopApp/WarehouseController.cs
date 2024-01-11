using Microsoft.AspNetCore.Mvc;
using MyAPI.EShoppApp.Data.DTOs;
using MyAPI.EShoppApp.Data.Models;
using MyAPI.EShoppApp.Services.Repositories.ProductsRepository;

namespace MyAPI.Controllers.EShopApp;

[ApiController]
[Route("eshop/warehouse")]
public class WarehouseController : Controller
{
    private readonly IProductsRepository _productsrepo;
    
    public WarehouseController(IProductsRepository productsrepo)
    {
        _productsrepo = productsrepo;
    }

    [HttpGet("getallproducts")]
    public async Task<List<Product>> GetAllProducts()
    {
        return await _productsrepo.GetProducts();
    }
    
    [HttpGet("getmaincategories")]
    public async Task<List<ParentCategory>> GetParentCategories()
    {
        return await _productsrepo.GetParentCategories();
    }
    
    [HttpGet("getsubcategories/{patid}")]
    public async Task<List<Category>> GetCategories(string patid)
    {
        return await _productsrepo.GetCategories(patid);
    }
    
    [HttpGet("getproduct/{productid}")]
    public async Task<Product> GetProduct(string productid)
    {
        return await _productsrepo.GetProduct(productid);
    }
    
    [HttpGet("getcategoryproducts/{categoryid}")]
    public async Task<List<Product>> GetCategoryProducts(string categoryid)
    {
        return await _productsrepo.GetProductsByCategory(categoryid);
    }

    [HttpGet("mostselling")]
    public async Task<List<Product>> ReturnMostSelling()
    {
        return await _productsrepo.GetMostSelling();
    }

    [HttpPost("addproduct")]
    public async Task AddProduct(ProductDTO newproductrequest)
    { 
        await _productsrepo.AddProduct(newproductrequest);
    }
    
}