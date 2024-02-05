using System.Linq.Expressions;
using Domain.Common;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Converters;

public class EmailConverter : ValueConverter<Email, string>
{
    public EmailConverter() : base(
        v => v.ToString(),
        v => new Email(v))
    {
        
    }
}