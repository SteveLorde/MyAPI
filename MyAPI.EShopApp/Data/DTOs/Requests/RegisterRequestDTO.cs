﻿using Microsoft.AspNetCore.Http;

namespace MyAPI.EShopApp.Data.DTOs.Requests;

public class RegisterRequestDTO
{
    public string username { get; set; }
    public string password { get; set; }
    public IFormFile? profileimagefile { get; set; }
}