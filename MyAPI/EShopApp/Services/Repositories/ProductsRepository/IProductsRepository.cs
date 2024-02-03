using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.Models;

namespace MyAPI.EShopApp.Services.Repositories.ProductsRepository;

public interface IProductsRepository
{
    public Task<List<ProductDTO>> GetProducts();
    public Task<ProductDTO> GetProduct(string productid);
    public Task<List<ProductDTO>> GetMostSelling();
    public Task<List<ParentCategory>> GetParentCategories();
    public Task<List<Category>> GetCategories(string maincategoryid);
    public Task CreateAssetsFolders();
    public Task<List<ProductDTO>> GetProductsByCategory(string categoryid);
    public Task AddProduct(ProductDTO producttoadd);
    public Task<bool> CheckProduct(string productid);
    public Task UpdateProduct(ProductDTO producttoupdate);
    public Task RemoveProduct(string productid);

}