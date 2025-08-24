using ce.imf.connect.comon.DTOs;
using ce.imf.connect.comon.Mapper;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.common.Mapper;

namespace ce.imf.connect.application.Service.Catalog
{
    public class FinalDetailsService : IFinalDetailsService
    {
        private readonly IFinalDetailsRepository _repository;

        public FinalDetailsService(IFinalDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImfResponse<IEnumerable<FinalDetailsDto>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return new ImfResponse<IEnumerable<FinalDetailsDto>>(
                data.Select(x => x.ToDto()).ToList(),
                "Fetched all FinalDetails"
            );
        }

        public async Task<ImfResponse<FinalDetailsDto>> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ImfResponse<FinalDetailsDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "FinalDetails not found" } },
                    "Not Found"
                );
            }

            return new ImfResponse<FinalDetailsDto>(entity.ToDto(), "Fetched FinalDetails by Id");
        }

        public async Task<ImfResponse<FinalDetailsDto>> GetByApplicationNoAsync(string applicationNo)
        {
            var entity = await _repository.GetByApplicationNoAsync(applicationNo);
            if (entity == null)
            {
                return new ImfResponse<FinalDetailsDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "FinalDetails not found for ApplicationNo" } },
                    "Not Found"
                );
            }

            return new ImfResponse<FinalDetailsDto>(entity.ToDto(), "Fetched FinalDetails by ApplicationNo");
        }

        public async Task<ImfResponse<FinalDetailsDto>> AddAsync(FinalDetailsDto dto)
        {
            var entity = dto.ToEntity();
            var result = await _repository.AddAsync(entity);
            return new ImfResponse<FinalDetailsDto>(result.ToDto(), "FinalDetails added successfully");
        }

        public async Task<ImfResponse<FinalDetailsDto>> UpdateAsync(FinalDetailsDto dto)
        {
            var entity = dto.ToEntity();
            var result = await _repository.UpdateAsync(entity);
            return new ImfResponse<FinalDetailsDto>(result.ToDto(), "FinalDetails updated successfully");
        }

        public async Task<ImfResponse<bool>> DeleteAsync(Guid id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
            {
                return new ImfResponse<bool>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "FinalDetails not found for deletion" } },
                    "Delete failed"
                );
            }

            return new ImfResponse<bool>(true, "FinalDetails deleted successfully");
        }
    }
}
