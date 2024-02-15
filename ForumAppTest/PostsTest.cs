using System.Net.Http.Json;
using System.Text;
using MyAPI.ForumApp.Data.DTOs.Requests;
using MyAPI.ForumApp.Data.DTOs.Responses;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace ForumAppTest;

public class PostsTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private HttpClient _httpClient = new();

    public PostsTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    public async void AddPost()
    {
        var postbody = " {\"ops\":[{\"insert\":\"xxxxxxx\"},{\"attributes\":{\"bold\":true},\"insert\":\"XXXX\"},{\"insert\":\"\\n\"}]} ";
        AddPostRequestDTO newpost = new AddPostRequestDTO { ThreadId = Guid.Parse("25FC63F8-9B86-48C2-A75D-40C4F357C1E7"), UserId = Guid.Parse("CB89BDB8-348A-4AF4-B837-8CAA71BD7FB0"), Body = postbody };
        var response = await  _httpClient.PostAsJsonAsync("http://localhost:5010/ForumApp/AddPost", newpost).Result.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine("response: " + response);
    }
    
    [Fact]
    public async void GetThread()
    {
        string threadid = "25FC63F8-9B86-48C2-A75D-40C4F357C1E7";
        string url = $"http://localhost:5010/ForumApp/threads/getthread/{threadid}";
        var response = await _httpClient.GetAsync(url).Result.Content.ReadFromJsonAsync<ThreadResponseDTO>();
        foreach (var post in response.posts)
        {
            _testOutputHelper.WriteLine("" + post.UserId + " "  + " " + post.body);
        }
    }
    
    
}