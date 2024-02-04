using Domain.Common;

namespace Domain.Positions;

public readonly struct Contact
{
    public Email Email { get; init; }
    public string Name { get; init; }
    public string Phone { get; init; }
    public string Homepage { get; init; }
}