using Domain.Common;
using Domain.Positions;

namespace Domain.Agencies;

public sealed record Agency
{
    public Agency() { }
    
    public AgencyId Id { get; init; } = AgencyId.New();
    public required string Name { get; init; }
    public Address Address { get; init; }
    
    public IReadOnlyList<Position> Positions { get; init; }
}