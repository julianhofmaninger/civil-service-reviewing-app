using System.Security.Claims;

namespace API.Extensions;

public static class HttpContextExtensions
{
    public static Guid GetUserId(this HttpContext httpContext)
    {
        var value = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.TryParse(value, out var userId) ? userId : Guid.Empty; 
    }

    public static string GetEmail(this HttpContext httpContext)
    {
        var value = httpContext.User.FindFirstValue(ClaimTypes.Email);
        return value ?? string.Empty;
    }
}