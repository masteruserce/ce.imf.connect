using ce.imf.connect.common.DTOs;
using ce.imf.connect.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.Mapper
{
    public static class FormDataValueMapper
    {
        public static FormDataValueDto ToDto(this FormDataValue entity) =>
            new FormDataValueDto
            {
                Id = entity.Id,
                ClientId = entity.ClientId,
                FormId = entity.FormId,
                SectionId = entity.SectionId,
                FieldId = entity.FieldId,
                DataValue = entity.DataValue,
                Active = entity.Active
            };

        public static FormDataValue ToEntity(this FormDataValueDto dto) =>
            new FormDataValue
            {
                Id = dto.Id,
                ClientId = dto.ClientId,
                FormId = dto.FormId,
                SectionId = dto.SectionId,
                FieldId = dto.FieldId,
                DataValue = dto.DataValue,
                Active = dto.Active
            };

        public static void UpdateEntity(this FormDataValue entity, FormDataValueDto dto)
        {
            entity.DataValue = dto.DataValue;
            entity.Active = dto.Active;
            entity.UpdatedAt = DateTime.UtcNow;
        }
    }

}
