using Microsoft.AspNetCore.Mvc;
using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.DTOs.Responses;
using MyAPI.EShopApp.Data.Models;
using MyAPI.EShopApp.Services.Repositories.ProductsRepository;

namespace MyAPI.EShopApp.Controllers;

[ApiController]
[Route("eshop/warehouse")]
public class WarehouseController : Controller
{
    private readonly IProductsRepository _productsrepo;
    
    public WarehouseController(IProductsRepository productsrepo)
    {
        _productsrepo = productsrepo;
    }

    [HttpGet("getallproducts/{pageNumber}")]
    public async Task<PaginatedProductsResponseDTO> GetAllProducts(int pageNumber)
    {
        PaginatedProductsResponseDTO paginatedProducts = new PaginatedProductsResponseDTO();
        List<ProductDTO> products = await _productsrepo.GetProducts();
        if (pageNumber == 0)
        {
            paginatedProducts.Products = products;
            paginatedProducts.TotalPages = 0;
            return paginatedProducts;
        }
        else
        {
            var pagedProducts = products.Skip( (pageNumber - 1) * 20).Take(20).ToList();
            decimal totalPagesDecimal = (decimal)products.Count / (decimal)20;
            int totalPages = 0;
            if (totalPagesDecimal % 1 == 0)
            {
                totalPages = (int)totalPagesDecimal;
            }
            else
            {
                totalPages = (int)totalPagesDecimal + 1;
            }
            paginatedProducts.Products = pagedProducts;
            paginatedProducts.TotalPages = totalPages;
            return paginatedProducts;
        }
    }

    [HttpGet("searchproduct/{productName}/{pageNumber}")]
    public async Task<PaginatedProductsResponseDTO> SearchProduct(string productName, int pageNumber)
    {
        List<ProductDTO> searchedProducts = await _productsrepo.SearchProduct(productName);
        var pagedProducts = searchedProducts.Skip( (pageNumber - 1) * 20).Take(20).ToList();
        decimal totalPagesDecimal = (decimal)searchedProducts.Count / (decimal)20;
        int totalPages = 0;
        if (totalPagesDecimal % 1 == 0)
        {
            totalPages = (int)totalPagesDecimal;
        }
        else
        {
            totalPages = (int)totalPagesDecimal + 1;
        }
        PaginatedProductsResponseDTO paginatedProducts = new PaginatedProductsResponseDTO() {Products = pagedProducts, TotalPages = totalPages};
        return paginatedProducts;
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
    
    [HttpGet("getcategoryproducts/{categoryid}/{pageNumber}")]
    public async Task<PaginatedProductsResponseDTO> GetCategoryProducts(string categoryid,int pageNumber)
    {
        List<ProductDTO> categoryProducts = await _productsrepo.GetProductsByCategory(categoryid);
        var pagedProducts = categoryProducts.Skip( (pageNumber - 1) * 20).Take(20).ToList();
        decimal totalPagesDecimal = (decimal)categoryProducts.Count / (decimal)20;
        int totalPages = 0;
        if (totalPagesDecimal % 1 == 0)
        {
            totalPages = (int)totalPagesDecimal;
        }
        else
        {
            totalPages = (int)totalPagesDecimal + 1;
        }
        PaginatedProductsResponseDTO paginatedProducts = new PaginatedProductsResponseDTO() {Products = pagedProducts, TotalPages = totalPages};
        return paginatedProducts;
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