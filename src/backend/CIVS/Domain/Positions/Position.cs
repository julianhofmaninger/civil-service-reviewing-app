using Domain.Agencies;
using Domain.Common;
using Domain.Departments;
using Domain.Owners;
using Domain.Slots;

namespace Domain.Positions;

public sealed record Position
{
    public Position() { }
    
    public PositionId Id = PositionId.New();
    public DateTime LastSyncedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public Code Code { get; init; }
    public Department Department { get; init; } = Department.None;
    public string? Activity { get; set; }
    public required string Title { get; init; } 
    public Contact Contact { get; init; }
    public IReadOnlyList<Slot> Slots { get; init; } = [];
    public IReadOnlyList<Agency> Agencies { get; init; } = [];
    public Address Address { get; init; }
    public Owner Owner { get; init; }
}