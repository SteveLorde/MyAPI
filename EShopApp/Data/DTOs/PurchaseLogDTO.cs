﻿using System.ComponentModel.DataAnnotations;
using MyAPI.EShopApp.Data.Models;

namespace MyAPI.EShopApp.Data.DTOs;

public class PurchaseLogDTO
{
    [Key]
    public Guid Id { get; set; }
    public List<Product> Products { get; set; }
    public Guid UserId { get; set; }
    public DateTime datetime { get; set; }
    public decimal extrafees { get; set; }
    public decimal totalorder { get; set; }
}