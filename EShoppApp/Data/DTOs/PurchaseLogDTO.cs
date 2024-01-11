using System.ComponentModel.DataAnnotations;
using MyAPI.EShoppApp.Data.Models;

namespace MyAPI.EShoppApp.Data.DTOs;

public class PurchaseLogDTO
{
    [Key]
    public Guid Id { get; set; }
    public List<Product> Products { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public DateTime datetime { get; set; }
    public decimal extrafees { get; set; }
    public decimal totalorder { get; set; }
}