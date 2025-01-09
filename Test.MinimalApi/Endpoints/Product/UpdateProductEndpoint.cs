using Test.Core.Handlers;
using Test.Core.Requests.Products;
using Test.Core.Responses;

namespace Test.MinimalApi.Endpoints.Product;

public class UpdateProductEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}", HandleAsync)
            .WithName("Products: Update")
            .WithSummary("atualiza um produto")
            .WithDescription("atualiza um produto")
            .WithOrder(3)
            .Produces<Response<Core.Models.Product>>();
    }

    private static async Task<IResult> HandleAsync(IProductHandler handler, UpdateProductRequest request, long id)
    {
        request.Id = id;
        request.UserId = "alyson@gmail.com";
        
        var result = await handler.UpdateProductAsync(request);

        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}