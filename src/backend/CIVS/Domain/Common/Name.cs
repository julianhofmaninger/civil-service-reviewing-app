namespace Domain.Common;

public readonly record struct Name
{
    public Name(string firstname, string lastname)
    {
        Firstname = firstname;
        Lastname = lastname;
    }
    
    public string Firstname { get; init; }
    public string Lastname { get; init; }
    public string Fullname => $"{Firstname} {Lastname}";

    public static Name Empty => new Name(string.Empty, string.Empty);

    public bool HasValue => !string.IsNullOrWhiteSpace(Fullname);
}