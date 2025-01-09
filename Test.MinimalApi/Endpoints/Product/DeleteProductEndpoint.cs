using Test.Core.Handlers;
using Test.Core.Requests.Products;
using Test.Core.Responses;

namespace Test.MinimalApi.Endpoints.Product;

public class DeleteProductEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapDelete("/{id}", HandleAsync)
            .WithName("Products: Delete")
            .WithSummary("remove um produto")
            .WithDescription("remove um produto")
            .WithOrder(2)
            .Produces<Response<Core.Models.Product>>();
    }

    private static async Task<IResult> HandleAsync(IProductHandler handler, long id)
    {
        var request = new DeleteProductRequest
        {
            Id = id,
            UserId = "alyson@gmail.com"
        };
        
        var result = await handler.DeleteProductAsync(request);

        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}