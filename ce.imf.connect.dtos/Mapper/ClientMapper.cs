using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;

namespace ce.imf.connect.common.Mapper
{
    public static class ClientMapper
    {
        public static ClientDto ToDto(this Clients entity)
        {
            return new ClientDto
            {
                ClientId = entity.ClientId,
                Name = entity.Name,
                Description = entity.Description,
                LogoBase64 = entity.LogoBase64,
                UserName = entity.UserName,
                Email = entity.Email,
                Phone = entity.Phone,
                Address = entity.Address,
                City = entity.City,
                State = entity.State,
                Country = entity.Country,
                ZipCode = entity.ZipCode,
                IsActive = entity.IsActive
            };
        }

        public static Clients ToEntity(this ClientDto dto)
        {
            return new Clients
            {
                ClientId = dto.ClientId == Guid.Empty ? Guid.NewGuid() : dto.ClientId,
                Name = dto.Name,
                Description = dto.Description,
                LogoBase64 = dto.LogoBase64,
                UserName = dto.UserName,
                UserPassword = dto.UserPassword,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                City = dto.City,
                State = dto.State,
                Country = dto.Country,
                ZipCode = dto.ZipCode,
                IsActive = dto.IsActive
            };
        }

        public static void UpdateEntity(this Clients entity, ClientDto dto)
        {
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.LogoBase64 = dto.LogoBase64;
            entity.UserName = dto.UserName;
            // Only update the password if it's provided
            if (!string.IsNullOrWhiteSpace(dto.UserPassword))
            {
                entity.UserPassword = dto.UserPassword;
            }
            entity.Email = dto.Email;
            entity.Phone = dto.Phone;
            entity.Address = dto.Address;
            entity.City = dto.City;
            entity.State = dto.State;
            entity.Country = dto.Country;
            entity.ZipCode = dto.ZipCode;
            entity.IsActive = dto.IsActive;
        }
    }
}
