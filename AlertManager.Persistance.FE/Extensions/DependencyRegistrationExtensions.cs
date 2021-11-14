using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlertManager.Persistance.EF.Extensions
{
    public static class DependencyRegistrationExtensions
    {
        public static IServiceCollection RegisterPersistanceEF(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AlertManagerContext>(c => c.UseSqlServer(
                configuration.GetConnectionString("AlertManagerDbConnectionString")));

            return services;
        }
    }
}
