using Application.Interfaces;
using Application.Services;

namespace CastGroupAPI.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AdicionarDependencias(this WebApplicationBuilder builder)
        {
            IServiceCollection services = builder.Services;

            services.AddTransient<IEnderecoService, EnderecoService>();

            return services;
        }
    }
}