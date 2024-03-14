using Microsoft.AspNetCore.Mvc;
using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.Models;
using MyAPI.EShopApp.Services.Repositories.ProductsRepository;

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
    public async Task<List<ProductDTO>> GetAllProducts()
    {
        return await _productsrepo.GetProducts();
    }
    
    [HttpGet("getmaincategories")]
    public async Task<List<MainCategory>> GetMainCategories()
    {
        return await _productsrepo.GetParentCategories();
    }

    [HttpGet("getsubcategory/{subcategoryid}")]
    public async Task<SubCategoryDTO> GetSubCategory(string subcategoryid)
    {
        return await _productsrepo.GetSubCategory(subcategoryid);
    }
    
    [HttpGet("getsubcategories/{patid}")]
    public async Task<List<SubCategory>> GetSubCategories(string patid)
    {
        return await _productsrepo.GetCategories(patid);
    }
    
    [HttpGet("getproduct/{productid}")]
    public async Task<ProductDTO> GetProduct(string productid)
    {
        return await _productsrepo.GetProduct(productid);
    }
    
    [HttpGet("getcategoryproducts/{categoryid}")]
    public async Task<List<ProductDTO>> GetCategoryProducts(string categoryid)
    {
        return await _productsrepo.GetProductsByCategory(categoryid);
    }

    [HttpGet("mostselling")]
    public async Task<List<ProductDTO>> ReturnMostSelling()
    {
        return await _productsrepo.GetMostSelling();
    }

    [HttpPost("addproduct")]
    public async Task<bool> AddProduct(ProductDTO newproductrequest)
    { 
        return await _productsrepo.AddProduct(newproductrequest);
    }
    
}