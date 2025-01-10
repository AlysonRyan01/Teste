using Microsoft.AspNetCore.Identity;
using Test.MinimalApi.Models;

namespace Test.MinimalApi.Endpoints.Identity;

public class LogoutEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapPost("/logout", HandleAsync)
            .RequireAuthorization();
    }

    private static async Task<IResult> HandleAsync(SignInManager<ApplicationUser> signInManager)
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }
}