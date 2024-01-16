namespace MyAPI.ForumApp.Data.Models;

public class SubCategory
{
    public Guid Id { get; set; }
    public string name { get; set; }
    public Guid CategoryId { get; set; }
    public Category category { get; set; }
    public List<Thread> threads { get; set; }
    //public int numofthreads { get; set; }
}