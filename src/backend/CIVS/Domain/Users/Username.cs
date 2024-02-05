namespace Domain.Users;

public readonly record struct Username
{
    private readonly string _value;
    public Username(string username)
    {
        ArgumentException.ThrowIfNullOrEmpty(username);
        _value = username;
    }

    public override string ToString() => _value;
}