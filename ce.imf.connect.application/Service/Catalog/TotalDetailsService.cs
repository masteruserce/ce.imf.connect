using ce.imf.connect.comon.DTOs;
using ce.imf.connect.comon.Mapper;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.common.Mapper;

namespace ce.imf.connect.application.Service.Catalog
{
    public class TotalDetailsService : ITotalDetailsService
    {
        private readonly ITotalDetailsRepository _repository;

        public TotalDetailsService(ITotalDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImfResponse<IEnumerable<TotalDetailsDto>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return new ImfResponse<IEnumerable<TotalDetailsDto>>(
                data.Select(x => x.ToDto()).ToList(),
                "Fetched all Total details"
            );
        }

        public async Task<ImfResponse<TotalDetailsDto>> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ImfResponse<TotalDetailsDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "Total details not found" } },
                    "Not Found"
                );
            }

            return new ImfResponse<TotalDetailsDto>(entity.ToDto(), "Fetched Total details by Id");
        }

        public async Task<ImfResponse<TotalDetailsDto>> GetByApplicationNoAsync(string applicationNo)
        {
            var entity = await _repository.GetByApplicationNoAsync(applicationNo);
            if (entity == null)
            {
                return new ImfResponse<TotalDetailsDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "Total details not found for ApplicationNo" } },
                    "Not Found"
                );
            }

            return new ImfResponse<TotalDetailsDto>(entity.ToDto(), "Fetched Total details by ApplicationNo");
        }

        public async Task<ImfResponse<TotalDetailsDto>> AddAsync(TotalDetailsDto dto)
        {
            var entity = dto.ToEntity();
            var result = await _repository.AddAsync(entity);
            return new ImfResponse<TotalDetailsDto>(result.ToDto(), "Total details added successfully");
        }

        public async Task<ImfResponse<TotalDetailsDto>> UpdateAsync(TotalDetailsDto dto)
        {
            var entity = dto.ToEntity();
            var result = await _repository.UpdateAsync(entity);
            return new ImfResponse<TotalDetailsDto>(result.ToDto(), "Total details updated successfully");
        }

        public async Task<ImfResponse<bool>> DeleteAsync(Guid id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
            {
                return new ImfResponse<bool>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "Total details not found for deletion" } },
                    "Delete failed"
                );
            }

            return new ImfResponse<bool>(true, "Total details deleted successfully");
        }
    }
}
