using Euro.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Euro.API.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = string.Empty;

            connection = configuration.GetConnectionString("EuroDb");

            services.AddDbContext<EuroContext>(services => services.UseSqlServer(connection));

            return services;
        }
    }
}