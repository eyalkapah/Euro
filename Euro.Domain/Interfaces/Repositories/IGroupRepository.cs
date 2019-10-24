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
        Task<IEnumerable<Group>> GetAllGroupsAsync(CancellationToken token = default);

        Task<Group> GetGroupByIdAsync(int id, CancellationToken token = default);

        Task AddGroupAsync(Group input, CancellationToken token);

        Task UpdateGroupAsync(int id, Group group, CancellationToken token = default);
    }
}