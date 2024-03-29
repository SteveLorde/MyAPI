﻿using System.ComponentModel.DataAnnotations.Schema;
using MyAPI.EShopApp.Data.JointModels;

namespace MyAPI.EShopApp.Data.Models;

public class DiscountEvent
{
    public Guid Id { get; set; }
    public string title { get; set; }
    public string subtitle { get; set; }
    public string description { get; set; }
    public DateOnly startdate { get; set; }
    public DateOnly enddate { get; set; }
    public string? image { get; set; }
    public decimal discountamount { get; set; }
    public bool ispercentage { get; set; }
    public List<Product> Products { get; set; }

}