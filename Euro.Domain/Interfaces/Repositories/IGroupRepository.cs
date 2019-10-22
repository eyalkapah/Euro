using Euro.Domain.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.Domain.Interfaces.Repositories
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<IEnumerable<GroupApiModel>> GetAllGroupsAsync(CancellationToken token = default);
    }
}