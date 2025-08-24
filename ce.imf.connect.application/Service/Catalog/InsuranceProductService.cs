using ce.imf.connect.comon.DTOs;
using ce.imf.connect.comon.Mapper;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.common.Mapper;

namespace ce.imf.connect.application.Service.Catalog
{
    public class InsuranceProductService : IInsuranceProductService
    {
        private readonly IInsuranceProductRepository _repository;

        public InsuranceProductService(IInsuranceProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImfResponse<InsuranceProductDto?>> GetByIdAsync(Guid id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null)
            {
                return new ImfResponse<InsuranceProductDto?>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "InsuranceProduct not found" } }
                );
            }
            return new ImfResponse<InsuranceProductDto?>(data.ToDto(), "InsuranceProduct fetched successfully");
        }

        public async Task<ImfResponse<IEnumerable<InsuranceProductDto>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return new ImfResponse<IEnumerable<InsuranceProductDto>>(data.Select(x=>x.ToDto()), "InsuranceProducts fetched successfully");
        }

        public async Task<ImfResponse<InsuranceProductDto>> AddAsync(InsuranceProductDto dto)
        {
            var data = await _repository.AddAsync(dto.ToEntity());
            return new ImfResponse<InsuranceProductDto>(data.ToDto(), "InsuranceProduct created successfully");
        }

        public async Task<ImfResponse<InsuranceProductDto?>> UpdateAsync(InsuranceProductDto dto)
        {
            var data = await _repository.UpdateAsync(dto.ToEntity());
            if (data == null)
            {
                return new ImfResponse<InsuranceProductDto?>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "InsuranceProduct not found for update" } }
                );
            }
            return new ImfResponse<InsuranceProductDto?>(data.ToDto(), "InsuranceProduct updated successfully");
        }

        public async Task<ImfResponse<bool>> DeleteAsync(Guid id)
        {
            var success = await _repository.DeleteAsync(id);
            if (!success)
            {
                return new ImfResponse<bool>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "InsuranceProduct not found for deletion" } }
                );
            }
            return new ImfResponse<bool>(true, "InsuranceProduct deleted successfully");
        }
    }
}
