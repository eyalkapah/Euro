using Euro.Context;
using Euro.Domain;
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
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(EuroContext context, IMemoryCache cache) : base(context, cache)
        {
        }

        public async Task<IEnumerable<Group>> ITeamRepository.GetAllAsync(CancellationToken token)
        {
            var teams = await GetAllAsync(token);

            foreach (var team in teams)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));

                Cache.Set(team.TeamId, team, cacheEntryOptions);
            }

            return teams;
        }
    }
}