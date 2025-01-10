using Test.MinimalApi.Common.Extensions;


var builder = WebApplication.CreateBuilder(args);
builder.AddSecurity();
builder.AddCofiguration();
builder.AddDataContext();
builder.AddServices();
builder.AddCrossOrigin();
builder.AddDocumentation();

var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.AddDocumentation();

app.AddMapEndpoints();

app.Run();
