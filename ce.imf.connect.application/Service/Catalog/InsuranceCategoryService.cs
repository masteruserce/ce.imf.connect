using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.comon.Mapper;

namespace ce.imf.connect.application.Service.Catalog
{
    public class InsuranceCategoryService : IInsuranceCategoryService
    {
        private readonly IInsuranceCategoryRepository _repository;

        public InsuranceCategoryService(IInsuranceCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImfResponse<IEnumerable<InsuranceCategoryDto>>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return new ImfResponse<IEnumerable<InsuranceCategoryDto>>(entities.Select(e => e.ToDto()));
        }

        public async Task<ImfResponse<InsuranceCategoryDto>> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return new ImfResponse<InsuranceCategoryDto>(new List<ImfErrors> { new ImfErrors { Code = "404", Details = "Category not found" } });

            return new ImfResponse<InsuranceCategoryDto>(entity.ToDto());
        }

        public async Task<ImfResponse<InsuranceCategoryDto>> AddAsync(InsuranceCategoryDto dto)
        {
            var entity = await _repository.AddAsync(dto.ToEntity());
            return new ImfResponse<InsuranceCategoryDto>(entity.ToDto(), "Category added successfully");
        }

        public async Task<ImfResponse<InsuranceCategoryDto>> UpdateAsync(InsuranceCategoryDto dto)
        {
            var entity = await _repository.UpdateAsync(dto.ToEntity());
            return new ImfResponse<InsuranceCategoryDto>(entity.ToDto(), "Category updated successfully");
        }

        public async Task<ImfResponse<bool>> DeleteAsync(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            return new ImfResponse<bool>(result, result ? "Category deleted successfully" : "Delete failed");
        }
        public async Task<ImfResponse<IEnumerable<InsuranceCategoryDto>>> GetByType(string insuranceType)
        {
            var entities = await _repository.GetByType(insuranceType);
            if (entities == null)
                return new ImfResponse<IEnumerable<InsuranceCategoryDto>>(new List<ImfErrors> { new ImfErrors { Code = "404", Details = "Category not found" } });

            return new ImfResponse<IEnumerable<InsuranceCategoryDto>>(entities.Select(e => e.ToDto()));
        }
    }
}
