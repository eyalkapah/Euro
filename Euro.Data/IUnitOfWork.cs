using Euro.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.Data
{
    public interface IUnitOfWork
    {
        IGroupRepository Groups { get; set; }

        Task<bool> SaveAsync(CancellationToken token = default);
    }
}