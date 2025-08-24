using ce.imf.connect.comon.DTOs;
using ce.imf.connect.comon.Mapper;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.common.Mapper;

namespace ce.imf.connect.application.Service.Catalog
{
    public class PayoutDetailsService : IPayoutDetailsService
    {
        private readonly IPayoutDetailsRepository _repository;

        public PayoutDetailsService(IPayoutDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImfResponse<IEnumerable<PayoutDetailsDto>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return new ImfResponse<IEnumerable<PayoutDetailsDto>>(
                data.Select(x => x.ToDto()).ToList(),
                "Fetched all Payout details"
            );
        }

        public async Task<ImfResponse<PayoutDetailsDto>> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ImfResponse<PayoutDetailsDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "Payout details not found" } },
                    "Not Found"
                );
            }

            return new ImfResponse<PayoutDetailsDto>(entity.ToDto(), "Fetched Payout details by Id");
        }

        public async Task<ImfResponse<PayoutDetailsDto>> GetByApplicationNoAsync(string applicationNo)
        {
            var entity = await _repository.GetByApplicationNoAsync(applicationNo);
            if (entity == null)
            {
                return new ImfResponse<PayoutDetailsDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "Payout details not found for ApplicationNo" } },
                    "Not Found"
                );
            }

            return new ImfResponse<PayoutDetailsDto>(entity.ToDto(), "Fetched Payout details by ApplicationNo");
        }

        public async Task<ImfResponse<PayoutDetailsDto>> AddAsync(PayoutDetailsDto dto)
        {
            var entity = dto.ToEntity();
            var result = await _repository.AddAsync(entity);
            return new ImfResponse<PayoutDetailsDto>(result.ToDto(), "Payout details added successfully");
        }

        public async Task<ImfResponse<PayoutDetailsDto>> UpdateAsync(PayoutDetailsDto dto)
        {
            var entity = dto.ToEntity();
            var result = await _repository.UpdateAsync(entity);
            return new ImfResponse<PayoutDetailsDto>(result.ToDto(), "Payout details updated successfully");
        }

        public async Task<ImfResponse<bool>> DeleteAsync(Guid id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
            {
                return new ImfResponse<bool>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "Payout details not found for deletion" } },
                    "Delete failed"
                );
            }

            return new ImfResponse<bool>(true, "Payout details deleted successfully");
        }
    }
}
