using System.ComponentModel.DataAnnotations;

namespace Test.Core.Requests.Products;

public class DeleteProductRequest : BaseRequest
{
    [Required(ErrorMessage = "Product Id is required" )]
    public long Id { get; set; }
}