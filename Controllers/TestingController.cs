using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers;

[ApiController]
[Route("Testing")]
public class TestingController : Controller
{
    [HttpGet("GetTest")]
    public async Task<string> GetTest()
    {
        return "Ok";
    }
}