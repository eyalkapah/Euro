﻿using Euro.ContextDb;
using Euro.Data.Exceptions;
using Euro.Domain;
using Euro.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.Data.Repositories
{
    public class GroupRepository<TEntity> : BaseRepository<TEntity>, IGroupRepository<TEntity> where TEntity : Group
    {
        public GroupRepository(EuroContext context, IMemoryCache cache) : base(context, cache)
        {
        }

        public new async Task AddAsync(TEntity item, CancellationToken token)
        {
            if (await IsExistsAsync(g => g.Name.ToLower() == item.Name.ToLower()))
            {
                throw new DuplicateValueException(nameof(item.Name), item.Name);
            }

            await base.AddAsync(item, token);
        }

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

                Cache.Set(item.GroupId, item, cacheEntryOptions);
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

        public async Task UpdateAsync(TEntity item, CancellationToken token = default, params object[] keyValues)
        {
            var id = (int)keyValues[0];

            if (await IsExistsAsync(g => g.Name.ToLower() == item.Name.ToLower() && g.GroupId != id, token))
            {
                throw new AlreadyExistsException(item.Name);
            }

            item.GroupId = id;

            Update(item);
        }
    }
}