using Euro.Domain.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.Domain.Interfaces.Repositories
{
    public interface IGroupRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        //Task AddAsync(TEntity input, CancellationToken token);

        //Task DeleteAsync(CancellationToken token = default, params object[] keyValues);

        //Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token = default);

        //Task<TEntity> GetByIdAsync(CancellationToken token = default, params object[] keyValues);

        //Task UpdateAsync(TEntity item, CancellationToken token = default, params object[] keyValues);
    }
}