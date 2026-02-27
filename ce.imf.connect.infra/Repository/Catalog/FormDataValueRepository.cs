using ce.imf.connect.common.DTOs;
using ce.imf.connect.comon.DTOs;
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
        public async Task<PaginatedResult<TransactionGridDto>> GetByFormPagedAsync(
                                                Guid formId,
                                                Guid? clientId,
                                                int pageNumber,
                                                int pageSize,
                                                bool ascending = true,
                                                CancellationToken cancellationToken = default)
        {
            var baseQuery = _db.FormDataValues
            .Where(f =>
            f.FormId == formId &&
            (clientId == null || f.ClientId == clientId) &&
            f.Active &&
            !f.IsDraft);

            // Step 1: Total distinct transactions
            var totalTransactions = await baseQuery
                .Select(x => x.TransactionId)
                .Distinct()
                .CountAsync(cancellationToken);

            // Step 2: Get paged transaction ids
            var transactionIdsQuery = baseQuery
                .Select(x => x.TransactionId)
                .Distinct();

            transactionIdsQuery = ascending
                ? transactionIdsQuery.OrderBy(x => x)
                : transactionIdsQuery.OrderByDescending(x => x);

            var transactionIds = await transactionIdsQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            if (!transactionIds.Any())
            {
                return new PaginatedResult<TransactionGridDto>
                {
                    Items = new List<TransactionGridDto>(),
                    TotalCount = 0,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = 0
                };
            }

            // Step 3: Get all rows for selected transactions
            // Join with FieldConfig
            var rows = await (
                from fd in _db.FormDataValues
                join fc in _db.FieldConfigs
                    on fd.FieldId equals fc.Id
                where fd.FormId == formId
                      && (clientId == null || fd.ClientId == clientId)
                      && fd.Active
                      && !fd.IsDraft
                      && transactionIds.Contains(fd.TransactionId)
                orderby fd.TransactionId, fd.CreatedAt
                select new FormDataValueReadResponseDto
                {
                    Id = fd.Id,
                    ClientId = fd.ClientId,
                    TransactionId = fd.TransactionId,
                    FormId = fd.FormId,
                    SectionId = fd.SectionId,
                    FieldId = fd.FieldId,
                    FieldName = fc.Label,
                    DataValue = fd.DataValue,
                    Active = fd.Active,
                    IsDraft = fd.IsDraft,
                    CreatedAt = fd.CreatedAt,
                    UpdatedAt = fd.UpdatedAt,
                    CreatedBy = fd.CreatedBy,
                    UpdatedBy = fd.UpdatedBy
                })
                .ToListAsync(cancellationToken);

            var grouped = rows
                        .GroupBy(x => x.TransactionId)
                        .Select(g => new TransactionGridDto
                        {
                            TransactionId = g.Key,
                            CreatedAt = g.First().CreatedAt,
                            Fields = g.ToDictionary(
                        x => x.FieldName,
                        x => x.DataValue
                        )
                        })
                        .ToList();

            return new PaginatedResult<TransactionGridDto>
            { 
            Items = grouped,
            TotalCount = totalTransactions,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalPages = (int)Math.Ceiling(totalTransactions / (double)pageSize)
            };
            //return new PaginatedResult<FormDataValueReadResponseDto>
            //{
            //    Items = rows,
            //    TotalCount = totalTransactions,
            //    PageNumber = pageNumber,
            //    PageSize = pageSize,
            //    TotalPages = (int)Math.Ceiling(totalTransactions / (double)pageSize)
            //};
            // Step 4: Map to DTO
            //var result = rows.Select(x => new FormDataValueReadResponseDto
            //{
            //    Id = x.Id,
            //    ClientId = x.ClientId,
            //    TransactionId = x.TransactionId,
            //    FormId = x.FormId,
            //    SectionId = x.SectionId,
            //    FieldId = x.FieldId,
            //    DataValue = x.DataValue,
            //    Active = x.Active,
            //    IsDraft = x.IsDraft,
            //    CreatedAt = x.CreatedAt,
            //    UpdatedAt = x.UpdatedAt,
            //    CreatedBy = x.CreatedBy,
            //    UpdatedBy = x.UpdatedBy
            //}).ToList();

            //return rows;
        }
    }

}
