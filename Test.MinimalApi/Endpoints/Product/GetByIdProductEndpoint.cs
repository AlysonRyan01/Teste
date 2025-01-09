using Test.Core.Handlers;
using Test.Core.Requests.Products;
using Test.Core.Responses;

namespace Test.MinimalApi.Endpoints.Product;

public class GetByIdProductEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id}", HandleAsync)
            .WithName("Products: Get by Id")
            .WithSummary("Carrega um produto")
            .WithDescription("Carrega um produto")
            .WithOrder(4)
            .Produces<Response<Core.Models.Product>>();
    }

    private static async Task<IResult> HandleAsync(IProductHandler handler, long id)
    {
        var request = new GetByIdProductRequest
        {
            Id = id,
            UserId = "alyson@gmail.com"
        };
        
        var result = await handler.GetByIdProductAsync(request);

        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}