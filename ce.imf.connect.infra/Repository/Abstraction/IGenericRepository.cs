using ce.imf.connect.comon.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<List<T>> AddRangeAsync(List<T> entities);
        Task UpdateAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task ActivateAsync(Guid id);
        Task DeactivateAsync(Guid id);
        Task<PaginatedResult<T>> GetPagedAsync(
           Expression<Func<T, bool>>? predicate,
           int pageNumber,
           int pageSize,
           Expression<Func<T, DateTime>>? orderBy = null,
           bool ascending = true,
           CancellationToken cancellationToken = default);
        Task<PaginatedResult<T>> FindPagedAsync(
           Expression<Func<T, bool>> predicate,
           int pageNumber,
           int pageSize,
           Expression<Func<T, DateTime>>? orderBy = null,
           bool ascending = true,
           CancellationToken cancellationToken = default)
           => GetPagedAsync(predicate, pageNumber, pageSize, orderBy, ascending, cancellationToken);
    }
}
