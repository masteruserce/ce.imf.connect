using ce.imf.connect.models;
namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IFormRepository
    {
        Task<Form?> GetFormWithSectionsAsync(Guid? clientId, string formName);
        Task AddFormAsync(Form form);
        Task AddSectionsAsync(IEnumerable<Section> sections);
        Task AddFieldConfigsAsync(IEnumerable<FieldConfig> fields);
        Task<bool> IsFormExistsByCLientId(Guid? clientId, string formName);
        Task<Form> UpdateAsync(Form form);

        Task<IEnumerable<Section>> UpdateSectionsAsync(IEnumerable<Section> sections);

        Task<IEnumerable<FieldConfig>> UpdateFieldConfigsAsync(IEnumerable<FieldConfig> fields);
        Task<List<Form>> GetFormByClientIdAsync(Guid? clientId);
        Task<Form?> GetFormIncludingEntities(Guid? clientId, string formName);
        Task<Form?> GetFormById(Guid formid);
        Task SaveChangesAsync();
    }
}
