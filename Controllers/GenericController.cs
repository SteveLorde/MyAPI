using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers;


[ApiController]
public class GenericController<T> : Controller where T : class
{
    
    public GenericController()
    {
        
    }
    
    
    
}