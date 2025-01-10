using Test.MinimalApi.Endpoints;

namespace Test.MinimalApi.Common.Extensions;

public static class AppExtension
{
    public static void AddDocumentation(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    public static void AddMapEndpoints(this WebApplication app)
    {
        app.MapEndpoints();
    }
}