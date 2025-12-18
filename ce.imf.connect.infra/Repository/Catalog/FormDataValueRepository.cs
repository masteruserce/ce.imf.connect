using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;
namespace ce.imf.connect.infra.Repository.Catalog
{
    public class FormDataValueRepository : IFormDataValueRepository
    {
        private readonly AppDbContext _db;
        public FormDataValueRepository(AppDbContext db) => _db = db;

        public async Task<FormDataValue> AddAsync(FormDataValue entity)
        {
            _db.FormDataValues.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<FormDataValue?> GetByIdAsync(Guid id) =>
            await _db.FormDataValues.FindAsync(id);

        public async Task<IEnumerable<FormDataValue>> GetByFormAsync(Guid formId, Guid? clientId) =>
            await _db.FormDataValues
                .Where(f => f.FormId == formId && (clientId == null || f.ClientId == clientId))
                .ToListAsync();

        public async Task UpdateAsync(FormDataValue entity)
        {
            _db.FormDataValues.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task ActivateAsync(Guid id)
        {
            var entity = await _db.FormDataValues.FindAsync(id);
            if (entity != null)
            {
                entity.Active = true;
                entity.UpdatedAt = DateTime.UtcNow;
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeactivateAsync(Guid id)
        {
            var entity = await _db.FormDataValues.FindAsync(id);
            if (entity != null)
            {
                entity.Active = false;
                entity.UpdatedAt = DateTime.UtcNow;
                await _db.SaveChangesAsync();
            }
        }
        public async Task<List<FormDataValue>> AddRangeAsync(List<FormDataValue> entity)
        {
                await _db.FormDataValues.AddRangeAsync(entity);
                await _db.SaveChangesAsync();
                return entity;

        }
    }

}
