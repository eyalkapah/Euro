using Euro.Context;
using Euro.Domain;
using Euro.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.Data.Repositories
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        private readonly EuroContext _context;
        protected IMemoryCache Cache { get; }
        protected DbSet<TEntity> Set { get; }

        // C'tor
        //
        public BaseRepository(EuroContext context, IMemoryCache cache)
        {
            _context = context;
            Cache = cache;

            Set = context.Set<TEntity>();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.AsQueryable().Any(predicate);
        }

        public void Dispose() => _context.Dispose();

        public bool IsEmpty()
        {
            return !Set.Any();
        }

        public IQueryable<TEntity> Queryable()
        {
            return Set;
        }

        protected async ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken token = default) => await Set.AddAsync(entity, token);

        protected void Delete(TEntity item) => Set.Remove(item);

        protected async Task<TEntity> FindAsync(CancellationToken token = default, params object[] keyValues) => await Set.FindAsync(keyValues, token);

        protected async Task<List<TEntity>> GetAllAsync(CancellationToken token = default) => await Set.AsNoTracking().ToListAsync(token);

        protected async ValueTask<TEntity> GetAsync(CancellationToken token = default, params object[] keyValues) => await Set.FindAsync(keyValues, token);

        protected async Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default) => await Set.AsNoTracking().AnyAsync(predicate, token);

        protected EntityState Update(TEntity entity) => _context.Entry(entity).State = EntityState.Modified;
    }
}