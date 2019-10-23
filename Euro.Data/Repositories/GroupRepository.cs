using AutoMapper;
using Euro.Context;
using Euro.Data.Exceptiona;
using Euro.Domain;
using Euro.Domain.ApiModels;
using Euro.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.Data.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GroupRepository(EuroContext context, IMapper mapper, IMemoryCache cache) : base(context)
        {
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Group> AddGroupAsync(GroupApiModel input, CancellationToken token)
        {
            if (await IsExistsAsync(g => g.Name.Equals(input.Name, StringComparison.CurrentCultureIgnoreCase)))
            {
                throw new DuplicateValueException(nameof(input.Name), input.Name);
            }

            var group = _mapper.Map<Group>(input);

            await AddAsync(group, token);

            return group;
        }

        public async Task<IEnumerable<GroupApiModel>> GetAllGroupsAsync(CancellationToken token = default)
        {
            var groups = await GetAllAsync(token);

            foreach (var group in groups)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));

                _cache.Set(group.GroupId, group, cacheEntryOptions);
            }

            var groupApiModels = _mapper.Map<IEnumerable<GroupApiModel>>(groups);

            return groupApiModels;
        }

        public async Task<GroupApiModel> GetGroupByIdAsync(int id, CancellationToken token = default)
        {
            var group = _cache.Get<Group>(id);

            if (group != null)
            {
                var groupApiModel = _mapper.Map<GroupApiModel>(group);
                return groupApiModel;
            }
            else
            {
                group = await FindAsync(token, id);

                var groupApiModel = _mapper.Map<GroupApiModel>(group);

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));

                _cache.Set(groupApiModel.GroupId, group, cacheEntryOptions);

                return groupApiModel;
            }
        }
    }
}