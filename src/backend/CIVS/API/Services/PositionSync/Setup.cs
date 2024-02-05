namespace API.Services.PositionSync;

public static class Setup
{
    public static IServiceCollection AddPositionSyncService(
        this IServiceCollection services)
    {
        services.AddScoped<PositionSyncService>();
        return services;
    }
}