using Test.Core.Enums;

namespace Test.Core.Models;

public class Product
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public Decimal Price { get; set; }
    public ProductType Type { get; set; }
    public string? UserId { get; set; }
}