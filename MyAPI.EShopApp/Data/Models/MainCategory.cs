namespace MyAPI.EShopApp.Data.Models;

public class MainCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<SubCategory> SubCategories { get; set; }
}