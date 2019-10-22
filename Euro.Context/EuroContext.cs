using Euro.Context.Configurations;
using Euro.Context.Migrations.Seeders;
using Euro.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Euro.Context
{
    public class EuroContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Match> Matches { get; set; }

        public EuroContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new TeamConfiguration());
            builder.ApplyConfiguration(new GroupConfiguration());
            builder.ApplyConfiguration(new MatchConfiguration());

            builder.SeedGroups();
            builder.SeedTeams();
            builder.SeedMatches();
        }
    }
}