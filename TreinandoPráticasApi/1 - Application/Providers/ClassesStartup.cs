using Microsoft.AspNetCore.WebSockets;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using TreinandoPráticasApi._4__Data;
using TreinandoPráticasApi.Configs.Filters;
using TreinandoPráticasApi.Repositories;
using TreinandoPráticasApi.Services;

namespace TreinandoPráticasApi.Providers
{
    public static class ClassesStartup
    {
        public static IServiceCollection AddDIPScoppedClasse(this IServiceCollection services)
        {
            services.AddScoped<SeedingServiceData>();
            services.AddScoped<IProduto, ProdutoService>();
            services.AddScoped<IUsuario, UsuarioService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ApiLoggingFilter>();

            return services;
        }
        public static IServiceCollection AddDIPSingletonClasse(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddDIPTransientClasse(this IServiceCollection services)
        {
            return services;
        }
    }
}
