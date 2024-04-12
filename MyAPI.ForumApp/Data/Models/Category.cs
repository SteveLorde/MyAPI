namespace MyAPI.ForumApp.Data.Models;

public class Category
{
    public Guid Id { get; set; }
    public int orderingid { get; set; }
    public string name { get; set; }
    public List<SubCategory> subcategories { get; set; }
}