using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.Domain.Interfaces.Repositories
{
    public interface ITeamRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<Team>> GetTeamsByGroupIdAsync(CancellationToken token, params object[] keyValues);
    }
}