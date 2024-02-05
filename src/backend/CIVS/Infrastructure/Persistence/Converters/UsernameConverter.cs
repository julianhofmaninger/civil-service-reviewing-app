using Domain.Users;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Converters;

public class UsernameConverter : ValueConverter<Username, string>
{
    public UsernameConverter() : base(
        v => v.ToString(),
        v => new Username(v))
    {
        
    }
}