namespace MyAPI.EShopApp.Data.Models;

public class SubCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid MainCategoryId { get; set; }
    public MainCategory MainCategory { get; set; }

}