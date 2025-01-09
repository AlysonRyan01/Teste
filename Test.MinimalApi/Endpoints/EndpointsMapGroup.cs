using Test.MinimalApi.Endpoints.Product;

namespace Test.MinimalApi.Endpoints;

public static class EndpointsMapGroup
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("/v1/Products")
            .WithTags("Products")
            .MapEndpoint<CreateProductEndpoint>()
            .MapEndpoint<UpdateProductEndpoint>()
            .MapEndpoint<DeleteProductEndpoint>()
            .MapEndpoint<GetAllProductsEndpoint>()
            .MapEndpoint<GetByIdProductEndpoint>();

    }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }