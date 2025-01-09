using Microsoft.EntityFrameworkCore;
using Test.Core.Handlers;
using Test.MinimalApi.Data;
using Test.MinimalApi.Endpoints;
using Test.MinimalApi.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(n => n.FullName);
});

builder.Services.AddDbContext<TestDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IProductHandler, ProductHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapEndpoints();

app.MapGet("/", () => "Rodando minimal api");

app.Run();
