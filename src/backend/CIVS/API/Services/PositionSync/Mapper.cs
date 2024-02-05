using Domain.Common;
using Domain.Positions;

namespace API.Services.PositionSync;

internal static class Mapper
{
    public static Position FromContent(this Content content) 
        => new Position 
        {
            Id = PositionId.New(),
            Title = content.title,
            LastSyncedAt = content.lastSyncedAt,
            ModifiedAt = content.modifiedAt,
            Code = new Code{ Value = content.code },
            Address = new Domain.Common.Address
            {
                AddressName = content.address.address,
                AreaCode = content.address.areaCode,
                City = content.address.city,
                DistrictCode = content.address.districtCode,
                ZipCode = content.address.zipCode,
                Region = content.address.region
            },
            Activity = content.activity,
            Agencies = content.agencies
                .Select(x => new Domain.Agencies.Agency
                {
                    Name = x.name,
                    Address = new Domain.Common.Address
                    {
                        AddressName = x.address.address,
                        AreaCode = x.address.areaCode,
                        City = x.address.city,
                        DistrictCode = x.address.districtCode,
                        ZipCode = x.address.zipCode,
                        Region = x.address.region
                    }
                })
                .ToList(),
            Owner = new Domain.Owners.Owner
            {
                Title = content.owner.title,
                Address = new Domain.Common.Address
                {
                    AddressName = content.owner.address.address,
                    AreaCode = content.owner.address.areaCode,
                    City = content.owner.address.city,
                    DistrictCode = content.owner.address.districtCode,
                    ZipCode = content.owner.address.zipCode,
                    Region = content.owner.address.region
                }
            },
            Slots = content.slots
                .Select(x => new Domain.Slots.Slot
                {
                    Available = x.available,
                    Capacity = x.capacity,
                    Date = DateOnly.Parse(x.date)
                })
                .ToList(),
            Contact = new Contact
            {
                Email = 
                    Email.IsValidEmail(content.email) ? 
                        new Email 
                        {
                            Value = content.email
                        } : 
                        Email.None,
                Name = content.name,
                Phone = content.phone,
                Homepage = content.homepage
            }
        };
    
}