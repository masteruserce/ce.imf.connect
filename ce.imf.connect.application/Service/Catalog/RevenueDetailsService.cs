using ce.imf.connect.comon.DTOs;
using ce.imf.connect.comon.Mapper;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.common.Mapper;

namespace ce.imf.connect.application.Service.Catalog
{
    public class RevenueDetailsService : IRevenueDetailsService
    {
        private readonly IRevenueDetailsRepository _repository;

        public RevenueDetailsService(IRevenueDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImfResponse<IEnumerable<RevenueDetailsDto>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return new ImfResponse<IEnumerable<RevenueDetailsDto>>(data.Select(x => x.ToDto()).ToList(), "Fetched all RevenueDetails");
        }

        public async Task<ImfResponse<RevenueDetailsDto>> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return new ImfResponse<RevenueDetailsDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "RevenueDetails not found" } },
                    "Not Found"
                );

            return new ImfResponse<RevenueDetailsDto>(entity.ToDto(), "Fetched RevenueDetails by Id");
        }

        public async Task<ImfResponse<RevenueDetailsDto>> GetByApplicationNoAsync(string applicationNo)
        {
            var entity = await _repository.GetByApplicationNoAsync(applicationNo);
            if (entity == null)
                return new ImfResponse<RevenueDetailsDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "RevenueDetails not found for ApplicationNo" } },
                    "Not Found"
                );

            return new ImfResponse<RevenueDetailsDto>(entity.ToDto(), "Fetched RevenueDetails by ApplicationNo");
        }

        public async Task<ImfResponse<RevenueDetailsDto>> AddAsync(RevenueDetailsDto dto)
        {
            var entity = dto.ToEntity();
            var result = await _repository.AddAsync(entity);
            return new ImfResponse<RevenueDetailsDto>(result.ToDto(), "RevenueDetails added successfully");
        }

        public async Task<ImfResponse<RevenueDetailsDto>> UpdateAsync(RevenueDetailsDto dto)
        {
            var entity = dto.ToEntity();
            var result = await _repository.UpdateAsync(entity);
            return new ImfResponse<RevenueDetailsDto>(result.ToDto(), "RevenueDetails updated successfully");
        }

        public async Task<ImfResponse<bool>> DeleteAsync(Guid id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
                return new ImfResponse<bool>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "RevenueDetails not found for deletion" } },
                    "Delete failed"
                );

            return new ImfResponse<bool>(true, "RevenueDetails deleted successfully");
        }
    }
}
