using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Application.Commons.Interfaces;
using ToDoApp.Infrastructure.Persistence;
using ToDoApp.Infrastructure.Persistence.Interceptors;
using ToDoApp.Infrastructure.Services;

namespace ToDoApp.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureService
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString: configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IGuidGenerator, GuidGeneratorService>();

            return services;
        }
    }
}
