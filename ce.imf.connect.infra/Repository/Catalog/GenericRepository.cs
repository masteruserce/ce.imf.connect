using ce.imf.connect.comon.DTOs;
using ce.imf.connect.infra.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.infra.Repository.Catalog
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _db;
        protected readonly DbSet<T> _table;

        public GenericRepository(AppDbContext db)
        {
            _db = db;
            _table = db.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _table.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> AddRangeAsync(List<T> entities)
        {
            await _table.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
            return entities;
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _table.Where(predicate).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _table.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task ActivateAsync(Guid id)
        {
            var entity = await _table.FindAsync(id);
            if (entity != null)
            {
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeactivateAsync(Guid id)
        {
            var entity = await _table.FindAsync(id);
            if (entity != null)
            {
                await _db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Core paged query. You can pass predicate (optional), ordering (optional), and paging params.
        /// If orderBy is null, results will be returned in DB natural order (not deterministic) — prefer passing orderBy.
        /// </summary>
        public async Task<PaginatedResult<T>> GetPagedAsync(
            Expression<Func<T, bool>>? predicate,
            int pageNumber,
            int pageSize,
            Expression<Func<T, DateTime>>? orderBy = null,
            bool ascending = true,
            CancellationToken cancellationToken = default)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            IQueryable<T> query = _table;

            if (predicate != null)
                query = query.Where(predicate);

            var totalCount = await query.CountAsync(cancellationToken);

            if (orderBy != null)
                query = ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);

            var skip = (pageNumber - 1) * pageSize;
            var items = await query
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var totalPages = totalCount == 0 ? 0 : (int)Math.Ceiling((double)totalCount / pageSize);

            return new PaginatedResult<T>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };
        }

        /// <summary>
        /// Convenience wrapper for predicate-only paging (no explicit ordering).
        /// </summary>
        public Task<PaginatedResult<T>> FindPagedAsync(
            Expression<Func<T, bool>> predicate,
            int pageNumber,
            int pageSize,
            Expression<Func<T, DateTime>>? orderBy = null,
            bool ascending = true,
            CancellationToken cancellationToken = default)
            => GetPagedAsync(predicate, pageNumber, pageSize, orderBy, ascending, cancellationToken);
    }
}
