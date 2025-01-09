using Test.Core.Handlers;
using Test.Core.Requests.Products;
using Test.Core.Responses;

namespace Test.MinimalApi.Endpoints.Product;

public class CreateProductEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/", HandleAsync)
            .WithName("Products: Create")
            .WithSummary("Cria uma novo produto")
            .WithDescription("Cria um novo produto")
            .WithOrder(1)
            .Produces<Response<Core.Models.Product>>();
    }

    private static async Task<IResult> HandleAsync(IProductHandler handler, CreateProductRequest request)
    {
        request.UserId = "alyson@gmail.com";
        var result = await handler.PostProductAsync(request);

        return result.IsSuccess ? Results.Created($"/{result.Data?.Id}", result) : Results.BadRequest(result);
    }
}