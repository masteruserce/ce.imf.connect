using ce.imf.connect.comon.DTOs;
using ce.imf.connect.comon.Mapper;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.common.Mapper;

namespace ce.imf.connect.application.Service.Catalog
{
    public class FiftyBcDetailsService : IFiftyBcDetailsService
    {
        private readonly IFiftyBcDetailsRepository _repository;

        public FiftyBcDetailsService(IFiftyBcDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImfResponse<IEnumerable<FiftyBcDetailsDto>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return new ImfResponse<IEnumerable<FiftyBcDetailsDto>>(
                data.Select(x => x.ToDto()).ToList(),
                "Fetched all FiftyBcDetails"
            );
        }

        public async Task<ImfResponse<FiftyBcDetailsDto>> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ImfResponse<FiftyBcDetailsDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "FiftyBcDetails not found" } },
                    "Not Found"
                );
            }

            return new ImfResponse<FiftyBcDetailsDto>(entity.ToDto(), "Fetched FiftyBcDetails by Id");
        }

        public async Task<ImfResponse<FiftyBcDetailsDto>> GetByApplicationNoAsync(string applicationNo)
        {
            var entity = await _repository.GetByApplicationNoAsync(applicationNo);
            if (entity == null)
            {
                return new ImfResponse<FiftyBcDetailsDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "FiftyBcDetails not found for ApplicationNo" } },
                    "Not Found"
                );
            }

            return new ImfResponse<FiftyBcDetailsDto>(entity.ToDto(), "Fetched FiftyBcDetails by ApplicationNo");
        }

        public async Task<ImfResponse<FiftyBcDetailsDto>> AddAsync(FiftyBcDetailsDto dto)
        {
            var entity = dto.ToEntity();
            var result = await _repository.AddAsync(entity);
            return new ImfResponse<FiftyBcDetailsDto>(result.ToDto(), "FiftyBcDetails added successfully");
        }

        public async Task<ImfResponse<FiftyBcDetailsDto>> UpdateAsync(FiftyBcDetailsDto dto)
        {
            var entity = dto.ToEntity();
            var result = await _repository.UpdateAsync(entity);
            return new ImfResponse<FiftyBcDetailsDto>(result.ToDto(), "FiftyBcDetails updated successfully");
        }

        public async Task<ImfResponse<bool>> DeleteAsync(Guid id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
            {
                return new ImfResponse<bool>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "FiftyBcDetails not found for deletion" } },
                    "Delete failed"
                );
            }

            return new ImfResponse<bool>(true, "FiftyBcDetails deleted successfully");
        }
    }
}
