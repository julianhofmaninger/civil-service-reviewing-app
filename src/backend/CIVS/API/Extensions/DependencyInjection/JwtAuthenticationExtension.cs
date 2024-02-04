using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions.DependencyInjection;

public static class JwtAuthenticationExtension
{
    private const string Supabase = "Supabase";

    public static IServiceCollection AddJwtAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var settings = configuration
            .GetSection(Supabase)
            .Get<Settings>();
        
        services.AddAuthentication(o =>
        {
            o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.IncludeErrorDetails = true;
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(settings!.JwtSecret!)),
                ValidateIssuer = false,
                ValidateAudience = true,
                ValidAudience = "authenticated"
            };
        });
        return services;
    }
    
    private record Settings
    {
        [JsonConstructor]
        public Settings(string jwtSecret)
        {
            ArgumentException.ThrowIfNullOrEmpty(jwtSecret);
            JwtSecret = jwtSecret;
        }
        public string JwtSecret { get; init; }
    };
}