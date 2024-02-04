using Domain.Common;

namespace Domain.Owners;

public sealed record Owner
{
    private Owner() { }
    
    public OwnerId Id { get; init; } = OwnerId.New();
    public required string Title { get; set; }
    public Address Address { get; set; }
}