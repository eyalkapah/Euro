using Euro.Context.Configurations;
using Euro.ContextDb.Configurations;
using Euro.ContextDb.Models;
using Euro.ContextDb.Seeders;
using Euro.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Euro.ContextDb
{
    public class EuroContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }

        public EuroContext(DbContextOptions<EuroContext> options) : base(options)
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