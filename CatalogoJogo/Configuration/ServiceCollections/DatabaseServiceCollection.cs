using CatalogoJogo.Domain.JogoContext.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogoJogo.Configuration.ServiceCollection
{
    public static class DatabaseServiceCollection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<JogoDataContext>(options =>
            {
                options.UseInMemoryDatabase("JogoDatabase");
            });

            return services;
        }
    }
}