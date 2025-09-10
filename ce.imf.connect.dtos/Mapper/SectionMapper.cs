using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.Mapper
{
    public static class SectionMapper
    {
        public static SectionDto ToDto(this Section e) => new SectionDto
        {
            Id = e.Id,
            ClientId = e.ClientId,
            DisplayOrder = e.DisplayOrder,
            SectionName = e.SectionName,
            FormId = e.FormId,
        };

        public static Section ToEntity(this SectionDto d) => new Section
        {
            Id = d.Id == Guid.Empty ? Guid.NewGuid() : d.Id.Value,
            ClientId = d.ClientId,
            SectionName = d.SectionName,
            DisplayOrder = d.DisplayOrder,
            FormId = d.FormId.Value
        };
    }

}
