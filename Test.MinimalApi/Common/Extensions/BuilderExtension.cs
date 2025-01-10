using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Test.Core;
using Test.Core.Handlers;
using Test.MinimalApi.Data;
using Test.MinimalApi.Handlers;
using Test.MinimalApi.Models;

namespace Test.MinimalApi.Common.Extensions;

public static class BuilderExtension
{
    public static void AddCofiguration(this WebApplicationBuilder builder)
    {
        Configuration.ConnectionString = builder
            .Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        
        Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
        Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontenddUrl") ?? string.Empty;
    }

    public static void AddSecurity(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
            .AddIdentityCookies();
        builder.Services.AddAuthorization();
    }

    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            x.CustomSchemaIds(n => n.FullName);
        });
    }

    public static void AddDataContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<TestDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole<long>>()
            .AddEntityFrameworkStores<TestDbContext>()
            .AddApiEndpoints();
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IProductHandler, ProductHandler>();
    }
    
    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options => options.AddPolicy(
            ApiConfiguration.CorsPolicyName,
            policy => policy
                .WithOrigins(
                [
                    Configuration.BackendUrl,
                    Configuration.FrontendUrl
                ])
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
        ));
    }
}