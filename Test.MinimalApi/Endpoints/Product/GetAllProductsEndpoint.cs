using Test.Core.Handlers;
using Test.Core.Requests.Products;
using Test.Core.Responses;

namespace Test.MinimalApi.Endpoints.Product;

public class GetAllProductsEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/", HandleAsync)
            .WithName("Products: Get all")
            .WithSummary("Carrega todos os produtos")
            .WithDescription("Carrega todos os produtos")
            .WithOrder(5)
            .Produces<Response<Core.Models.Product>>();
    }

    private static async Task<IResult> HandleAsync(IProductHandler handler)
    {
        var request = new GetAllProductsRequest
        {
            UserId = "alyson@gmail.com"
        };
        
        var result = await handler.GetAllProductsAsync(request);

        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}