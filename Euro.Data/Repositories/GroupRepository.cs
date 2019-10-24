using Euro.Context;
using Euro.Data.Exceptiona;
using Euro.Domain;
using Euro.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.Data.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(EuroContext context, IMemoryCache cache) : base(context, cache)
        {
        }

        public async Task<IEnumerable<Group>> GetAllGroupsAsync(CancellationToken token = default)
        {
            var groups = await GetAllAsync(token);

            foreach (var group in groups)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));

                Cache.Set(group.GroupId, group, cacheEntryOptions);
            }

            return groups;
        }

        public async Task<Group> GetGroupByIdAsync(int id, CancellationToken token = default)
        {
            var group = Cache.Get<Group>(id);

            if (group != null)
            {
                return group;
            }
            else
            {
                group = await FindAsync(token, id);

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));

                Cache.Set(id, group, cacheEntryOptions);

                return group;
            }
        }

        public async Task AddGroupAsync(Group group, CancellationToken token)
        {
            if (await IsExistsAsync(g => g.Name.ToLower() == group.Name.ToLower()))
            {
                throw new DuplicateValueException(nameof(group.Name), group.Name);
            }

            await AddAsync(group, token);
        }

        public async Task UpdateGroupAsync(int id, Group group, CancellationToken token = default)
        {
            if (await IsExistsAsync(g => g.Name.ToLower() == group.Name.ToLower() && g.GroupId != id, token))
            {
                throw new AlreadyExistsException(group.Name);
            }

            group.GroupId = id;

            Update(group);
        }
    }
}