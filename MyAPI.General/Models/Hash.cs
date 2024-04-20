namespace MyAPI.Packages.Models;

public record Hash
{
    public string Salt { get; set; }
    public string HashedPassword { get; set; }
};