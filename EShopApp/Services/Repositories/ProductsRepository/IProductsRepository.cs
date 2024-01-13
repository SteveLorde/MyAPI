using MyAPI.EShopApp.Data.DTOs;
using MyAPI.EShopApp.Data.Models;

namespace MyAPI.EShopApp.Services.Repositories.ProductsRepository;

public interface IProductsRepository
{
    public Task<List<Product>> GetProducts();
    public Task<Product> GetProduct(string productid);
    public Task<List<Product>> GetMostSelling();
    public Task<List<ParentCategory>> GetParentCategories();
    public Task<List<Category>> GetCategories(string maincategoryid);
    public Task CreateAssetsFolders();
    public Task<List<Product>> GetProductsByCategory(string categoryid);
    public Task AddProduct(ProductDTO producttoadd);
    public Task<bool> CheckProduct(string productid);
    public Task UpdateProduct(ProductDTO producttoupdate);
    public Task RemoveProduct(ProductDTO producttoremove);

}