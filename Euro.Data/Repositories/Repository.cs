using Euro.Context;
using Euro.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly EuroContext _context;
        protected DbSet<TEntity> Set { get; }

        // C'tor
        //
        public Repository(EuroContext context)
        {
            _context = context;

            Set = context.Set<TEntity>();
        }

        public void Dispose() => _context.Dispose();

        public void Add(TEntity item)
        {
            _context.Entry(item).State = EntityState.Added;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.AsQueryable().Any(predicate);
        }

        public TEntity Find(params object[] keyValues)
        {
            return Set.Find(keyValues);
        }

        public bool IsEmpty()
        {
            return !Set.Any();
        }

        public bool IsExists(object[] keyValues)
        {
            return Find(keyValues) != null;
        }

        public bool IsExists<TKey>(TKey keyValue)
        {
            return Find(keyValue) != null;
        }

        public IQueryable<TEntity> Queryable()
        {
            return Set;
        }

        //public void Update(TEntity item)
        //{
        //    _context.Entry(item).State = EntityState.Modified;
        //}

        public IEnumerable<TEntity> GetAll()
        {
            return Set.ToList();
        }

        protected async Task<List<TEntity>> GetAllAsync(CancellationToken token = default) => await Set.AsNoTracking().ToListAsync(token);

        protected async Task<TEntity> FindAsync(CancellationToken token = default, params object[] keyValues) => await Set.FindAsync(keyValues, token);

        protected async Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default) => await Set.AsNoTracking().AnyAsync(predicate, token);

        protected async ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken token = default) => await Set.AddAsync(entity, token);

        protected async ValueTask<TEntity> GetAsync(CancellationToken token = default, params object[] keyValues) => await Set.FindAsync(keyValues, token);

        protected EntityEntry<TEntity> Update(TEntity entity) => Set.Update(entity);

        public void Delete(object[] keyValues)
        {
            var item = Find(keyValues);

            if (item == null)
                throw new KeyNotFoundException();

            Set.Remove(item);
        }

        public void Delete(TEntity item) => Set.Remove(item);

        public void Delete<TKey>(TKey key)
        {
            var item = Find(key);

            if (item == null)
                throw new KeyNotFoundException();

            Set.Remove(item);
        }
    }
}