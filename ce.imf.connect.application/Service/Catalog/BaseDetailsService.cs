using ce.imf.connect.comon.DTOs;
using ce.imf.connect.comon.Mapper;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.common.Mapper;

namespace ce.imf.connect.application.Service.Catalog
{
    public class BaseDetailsService : IBaseDetailsService
    {
        private readonly IBaseDetailsRepository _repository;

        public BaseDetailsService(IBaseDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImfResponse<IEnumerable<BaseDetailsDto>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return new ImfResponse<IEnumerable<BaseDetailsDto>>(
                data.Select(x => x.ToDto()).ToList(),
                "Fetched all BaseDetails"
            );
        }

        public async Task<ImfResponse<BaseDetailsDto>> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ImfResponse<BaseDetailsDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "BaseDetails not found" } },
                    "Not Found"
                );
            }

            return new ImfResponse<BaseDetailsDto>(entity.ToDto(), "Fetched BaseDetails by Id");
        }

        public async Task<ImfResponse<BaseDetailsDto>> GetByApplicationNoAsync(string applicationNo)
        {
            var entity = await _repository.GetByApplicationNoAsync(applicationNo);
            if (entity == null)
            {
                return new ImfResponse<BaseDetailsDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "BaseDetails not found for ApplicationNo" } },
                    "Not Found"
                );
            }

            return new ImfResponse<BaseDetailsDto>(entity.ToDto(), "Fetched BaseDetails by ApplicationNo");
        }

        public async Task<ImfResponse<BaseDetailsDto>> AddAsync(BaseDetailsDto dto)
        {
            var entity = dto.ToEntity();
            var result = await _repository.AddAsync(entity);
            return new ImfResponse<BaseDetailsDto>(result.ToDto(), "BaseDetails added successfully");
        }

        public async Task<ImfResponse<BaseDetailsDto>> UpdateAsync(BaseDetailsDto dto)
        {
            var entity = dto.ToEntity();
            var result = await _repository.UpdateAsync(entity);
            return new ImfResponse<BaseDetailsDto>(result.ToDto(), "BaseDetails updated successfully");
        }

        public async Task<ImfResponse<bool>> DeleteAsync(Guid id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
            {
                return new ImfResponse<bool>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "BaseDetails not found for deletion" } },
                    "Delete failed"
                );
            }

            return new ImfResponse<bool>(true, "BaseDetails deleted successfully");
        }
    }
}
