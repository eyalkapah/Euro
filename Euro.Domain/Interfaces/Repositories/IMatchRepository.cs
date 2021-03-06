﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.Domain.Interfaces.Repositories
{
    public interface IMatchRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<Match>> GetByTeamIdAsync(CancellationToken token, params object[] keyValues);
    }
}