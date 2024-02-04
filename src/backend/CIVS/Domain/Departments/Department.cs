namespace Domain.Departments;

public sealed record Department
{
    public DepartmentId Id { get; init; } = DepartmentId.New();
    public required string Code { get; init; }
    public required string Title { get; init; }

    public Department(string code, string title) : base()
    {
        Code = code;
        Title = title;
    }
    
    private Department() { }

    public static Department None => 
        new Department
        {
            Code = string.Empty,
            Title = string.Empty
        };

    public bool HasValue => !string.IsNullOrWhiteSpace(Code) && 
                            !string.IsNullOrWhiteSpace(Title);
}