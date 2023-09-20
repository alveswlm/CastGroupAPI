using Application.Interfaces;
using Application.Services;
using Infra.Data.Context;

namespace CastGroupAPI.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AdicionarDependencias(this WebApplicationBuilder builder)
        {
            IServiceCollection services = builder.Services;

            services.AddTransient<ContaDbContext>();
            services.AddTransient<IContaService, ContaService>();

            return services;
        }
    }
}