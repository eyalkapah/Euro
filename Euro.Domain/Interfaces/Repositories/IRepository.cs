using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity item);

        void AddRange(IEnumerable<TEntity> entities);

        bool Any(Expression<Func<TEntity, bool>> predicate);

        void Delete(object[] keyValues);

        void Delete(TEntity item);

        void Delete<TKey>(TKey key);

        TEntity Find(params object[] keyValues);

        bool IsEmpty();

        bool IsExists(object[] keyValues);

        bool IsExists<TKey>(TKey keyValue);

        IQueryable<TEntity> Queryable();

        IEnumerable<TEntity> GetAll();

        //void Update(TEntity item);

        //Task<List<TEntity>> GetAllAsync(CancellationToken token = default);

        //Task<TEntity> FindAsync(CancellationToken token = default, params object[] keyValues);

        //Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default);

        //ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken token = default);

        //ValueTask<TEntity> GetAsync(CancellationToken token = default, params object[] keyValues);

        //EntityEntry<TEntity> Update(TEntity entity);
    }
}