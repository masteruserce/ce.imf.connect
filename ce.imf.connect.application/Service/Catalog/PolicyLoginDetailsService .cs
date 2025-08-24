using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.comon.Mapper;

namespace ce.imf.connect.application.Service.Catalog
{
    public class PolicyLoginDetailsService : IPolicyLoginDetailsService
    {
        private readonly IPolicyLoginDetailsRepository _repository;

        public PolicyLoginDetailsService(IPolicyLoginDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImfResponse<IEnumerable<PolicyLoginDetailsDto>>> GetAllAsync()
        {
            var data = (await _repository.GetAllAsync()).Select(x => x.ToDto());
            return new ImfResponse<IEnumerable<PolicyLoginDetailsDto>>(data, "Fetched successfully.");
        }

        public async Task<ImfResponse<PolicyLoginDetailsDto?>> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return new ImfResponse<PolicyLoginDetailsDto?>(new List<ImfErrors> {
                new ImfErrors { Code="NOT_FOUND", Details=$"Id {id} not found" }
            }, "Record not found.");

            return new ImfResponse<PolicyLoginDetailsDto?>(entity.ToDto(), "Fetched successfully.");
        }

        public async Task<ImfResponse<PolicyLoginDetailsDto>> AddAsync(PolicyLoginDetailsDto dto)
        {
            var created = await _repository.AddAsync(dto.ToEntity());
            return new ImfResponse<PolicyLoginDetailsDto>(created.ToDto(), "Created successfully.");
        }

        public async Task<ImfResponse<PolicyLoginDetailsDto?>> UpdateAsync(PolicyLoginDetailsDto dto)
        {
            var updated = await _repository.UpdateAsync(dto.ToEntity());
            if (updated == null)
                return new ImfResponse<PolicyLoginDetailsDto?>(new List<ImfErrors> {
                new ImfErrors { Code="NOT_FOUND", Details=$"Id {dto.Id} not found" }
            }, "Update failed.");
            return new ImfResponse<PolicyLoginDetailsDto?>(updated.ToDto(), "Updated successfully.");
        }

        public async Task<ImfResponse<bool>> DeleteAsync(Guid id)
        {
            var success = await _repository.DeleteAsync(id);
            if (!success)
                return new ImfResponse<bool>(new List<ImfErrors> {
                new ImfErrors { Code="NOT_FOUND", Details=$"Id {id} not found" }
            }, "Delete failed.");
            return new ImfResponse<bool>(true, "Deleted successfully.");
        }
    }
}
