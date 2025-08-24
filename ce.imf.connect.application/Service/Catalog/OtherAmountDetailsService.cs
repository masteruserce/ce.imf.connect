using ce.imf.connect.comon.DTOs;
using ce.imf.connect.comon.Mapper;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.common.Mapper;

namespace ce.imf.connect.application.Service.Catalog
{
    public class OtherAmountDetailsService : IOtherAmountDetailsService
    {
        private readonly IOtherAmountDetailsRepository _repository;

        public OtherAmountDetailsService(IOtherAmountDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImfResponse<IEnumerable<OtherAmountDetailsDto>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return new ImfResponse<IEnumerable<OtherAmountDetailsDto>>(
                data.Select(x => x.ToDto()).ToList(),
                "Fetched all OtherAmountDetails"
            );
        }

        public async Task<ImfResponse<OtherAmountDetailsDto>> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ImfResponse<OtherAmountDetailsDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "OtherAmountDetails not found" } },
                    "Not Found"
                );
            }

            return new ImfResponse<OtherAmountDetailsDto>(entity.ToDto(), "Fetched OtherAmountDetails by Id");
        }

        public async Task<ImfResponse<OtherAmountDetailsDto>> GetByApplicationNoAsync(string applicationNo)
        {
            var entity = await _repository.GetByApplicationNoAsync(applicationNo);
            if (entity == null)
            {
                return new ImfResponse<OtherAmountDetailsDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "OtherAmountDetails not found for ApplicationNo" } },
                    "Not Found"
                );
            }

            return new ImfResponse<OtherAmountDetailsDto>(entity.ToDto(), "Fetched OtherAmountDetails by ApplicationNo");
        }

        public async Task<ImfResponse<OtherAmountDetailsDto>> AddAsync(OtherAmountDetailsDto dto)
        {
            var entity = dto.ToEntity();
            var result = await _repository.AddAsync(entity);
            return new ImfResponse<OtherAmountDetailsDto>(result.ToDto(), "OtherAmountDetails added successfully");
        }

        public async Task<ImfResponse<OtherAmountDetailsDto>> UpdateAsync(OtherAmountDetailsDto dto)
        {
            var entity = dto.ToEntity();
            var result = await _repository.UpdateAsync(entity);
            return new ImfResponse<OtherAmountDetailsDto>(result.ToDto(), "OtherAmountDetails updated successfully");
        }

        public async Task<ImfResponse<bool>> DeleteAsync(Guid id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
            {
                return new ImfResponse<bool>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "OtherAmountDetails not found for deletion" } },
                    "Delete failed"
                );
            }

            return new ImfResponse<bool>(true, "OtherAmountDetails deleted successfully");
        }
    }
}
