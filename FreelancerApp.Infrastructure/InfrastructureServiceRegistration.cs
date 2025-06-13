using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FreelancerApp.Infrastructure.Data;
using FreelancerApp.Infrastructure.Services;
using FreelancerApp.Application.Interfaces;

namespace FreelancerApp.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register the DbContext using SQLite (or change to SQL Server if needed)
            services.AddDbContext<FreelancerDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("FreelancerApp.Infrastructure")));

            // Register application services
            services.AddScoped<IFreelancerService, FreelancerService>();

            return services;
        }
    }
}
