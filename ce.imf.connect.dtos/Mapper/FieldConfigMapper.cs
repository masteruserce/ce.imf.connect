using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.Mapper
{
    public static class FieldConfigMapper
    {
        public static FieldConfigDto ToDto(this FieldConfig e) => new FieldConfigDto
        {
            Id = e.Id,
            ClientId = e.ClientId,
            SectionId = e.SectionId,
            FieldName = e.FieldName,
            FieldOrder = e.FieldOrder,
            Type = e.Type ?? "text",
            Label = e.Label ?? string.Empty,
            Placeholder = e.Placeholder ?? string.Empty,
            Options = e.Options ?? string.Empty,
            Required = e.Required,
            ValidationMessage = e.ValidationMessage ?? string.Empty,
            DefaultValue = e.DefaultValue ?? string.Empty
        };

        public static FieldConfig ToEntity(this FieldConfigDto d) => new FieldConfig
        {
            Id = d.Id == Guid.Empty ? Guid.NewGuid() : d.Id,
            ClientId = d.ClientId,
            SectionId = d.SectionId,
            FieldName = d.FieldName,
            FieldOrder = d.FieldOrder,
            Type = string.IsNullOrWhiteSpace(d.Type) ? "text" : d.Type,
            Label = d.Label ?? string.Empty,
            Placeholder = d.Placeholder ?? string.Empty,
            Options = d.Options ?? string.Empty,
            Required = d.Required,
            ValidationMessage = d.ValidationMessage ?? string.Empty,
            DefaultValue = d.DefaultValue ?? string.Empty
        };
    }

}
