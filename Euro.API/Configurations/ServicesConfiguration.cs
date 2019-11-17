using Euro.Data;
using Euro.Data.Repositories;
using Euro.Domain;
using Euro.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Euro.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static void AddCaching(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddResponseCaching();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGroupRepository<Group>, GroupRepository<Group>>();
            services.AddScoped<ITeamRepository<Team>, TeamRepository<Team>>();
            services.AddScoped<IMatchRepository<Match>, MatchRepository<Match>>();
        }

        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}