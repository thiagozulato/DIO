using CatalogoJogo.Application.JogoContext.Services;
using CatalogoJogo.Domain.JogoContext.Infra;
using CatalogoJogo.Domain.JogoContext.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogoJogo.Configuration.Dependencias
{
    public static class RegistrarDependencias
    {
        public static IServiceCollection AddDependencias(this IServiceCollection services)
        {
            services.AddScoped<IJogoService, JogoService>();
            services.AddScoped<IJogoRepository, JogoRepository>();

            return services;
        }
    }
}