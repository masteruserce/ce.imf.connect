using ce.imf.connect.comon.DTOs;
using ce.imf.connect.comon.Mapper;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.common.Mapper;

namespace ce.imf.connect.application.Service.Catalog
{
    public class PcDetailsService : IPcDetailsService
    {
        private readonly IPcDetailsRepository _repository;

        public PcDetailsService(IPcDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImfResponse<IEnumerable<PcDetailsDto>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return new ImfResponse<IEnumerable<PcDetailsDto>>(
                data.Select(x => x.ToDto()).ToList(),
                "Fetched all PcDetails"
            );
        }

        public async Task<ImfResponse<PcDetailsDto>> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ImfResponse<PcDetailsDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "PcDetails not found" } },
                    "Not Found"
                );
            }

            return new ImfResponse<PcDetailsDto>(entity.ToDto(), "Fetched PcDetails by Id");
        }

        public async Task<ImfResponse<PcDetailsDto>> GetByApplicationNoAsync(string applicationNo)
        {
            var entity = await _repository.GetByApplicationNoAsync(applicationNo);
            if (entity == null)
            {
                return new ImfResponse<PcDetailsDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "PcDetails not found for ApplicationNo" } },
                    "Not Found"
                );
            }

            return new ImfResponse<PcDetailsDto>(entity.ToDto(), "Fetched PcDetails by ApplicationNo");
        }

        public async Task<ImfResponse<PcDetailsDto>> AddAsync(PcDetailsDto dto)
        {
            var entity = dto.ToEntity();
            var result = await _repository.AddAsync(entity);
            return new ImfResponse<PcDetailsDto>(result.ToDto(), "PcDetails added successfully");
        }

        public async Task<ImfResponse<PcDetailsDto>> UpdateAsync(PcDetailsDto dto)
        {
            var entity = dto.ToEntity();
            var result = await _repository.UpdateAsync(entity);
            return new ImfResponse<PcDetailsDto>(result.ToDto(), "PcDetails updated successfully");
        }

        public async Task<ImfResponse<bool>> DeleteAsync(Guid id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
            {
                return new ImfResponse<bool>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "PcDetails not found for deletion" } },
                    "Delete failed"
                );
            }

            return new ImfResponse<bool>(true, "PcDetails deleted successfully");
        }
    }
}
