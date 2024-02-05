using API.Extensions.DependencyInjection;
using API.Services.PositionSync;
using Domain.Common;
using Domain.Users;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services
    .AddAuthentication();

builder.Services
    .AddAuthorization()
    .AddJwtAuthentication(configuration)
    .AddInfrastructure(configuration)
    .AddHttpClient()
    .AddPositionSyncService();

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

app.MapPost("positions/sync", async (
    PositionSyncService syncService) =>
{
    await syncService.SyncDatabase();
});

app.Run();