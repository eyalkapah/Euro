using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Euro.Context;
using Euro.Domain.Interfaces.Repositories;

namespace Euro.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EuroContext _context;

        public IGroupRepository Groups { get; set; }

        public UnitOfWork(EuroContext context, IGroupRepository groupRepository)
        {
            _context = context;

            Groups = groupRepository;
        }

        public async Task<bool> SaveAsync(CancellationToken token = default) => await _context.SaveChangesAsync(token) > 0;
    }
}