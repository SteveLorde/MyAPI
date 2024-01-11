using MyAPI.EShoppApp.Data.DTOs;
using MyAPI.EShoppApp.Data.Models;

namespace MyAPI.EShoppApp.Services.Repositories.ProductsRepository;

public interface IProductsRepository
{
    public Task<List<Product>> GetProducts();
    public Task<Product> GetProduct(string productid);
    public Task<List<Product>> GetMostSelling();
    public Task<List<ParentCategory>> GetMainCategories();
    public Task<List<Category>> GetCategories(string maincategoryid);
    public Task CreateAssetsFolders();
    public Task<List<Product>> GetProductsByCategory(string categoryid);
    public Task AddProduct(ProductDTO producttoadd);
    public Task AddQuantity(string productid);
    public Task RemoveQuantity(string productid);
    public Task UpdateProduct(ProductDTO producttoupdate);
    public Task RemoveProduct(ProductDTO producttoremove);

}