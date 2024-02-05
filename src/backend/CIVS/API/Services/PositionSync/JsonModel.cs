namespace API.Services.PositionSync;

public class Address
{
    public string address { get; set; }
    public string zipCode { get; set; }
    public string city { get; set; }
    public string areaCode { get; set; }
    public string region { get; set; }
    public string districtCode { get; set; }
}

public class Agency
{
    public string name { get; set; }
    public Address address { get; set; }
}

public class Content
{
    public object id { get; set; }
    public DateTime lastSyncedAt { get; set; }
    public DateTime modifiedAt { get; set; }
    public int code { get; set; }
    public string title { get; set; }
    public Address address { get; set; }
    public Owner owner { get; set; }
    public string branch { get; set; }
    public string branchCode { get; set; }
    public string activity { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string homepage { get; set; }
    public string info { get; set; }
    public List<Agency> agencies { get; set; }
    public List<Slot> slots { get; set; }
}

public class Owner
{
    public string title { get; set; }
    public Address address { get; set; }
}

public class Root
{
    public List<Content> content { get; set; }
    public int totalCount { get; set; }
    public DateTime lastUpdated { get; set; }
}

public class Slot
{
    public string date { get; set; }
    public int capacity { get; set; }
    public int used { get; set; }
    public int available { get; set; }
}