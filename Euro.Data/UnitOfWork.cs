﻿using System.Threading;
using System.Threading.Tasks;
using Euro.ContextDb;
using Euro.Domain;
using Euro.Domain.Interfaces.Repositories;

namespace Euro.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EuroContext _context;

        public IGroupRepository<Group> Groups { get; set; }
        public IMatchRepository<Match> Matches { get; set; }
        public ITeamRepository<Team> Teams { get; set; }

        public UnitOfWork(EuroContext context, IGroupRepository<Group> groupRepository, ITeamRepository<Team> teamRepository, IMatchRepository<Match> matchRepository)
        {
            _context = context;

            Groups = groupRepository;
            Teams = teamRepository;
            Matches = matchRepository;
        }

        public async Task<bool> SaveAsync(CancellationToken token = default) => await _context.SaveChangesAsync(token) > 0;
    }
}