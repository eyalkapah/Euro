using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.Domain.Interfaces.Repositories
{
    public interface ITeamRepository : IRepository<Team>
    {
        Task<IEnumerable<Group>> GetAllAsync(CancellationToken token = default);
    }
}