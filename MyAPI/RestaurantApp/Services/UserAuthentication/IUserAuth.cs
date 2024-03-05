namespace MyAPI.RestaurantApp.Services.UserAuthentication;

public interface IUserAuth
{
    public Task LoginUser();
    public Task RegisterUser();
}