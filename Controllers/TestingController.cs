using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers;

[ApiController]
[Route("Testing")]
public class TestingController : Controller
{
    [HttpGet]
    async Task<string> GetTest()
    {
        return "Ok";
    }
}