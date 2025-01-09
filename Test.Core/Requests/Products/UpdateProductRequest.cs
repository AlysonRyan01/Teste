using System.ComponentModel.DataAnnotations;
using Test.Core.Enums;

namespace Test.Core.Requests.Products;

public class UpdateProductRequest : BaseRequest
{
    public long Id { get; set; }
    
    [Required(ErrorMessage = "Product title is required")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Product price is required")]
    public Decimal Price { get; set; }
    
    [Required(ErrorMessage = "Type is required")]
    public ProductType Type { get; set; }
}