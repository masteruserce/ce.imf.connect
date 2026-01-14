using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;

namespace ce.imf.connect.comon.Mapper
{
    public static class PostalCodeMapper
    {
        public static PostalCodeDto ToDto(this PostalCode e) => new PostalCodeDto
        {
            Id = e.Id,
            CircleName = e.CircleName,
            RegionName = e.RegionName,
            DivisionName = e.DivisionName,
            OfficeName = e.OfficeName,
            PinCode = e.PinCode,
            OfficeType = e.OfficeType,
            Delivery = e.Delivery,
            District = e.District,
            StateName = e.StateName,
            Latitude = e.Latitude,
            Longitude = e.Longitude
        };

        public static PostalCode ToEntity(this PostalCodeDto d) => new PostalCode
        {
            Id = d.Id,
            CircleName = d.CircleName,
            RegionName = d.RegionName,
            DivisionName = d.DivisionName,
            OfficeName = d.OfficeName,
            PinCode = d.PinCode,
            OfficeType = d.OfficeType,
            Delivery = d.Delivery,
            District = d.District,
            StateName = d.StateName,
            Latitude = d.Latitude,
            Longitude = d.Longitude
        };

        public static void Patch(this PostalCode entity, PostalCodeDto dto)
        {
            entity.CircleName = dto.CircleName;
            entity.RegionName = dto.RegionName;
            entity.DivisionName = dto.DivisionName;
            entity.OfficeName = dto.OfficeName;
            entity.PinCode = dto.PinCode;
            entity.OfficeType = dto.OfficeType;
            entity.Delivery = dto.Delivery;
            entity.District = dto.District;
            entity.StateName = dto.StateName;
            entity.Latitude = dto.Latitude;
            entity.Longitude = dto.Longitude;
        }
    }
}
