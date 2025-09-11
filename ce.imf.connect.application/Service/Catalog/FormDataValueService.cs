using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.common.DTOs;
using ce.imf.connect.comon.DTOs;
using ce.imf.connect.comon.Mapper;
using ce.imf.connect.infra.Repository.Abstraction;

namespace ce.imf.connect.application.Service.Catalog
{
    public class FormDataValueService : IFormDataValueService
    {
        private readonly IFormDataValueRepository _repo;
        public FormDataValueService(IFormDataValueRepository repo) => _repo = repo;

        public async Task<ImfResponse<FormDataValueDto>> SaveAsync(FormDataValueDto dto)
        {
            var entity = dto.ToEntity();
            var saved = await _repo.AddAsync(entity);
            return new ImfResponse<FormDataValueDto>(saved.ToDto(), "Saved successfully");
        }

        public async Task<ImfResponse<FormDataValueDto>> UpdateAsync(FormDataValueDto dto)
        {
            var entity = await _repo.GetByIdAsync(dto.Id);
            if (entity == null) return new ImfResponse<FormDataValueDto>(
                new List<ImfErrors> { new ImfErrors { Code = "404", Details = "Not Found" } }, "Entity not found");

            entity.UpdateEntity(dto);
            await _repo.UpdateAsync(entity);
            return new ImfResponse<FormDataValueDto>(entity.ToDto(), "Updated successfully");
        }

        public async Task<ImfResponse<bool>> ActivateAsync(Guid id)
        {
            await _repo.ActivateAsync(id);
            return new ImfResponse<bool>(true, "Activated successfully");
        }

        public async Task<ImfResponse<bool>> DeactivateAsync(Guid id)
        {
            await _repo.DeactivateAsync(id);
            return new ImfResponse<bool>(true, "Deactivated successfully");
        }

        public async Task<ImfResponse<IEnumerable<FormDataValueDto>>> GetByFormAsync(Guid formId, Guid? clientId)
        {
            var values = await _repo.GetByFormAsync(formId, clientId);
            return new ImfResponse<IEnumerable<FormDataValueDto>>(values.Select(v => v.ToDto()), "Fetched successfully");
        }
    }

}
