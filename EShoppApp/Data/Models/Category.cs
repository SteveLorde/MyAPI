namespace MyAPI.EShoppApp.Data.Models;

public class Category
{
    public Guid Id { get; set; }
    public Guid ParentCategoryId { get; set; }
    public ParentCategory ParentCategory { get; set; }
    public string name { get; set; }
}