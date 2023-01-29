using AppointmentManagement.Application.Contracts.Persistence;
using AppointmentManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services
            , IConfiguration configuration)
        {
            services.AddDbContext<AppointmentManagementDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString
                    ("AppointmentManagementConnectionString")));
            // .EnableSensitiveDataLogging());

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<IAgentAvailabilityRepository, AgentAvailabilityRepository>();
            return services;
        }
    }
}
