using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers;

[ApiController]
[Route("Testing")]
public class TestingController : Controller
{
    [HttpGet]
    public async Task<string> GetTest()
    {
        return "Ok";
    }
}