using AutoMapper;
using Euro.Context;
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

        public GroupRepository(EuroContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<GroupApiModel>> GetAllGroupsAsync(CancellationToken token = default)
        {
            var groups = await GetAllAsync(token);

            foreach (var group in groups)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));

                // Set cache
            }

            var groupApiModels = _mapper.Map<IEnumerable<GroupApiModel>>(groups);

            return groupApiModels;
        }
    }
}