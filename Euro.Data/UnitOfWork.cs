using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Euro.Context;
using Euro.Domain;
using Euro.Domain.Interfaces.Repositories;

namespace Euro.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EuroContext _context;

        public IGroupRepository<Group> Groups { get; set; }
        public ITeamRepository<Team> Teams { get; set; }

        public UnitOfWork(EuroContext context, IGroupRepository<Group> groupRepository, ITeamRepository<Team> teamRepository)
        {
            _context = context;

            Groups = groupRepository;
            Teams = teamRepository;
        }

        public async Task<bool> SaveAsync(CancellationToken token = default) => await _context.SaveChangesAsync(token) > 0;
    }
}