using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.comon.Mapper;
using ce.imf.connect.models;

namespace ce.imf.connect.application.Service.Catalog
{
    //public class FieldConfigService : IFieldConfigService
    //{
    //    private readonly IFieldConfigRepository _repository;

    //    public FieldConfigService(IFieldConfigRepository repository)
    //    {
    //        _repository = repository;
    //    }

    //    public async Task<ImfResponse<FieldConfigDto>> GetByIdAsync(Guid id)
    //    {
    //        var entity = await _repository.GetByIdAsync(id);
    //        if (entity == null)
    //            return new ImfResponse<FieldConfigDto>(new List<ImfErrors>
    //            {
    //                new ImfErrors { Code = "NOT_FOUND", Details = "FieldConfig not found", Trace = "" }
    //            });

    //        return new ImfResponse<FieldConfigDto>(entity.ToDto());
    //    }

    //    public async Task<ImfResponse<IEnumerable<FieldConfigDto>>> GetAllAsync()
    //    {
    //        var entities = await _repository.GetAllAsync();
    //        return new ImfResponse<IEnumerable<FieldConfigDto>>(entities.Select(e => e.ToDto()));
    //    }
    //    public async Task<ImfResponse<FieldConfigDto>> UpdateAsync(FieldConfigDto dto)
    //    {
    //        var existing = await _repository.GetByIdAsync(dto.Id);
    //        if (existing == null)
    //            return new ImfResponse<FieldConfigDto>(new List<ImfErrors>
    //            {
    //                new ImfErrors { Code = "NOT_FOUND", Details = "FieldConfig not found", Trace = "" }
    //            });

    //        existing.UpdateEntity(dto);
    //        await _repository.UpdateAsync(existing);
    //        return new ImfResponse<FieldConfigDto>(existing.ToDto(), "FieldConfig updated successfully");
    //    }

    //    public async Task<ImfResponse<bool>> DeleteAsync(Guid id)
    //    {
    //        var existing = await _repository.GetByIdAsync(id);
    //        if (existing == null)
    //            return new ImfResponse<bool>(new List<ImfErrors>
    //            {
    //                new ImfErrors { Code = "NOT_FOUND", Details = "FieldConfig not found", Trace = "" }
    //            });

    //        await _repository.DeleteAsync(id);
    //        return new ImfResponse<bool>(true, "FieldConfig deleted successfully");
    //    }

    //    public async Task<ImfResponse<IEnumerable<FieldConfigDto>>> AddRangeAsync(ImportFieldsRequest dto)
    //    {
    //        var entites = dto.Fields.Select(s=>s.ToEntity()).ToList();   
    //        await _repository.AddRangeAsync(entites);
    //        var result = entites.Select(e => e.ToDto()).ToList();
    //        return new ImfResponse<IEnumerable<FieldConfigDto>>(result, "FieldConfig created successfully");
    //    }
    //    public async Task<ImfResponse<IEnumerable<FieldConfigDto>>> GetByIdAsyncbyClientIdAndFormName(Guid clientId, string formName)
    //    {
    //        var entities = await _repository.GetAllAsyncByClientIdAndFornName(clientId,formName);
    //        return new ImfResponse<IEnumerable<FieldConfigDto>>(entities.Select(e => e.ToDto()));
    //    }
    //}
}
