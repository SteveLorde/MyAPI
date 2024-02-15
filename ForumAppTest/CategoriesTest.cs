using System.Net.Http.Json;
using System.Text;
using MyAPI.ForumApp.Data.DTOs.Responses;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace ForumAppTest;

public class CategoriesTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private HttpClient _httpClient = new();

    public CategoriesTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async void GetCategories()
    {
        var response = await  _httpClient.GetAsync("http://localhost:5010/ForumApp/categories/getcategories").Result.Content.ReadFromJsonAsync<List<CategoryResponseDTO>>();
        _testOutputHelper.WriteLine(response.ToString());
    }

}