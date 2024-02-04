using Domain.Common;

namespace Domain.Users;

public record User
{
    public UserId Id { get; init; }
    public Email Email { get; init; }
    public DateTime EmailConfirmedAt { get; init; }
    public Name Name { get; set; } 
    public Username Username { get; set; }
}