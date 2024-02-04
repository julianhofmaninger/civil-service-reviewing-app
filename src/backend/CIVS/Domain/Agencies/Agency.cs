using Domain.Common;

namespace Domain.Agencies;

public sealed record Agency
{
    private Agency() { }
    
    public AgencyId Id { get; init; } = AgencyId.New();
    public required string Name { get; init; }
    public Address Address { get; init; }
}