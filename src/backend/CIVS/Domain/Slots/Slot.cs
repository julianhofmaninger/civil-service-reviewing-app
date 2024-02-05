using Domain.Positions;

namespace Domain.Slots;

public sealed record Slot
{
    private Slot() { }
    
    public SlotId Id { get; init; } = SlotId.New();
    public DateOnly Date { get; init; }
    public int Capacity { get; init; }
    public int Available { get; init; }
    public int Used { get; init; }
    public Position Position { get; init; }
}