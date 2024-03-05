namespace MyAPI.TheDailyBuyerApp.Data.DTO;

public class BoughtResponse
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string StoreName { get; set; }
    public string Price { get; set; }
    public string PictureName { get; set; }
    public string Storelink { get; set; }
    public bool IsVerified { get; set; }
}