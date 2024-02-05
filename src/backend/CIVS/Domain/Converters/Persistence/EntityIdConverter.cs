using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StrongIDs;

namespace Domain.Converters.Persistence;

public class EntityIdConverter<T>() : ValueConverter<T, Guid>(x => x.Value,
    x => ParseId(x))
    where T : struct, IEntityId<T>
{
    private static T ParseId(Guid value) => T.Parse(value.ToString());
}