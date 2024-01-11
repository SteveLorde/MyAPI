using System.ComponentModel.DataAnnotations;

namespace MyAPI.EShoppApp.Data.Models;

public class Product
{
    [Key]
    public Guid Id { get; set; }
    public string name { get; set; }
    public string? description { get; set; }
    public string? descriptionbullets { get; set; }
    
    public Guid? CategoryId { get; set; }
    public Category Category { get; set; }
    public int? price { get; set; }
    public int? barcode { get; set; }
    public int storequantity { get; set; }
    public DateOnly? addedon { get; set; }
    public Guid? DiscountEventId { get; set; }
    public DiscountEvent? DiscountEvent { get; set; }
    public string[]? images { get; set; }
    public int? sells { get; set; }
    
}