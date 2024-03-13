using System.ComponentModel.DataAnnotations;

namespace MyAPI.EShopApp.Data.Models;
public class User
{
    public Guid Id { get; set; }
    public string username { get; set; }
    public string pass_salt { get; set; }
    public string hashedpassword { get; set; }
    public string usertype { get; set; }
    public int phonenumber { get; set; }
    public string email { get; set; }
    public string profileimage { get; set; }
    public List<PurchaseLog> PurchaseLogs { get; set; }

}