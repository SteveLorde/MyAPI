using System.ComponentModel.DataAnnotations;

namespace MyAPI.EShopApp.Data.Models;
public class User
{
    public Guid Id { get; set; }
    public string Address { get; set; }
    public string UserName { get; set; }
    public string PassSalt { get; set; }
    public string HashedPassword { get; set; }
    public string UserType { get; set; }
    public int PhoneNumber { get; set; }
    public string Email { get; set; }
    public string ProfileImage { get; set; }
    public List<PurchaseLog> PurchaseLogs { get; set; }

}