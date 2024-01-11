namespace MyAPI.EShoppApp.Data.Models;

public class ParentCategory
{
    public Guid Id { get; set; }
    public string name { get; set; }
    public List<Category> Categories { get; set; }
}