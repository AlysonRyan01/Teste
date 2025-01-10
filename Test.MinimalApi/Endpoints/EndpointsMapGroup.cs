using Test.MinimalApi.Endpoints.Identity;
using Test.MinimalApi.Endpoints.Product;
using Test.MinimalApi.Models;

namespace Test.MinimalApi.Endpoints;

public static class EndpointsMapGroup
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGet("/", () => "Rodando minimal api")
            .WithTags("Run application");

        endpoints.MapGroup("/v1/Products")
            .WithTags("Products")
            .MapEndpoint<CreateProductEndpoint>()
            .MapEndpoint<UpdateProductEndpoint>()
            .MapEndpoint<DeleteProductEndpoint>()
            .MapEndpoint<GetAllProductsEndpoint>()
            .MapEndpoint<GetByIdProductEndpoint>();
        
        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapIdentityApi<ApplicationUser>();
        
        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapEndpoint<LogoutEndpoint>()
            .MapEndpoint<GetRolesEndpoint>();
    }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }