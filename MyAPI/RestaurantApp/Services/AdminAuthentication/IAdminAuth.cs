namespace MyAPI.RestaurantApp.Services.AdminAuthentication;

public interface IAdminAuth
{
    public Task AdminLogin();
    public Task AdminRegister();
}