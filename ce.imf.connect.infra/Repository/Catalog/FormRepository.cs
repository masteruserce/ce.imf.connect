using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.infra.Repository.Catalog
{
    public class FormRepository : IFormRepository
    {
        private readonly AppDbContext _db;
        public FormRepository(AppDbContext db) { _db = db; }

        public async Task<Form?> GetFormWithSectionsAsync(Guid? clientId, string formName)
        {
            return await _db.Forms
                .Include(f => f.Sections)
                    .ThenInclude(s => s.Fields)
                .Where(f => f.FormName == formName && f.ClientId == clientId)
                .FirstOrDefaultAsync();
        }

        public async Task AddFormAsync(Form form)
        {
            _db.Forms.Add(form);
            await _db.SaveChangesAsync();
        }

        public async Task AddSectionsAsync(IEnumerable<Section> sections)
        {
            _db.sections.AddRange(sections);
            await _db.SaveChangesAsync();
        }

        public async Task AddFieldConfigsAsync(IEnumerable<FieldConfig> fields)
        {
            _db.FieldConfigs.AddRange(fields);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> IsFormExistsByCLientId(Guid? clientId, string formName)
        {
            return await _db.Forms.Where(x => x.ClientId == clientId && x.FormName == formName).AnyAsync();
        }
        public async Task<Form> UpdateAsync(Form form)
        {
            _db.Forms.Update(form);
            await _db.SaveChangesAsync();
            return form;
        }

        public async Task<IEnumerable<Section>>  UpdateSectionsAsync(IEnumerable<Section> sections)
        {
            _db.sections.UpdateRange(sections);
            await _db.SaveChangesAsync();
            return sections;
        }

        public async Task<IEnumerable<FieldConfig>> UpdateFieldConfigsAsync(IEnumerable<FieldConfig> fields)
        {
            _db.FieldConfigs.UpdateRange(fields);
            await _db.SaveChangesAsync();
            return fields;
        }

        public async Task<List<Form>> GetFormByClientIdAsync(Guid? clientId)
        {
            return await _db.Forms.Where(x => x.ClientId == clientId).ToListAsync();
        }

        public async Task<Form?> GetFormIncludingEntities(Guid? clientId, string formName)
        {
           return await _db.Forms
                .Include(f => f.Sections)
                .ThenInclude(s => s.Fields)
                .FirstOrDefaultAsync(f => f.ClientId == clientId && f.FormName == formName);
        }
        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
