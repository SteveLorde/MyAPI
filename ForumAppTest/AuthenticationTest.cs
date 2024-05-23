using System.Net.Http.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using MyAPI.ForumApp.Data.DTOs.Requests;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace ForumAppTest;

public class AuthenticationTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private HttpClient _httpClient = new();

    public AuthenticationTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async void Login()
    {
        LoginRequestDTO loginreq = new LoginRequestDTO { username = "testuser1", password = "1234" };
        var response = await  _httpClient.PostAsJsonAsync("http://localhost:5010/ForumApp/authentication/login",loginreq).Result.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(response);
    }

    [Fact]
    public async void Register()
    {
        RegisterRequestDTO registerreq = new RegisterRequestDTO {email = "a@gmail.com" ,password = "aaa", username = "aaa"};
        var response = await _httpClient.PostAsJsonAsync("http://localhost:5010/ForumApp/authentication/register",registerreq).Result.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(response);
    }
    
    
}