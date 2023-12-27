namespace MyAPI.Services.Authentication;

public interface IAuthentication
{
    public Task Login();
    public Task LoginTest();
    public Task Register();
    public Task GetUser();
}