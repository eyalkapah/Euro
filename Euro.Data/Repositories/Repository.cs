using Euro.Context;
using Euro.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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

        public bool Delete(object[] keyValues)
        {
            var item = Find(keyValues);

            if (item == null)
                return false;

            _context.Entry(item).State = EntityState.Deleted;

            return true;
        }

        public void Delete(TEntity item)
        {
            _context.Entry(item).State = EntityState.Deleted;
        }

        public bool Delete<TKey>(TKey key)
        {
            var item = Find(key);

            if (item == null)
                return false;

            _context.Entry(item).State = EntityState.Deleted;

            return true;
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

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Set.ToList();
        }
    }
}