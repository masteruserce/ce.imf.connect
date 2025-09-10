using ce.imf.connect.infra;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FieldConfigRepository : IFieldConfigRepository
{
    private readonly AppDbContext _db;
    public FieldConfigRepository(AppDbContext db) => _db = db;

    public async Task AddRangeAsync(IEnumerable<FieldConfig> items)
    {
        await _db.FieldConfigs.AddRangeAsync(items);
        await _db.SaveChangesAsync();
    }
    public async Task<IEnumerable<FieldConfig>> GetAllAsync()
    {
        return await _db.FieldConfigs.ToListAsync();
    }
    public async Task<FieldConfig> GetByIdAsync(Guid id)
    {
        return await _db.FieldConfigs.Where(x=>x.ClientId == id).FirstAsync();
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var e = await _db.FieldConfigs.FindAsync(id);
        if (e != null) 
        {
            _db.FieldConfigs.Remove(e); 
            var result = await _db.SaveChangesAsync();
            return result > -1;
        }
        return false;
    }

    public async Task<FieldConfig> UpdateAsync(FieldConfig entity)
    {
        _db.FieldConfigs.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<FieldConfig>> GetAllAsyncByClientIdAndFornName(Guid clientId, string formName)
    {
        return await _db.FieldConfigs.Where(x => x.ClientId == clientId).ToListAsync();    
    }
}
