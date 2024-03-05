namespace MyAPI.RestaurantApp.Services.FoodRepo;

public interface IFoodRepo
{
    public Task GetAllFoods();
    public Task GetFoodDetails();
    public Task AddFood();
    public Task UpdateFood();
    public Task RemoveFood();
}