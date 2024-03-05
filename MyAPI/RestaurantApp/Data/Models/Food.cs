namespace MyAPI.RestaurantApp.Data.Models;

public class Food
{
    public int Id { get; set; }
    public string Name {get; set;}
    public string BulletDetails { get; set; }
    public decimal Price { get; set; }
    public List<string> PicturesNames { get; set; }

}