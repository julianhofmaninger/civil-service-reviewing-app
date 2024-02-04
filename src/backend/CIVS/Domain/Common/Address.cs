namespace Domain.Common;

public readonly struct Address
{
    public string AddressName { get; init; }
    public string ZipCode { get; init; }
    public string City { get; init; }
    public string AreaCode { get; init; }
    public string Region { get; init; }
    public string DistrictCode { get; init; }
}