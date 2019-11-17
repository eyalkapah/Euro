using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        //void AddRange(IEnumerable<TEntity> entities);

        //bool Any(Expression<Func<TEntity, bool>> predicate);

        //bool IsEmpty();

        //IQueryable<TEntity> Queryable();
        Task AddAsync(TEntity input, CancellationToken token);

        Task DeleteAsync(CancellationToken token = default, params object[] keyValues);

        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token = default);

        Task<TEntity> GetByIdAsync(CancellationToken token = default, params object[] keyValues);

        Task UpdateAsync(TEntity item, CancellationToken token = default, params object[] keyValues);
    }
}