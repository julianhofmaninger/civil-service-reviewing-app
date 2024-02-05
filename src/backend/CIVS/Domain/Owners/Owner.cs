using Domain.Common;
using Domain.Positions;

namespace Domain.Owners;

public sealed record Owner
{
    public Owner() { }
    
    public OwnerId Id { get; init; } = OwnerId.New();
    public required string Title { get; set; }
    public Address Address { get; set; }
    
    public IReadOnlyList<Position> Positions { get; init; }
}