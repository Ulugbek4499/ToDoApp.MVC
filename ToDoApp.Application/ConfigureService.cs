using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Application.Commons.Behaviours;

namespace ToDoApp.Application
{
    public static class ConfigureService
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
                config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });

            return services;
        }
    }
}
