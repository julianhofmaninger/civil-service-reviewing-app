using API.Extensions.DependencyInjection;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services
    .AddAuthentication();

builder.Services
    .AddAuthorization()
    .AddJwtAuthentication(configuration)
    .AddInfrastructure(configuration);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app
        .UseSwagger()
        .UseSwaggerUI();
}
app
    .UseHttpsRedirection()
    .UseAuthentication()
    .UseAuthorization();
app.Run();