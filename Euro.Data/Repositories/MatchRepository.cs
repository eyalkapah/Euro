using Euro.ContextDb;
using Euro.Data.Exceptions;
using Euro.Domain;
using Euro.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.Data.Repositories
{
    public class MatchRepository<TEntity> : BaseRepository<TEntity>, IMatchRepository<TEntity> where TEntity : Match
    {
        public MatchRepository(EuroContext context, IMemoryCache cache) : base(context, cache)
        {
        }

        public new async Task AddAsync(TEntity item, CancellationToken token) => await base.AddAsync(item, token);

        public async Task DeleteAsync(CancellationToken token = default, params object[] keyValues)
        {
            var item = await GetByIdAsync(token, keyValues);

            if (item == null)
            {
                throw new KeyNotFoundException();
            }

            Delete(item);
        }

        public new async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token = default)
        {
            var items = await base.GetAllAsync(token);

            foreach (var item in items)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));

                Cache.Set(item.MatchId, item, cacheEntryOptions);
            }

            return items;
        }

        public async Task<TEntity> GetByIdAsync(CancellationToken token = default, params object[] keyValues)
        {
            var item = Cache.Get<TEntity>(keyValues);

            if (item != null)
            {
                return item;
            }
            else
            {
                item = await FindAsync(token, keyValues);

                if (item == null)
                    throw new NotFoundException();

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));

                Cache.Set(keyValues, item, cacheEntryOptions);

                return item;
            }
        }

        public async Task<IEnumerable<Match>> GetByTeamIdAsync(CancellationToken token, params object[] keyValues)
        {
            int.TryParse(keyValues[0].ToString(), out int teamId);

            var matches = await GetAllAsync(token);

            return matches.Where(t => t.HostTeamId == teamId || t.GuestTeamId == teamId);
        }

        public Task UpdateAsync(TEntity item, CancellationToken token = default, params object[] keyValues)
        {
            var id = (int)keyValues[0];

            item.MatchId = id;

            return Task.FromResult(Update(item));
        }
    }
}