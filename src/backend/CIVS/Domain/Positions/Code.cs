namespace Domain.Positions;

public readonly struct Code
{
    private readonly int _value;

    public int Value
    {
        get => _value;
        init
        {
            if (value.ToString().Length != 5)
                throw new InvalidDataException("Department codes are 5 digits long!");
            _value = value;
        }
    }
}