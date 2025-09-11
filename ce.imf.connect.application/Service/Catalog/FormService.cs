using Azure.Core;
using ce.imf.connect.common.Mapper;
using ce.imf.connect.comon.DTOs;
using ce.imf.connect.comon.Mapper;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
namespace ce.imf.connect.application.Service.Catalog
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _repo;
        public FormService(IFormRepository repo) { _repo = repo; }

        public async Task<ImfResponse<FormDto>> GetFormAsync(Guid? clientId, string formName)
        {
            try
            {
                var form = await _repo.GetFormWithSectionsAsync(clientId, formName);
                if (form == null) return new ImfResponse<FormDto>(new List<ImfErrors> { new ImfErrors { Code = "NOT_FOUND", Details = "Form not found" } });
                var dto = new FormDto
                {
                    Id = form.Id,
                    ClientId = form.ClientId,
                    FormName = form.FormName,
                    Sections = form.Sections.OrderBy(s => s.DisplayOrder).Select(s => new SectionDto
                    {
                        Id = s.Id,
                        ClientId = s.ClientId,
                        FormId = s.FormId,
                        SectionName = s.SectionName,
                        DisplayOrder = s.DisplayOrder,
                        Fields = s.Fields.OrderBy(f => f.FieldOrder).Select(f => f.ToDto()).ToList()
                    }).ToList()
                };
                return new ImfResponse<FormDto>(dto, "OK");
            }
            catch (Exception ex)
            {
                return new ImfResponse<FormDto>(new List<ImfErrors> { new ImfErrors { Code = "ERR", Details = ex.Message, Trace = ex.StackTrace ?? "" } }, "Error");
            }
        }

        public async Task<ImfResponse<List<FormDto>>> GetFormsByClientIdAsync(Guid? clientId)
        {
            var forms = await _repo.GetFormByClientIdAsync(clientId);
            var formDtos = forms.Select(form => new FormDto
            {
                Id = form.Id,
                ClientId = form.ClientId,
                FormName = form.FormName,
                Sections = form.Sections.OrderBy(s => s.DisplayOrder).Select(s => new SectionDto
                {
                    Id = s.Id,
                    ClientId = s.ClientId,
                    FormId = s.FormId,
                    SectionName = s.SectionName,
                    DisplayOrder = s.DisplayOrder,
                    Fields = s.Fields.OrderBy(f => f.FieldOrder).Select(f => f.ToDto()).ToList()
                }).ToList()
            }).ToList();
            return new ImfResponse<List<FormDto>>(formDtos, "OK");
        }

        public async Task<ImfResponse<FormDto>> ImportFormAsync(ImportFieldsRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.FormName))
                return new ImfResponse<FormDto>(new List<ImfErrors> { new ImfErrors { Code = "BAD_REQUEST", Details = "FormName required" } });
            try
            {
                if (await _repo.IsFormExistsByCLientId(request.ClientId, request.FormName))
                {
                    var formDto = await GetFormAsync(request.ClientId, request.FormName);
                        formDto.Data.Sections = request.Sections;
                    var updatedEntity = await UpdateFormAsync(request.ClientId.Value, request.FormName, formDto.Data);
                    return updatedEntity;
                }
                else
                {
                   
                    return await AddFormAsync(request);
                }
            }

            catch (Exception ex)
            {
                return new ImfResponse<FormDto>(new List<ImfErrors> { new ImfErrors { Code = "ERR", Details = ex.Message, Trace = ex.StackTrace ?? "" } }, "Import failed");
            }
        }

        private async Task<ImfResponse<FormDto>> AddFormAsync(ImportFieldsRequest request)
        {
            // 1. create form record
            var form = new Form { Id = Guid.NewGuid(), ClientId = request.ClientId, FormName = request.FormName };
            await _repo.AddFormAsync(form);

            // 2. create sections and fields
            var sections = request.Sections.Select(s => new Section
            {
                Id = Guid.NewGuid(),
                ClientId = request.ClientId,
                FormId = form.Id,
                SectionName = s.SectionName,
                DisplayOrder = s.DisplayOrder
            }).ToList();

            await _repo.AddSectionsAsync(sections);

            var fields = new List<FieldConfig>();
            foreach (var sDto in request.Sections)
            {
                var sectionEntity = sections.First(x => x.SectionName == sDto.SectionName);
                foreach (var fDto in sDto.Fields)
                {
                    var field = new FieldConfig
                    {
                        Id = Guid.NewGuid(),
                        ClientId = request.ClientId,
                        SectionId = sectionEntity.Id,
                        FieldName = string.IsNullOrWhiteSpace(fDto.FieldName) ? string.Empty : fDto.FieldName,
                        FieldOrder = fDto.FieldOrder,
                        Type = string.IsNullOrWhiteSpace(fDto.Type) ? "text" : fDto.Type,
                        Label = fDto.Label ?? string.Empty,
                        Placeholder = fDto.Placeholder ?? string.Empty,
                        Options = fDto.Options ?? string.Empty,
                        Required = fDto.Required,
                        ValidationMessage = fDto.ValidationMessage ?? string.Empty,
                        DefaultValue = fDto.DefaultValue ?? string.Empty
                    };
                    fields.Add(field);
                }
            }
            if (fields.Any()) await _repo.AddFieldConfigsAsync(fields);

            var dto = new FormDto
            {
                Id = form.Id,
                ClientId = form.ClientId,
                FormName = form.FormName,
                Sections = form.Sections.OrderBy(s => s.DisplayOrder).Select(s => new SectionDto
                {
                    Id = s.Id,
                    ClientId = s.ClientId,
                    FormId = s.FormId,
                    SectionName = s.SectionName,
                    DisplayOrder = s.DisplayOrder,
                    Fields = s.Fields.OrderBy(f => f.FieldOrder).Select(f => f.ToDto()).ToList()
                }).ToList()
            };
            return new ImfResponse<FormDto>(dto, "Form imported successfully.");
        }

        private async Task<ImfResponse<FormDto>> UpdateFormAsync(Guid clientId, string formName, FormDto formDto)
        {
            var existingForm = await _repo.GetFormWithSectionsAsync(clientId, formName);

            if (existingForm == null)
            {
                return new ImfResponse<FormDto>(
                    new List<ImfErrors> {
                        new ImfErrors {
                            Code = "404",
                            Details = $"Form '{formName}' for Client '{clientId}' not found",
                            Trace = string.Empty
                        }
                    },
                    "Update failed"
                );
            }

            // ✅ Update form details
            existingForm.FormName = formDto.FormName;

            // ✅ Update Sections
            foreach (var secDto in formDto.Sections)
            {
                var existingSection = existingForm.Sections.FirstOrDefault(s => s.SectionName == secDto.SectionName);
                if (existingSection == null)
                {
                    // Add new section
                    existingForm.Sections.Add(new Section
                    {
                        Id = Guid.NewGuid(),
                        ClientId = clientId,
                        FormId = existingForm.Id,
                        SectionName = secDto.SectionName,
                        DisplayOrder = secDto.DisplayOrder,
                        Fields = secDto.Fields.Select(f => new FieldConfig
                        {
                            Id = Guid.NewGuid(),
                            SectionId = secDto.Id.Value,
                            ClientId = clientId,
                            FieldName = f.FieldName,
                            FieldOrder = f.FieldOrder,
                            Type = string.IsNullOrWhiteSpace(f.Type) ? "text" : f.Type,
                            Label = f.Label ?? "",
                            Placeholder = f.Placeholder ?? "",
                            Options = f.Options ?? "",
                            Required = f.Required,
                            ValidationMessage = f.ValidationMessage ?? "",
                            DefaultValue = f.DefaultValue ?? ""
                        }).ToList()
                    });
                }
                else
                {
                    // Update section
                    existingSection.SectionName = secDto.SectionName;
                    existingSection.DisplayOrder = secDto.DisplayOrder;

                    // ✅ Update Fields
                    foreach (var fieldDto in secDto.Fields)
                    {
                        var existingField = existingSection.Fields.FirstOrDefault(f => f.FieldName == fieldDto.FieldName);
                        if (existingField == null)
                        {
                            existingSection.Fields.Add(new FieldConfig
                            {
                                Id = Guid.NewGuid(),
                                SectionId = existingSection.Id,
                                ClientId = clientId,
                                FieldName = fieldDto.FieldName,
                                FieldOrder = fieldDto.FieldOrder,
                                Type = string.IsNullOrWhiteSpace(fieldDto.Type) ? "text" : fieldDto.Type,
                                Label = fieldDto.Label ?? "",
                                Placeholder = fieldDto.Placeholder ?? "",
                                Options = fieldDto.Options ?? "",
                                Required = fieldDto.Required,
                                ValidationMessage = fieldDto.ValidationMessage ?? "",
                                DefaultValue = fieldDto.DefaultValue ?? ""
                            });
                        }
                        else
                        {
                            existingField.FieldName = fieldDto.FieldName;
                            existingField.FieldOrder = fieldDto.FieldOrder;
                            existingField.Type = string.IsNullOrWhiteSpace(fieldDto.Type) ? "text" : fieldDto.Type;
                            existingField.Label = fieldDto.Label ?? "";
                            existingField.Placeholder = fieldDto.Placeholder ?? "";
                            existingField.Options = fieldDto.Options ?? "";
                            existingField.Required = fieldDto.Required;
                            existingField.ValidationMessage = fieldDto.ValidationMessage ?? "";
                            existingField.DefaultValue = fieldDto.DefaultValue ?? "";
                        }
                    }
                }
            }

            // Save updates
            var updated = await _repo.UpdateAsync(existingForm);

            var form = new FormDto
            {
                ClientId = updated.ClientId,
                FormName = updated.FormName,
                Id = updated.Id,
                Sections = updated.Sections.OrderBy(s => s.DisplayOrder).Select(s => new SectionDto
                {
                    Id = s.Id,
                    ClientId = s.ClientId,
                    FormId = s.FormId,
                    SectionName = s.SectionName,
                    DisplayOrder = s.DisplayOrder,
                    Fields = s.Fields.OrderBy(f => f.FieldOrder).Select(f => f.ToDto()).ToList()
                }).ToList()
            };

            return new ImfResponse<FormDto>(form, "Form updated successfully");
        }
    }
}
