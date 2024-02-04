namespace Domain.Positions;

public readonly struct Code
{
    private readonly int _code;
    public Code(int code)
    {
        if (code.ToString().Length != 5)
            throw new InvalidDataException("Department codes are 5 digits long!");
        _code = code;
    }
}