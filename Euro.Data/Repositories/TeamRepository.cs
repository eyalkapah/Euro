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
    public class TeamRepository<TEntity> : BaseRepository<TEntity>, ITeamRepository<TEntity> where TEntity : Team
    {
        public TeamRepository(EuroContext context, IMemoryCache cache) : base(context, cache)
        {
        }

        Task ITeamRepository<TEntity>.AddAsync(TEntity input, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CancellationToken token = default, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<TEntity>> ITeamRepository<TEntity>.GetAllAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(CancellationToken token = default, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity item, CancellationToken token = default, params object[] keyValues)
        {
            throw new NotImplementedException();
        }
    }
}