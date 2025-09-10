using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    using ce.imf.connect.models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFieldConfigRepository
    {
        Task AddRangeAsync(IEnumerable<FieldConfig> items);
        Task<IEnumerable<FieldConfig>> GetAllAsync();
        Task<IEnumerable<FieldConfig>> GetAllAsyncByClientIdAndFornName(Guid clientId, string formName);
        Task<FieldConfig> GetByIdAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);
        Task<FieldConfig> UpdateAsync(FieldConfig entity);
    }

}
