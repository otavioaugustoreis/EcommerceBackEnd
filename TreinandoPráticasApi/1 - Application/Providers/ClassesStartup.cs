using Microsoft.AspNetCore.WebSockets;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using TreinandoPráticasApi._4__Data;
using TreinandoPráticasApi.Configs.Filters;
using TreinandoPráticasApi.Logging;
using TreinandoPráticasApi.Repositories;
using TreinandoPráticasApi.Repositories.UnitOfWork;
using TreinandoPráticasApi.Services;

namespace TreinandoPráticasApi.Providers
{
    public static class ClassesStartup
    {
        public static IServiceCollection AddDIPScoppedClasse(this IServiceCollection services, ILogger logger)
        {
            logger.LogInformation("Registrando dependências com AddDIPScoppedClasse.");

            services.AddScoped<SeedingServiceData>();
            logger.LogInformation("Serviço {ServiceName} registrado.", nameof(SeedingServiceData));

            services.AddScoped<IProduto, ProdutoService>();
            logger.LogInformation("Serviço {ServiceName} registrado.", nameof(IProduto));

            services.AddScoped<IUsuario, UsuarioService>();
            logger.LogInformation("Serviço {ServiceName} registrado.", nameof(IUsuario));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            logger.LogInformation("Serviço genérico {ServiceName} registrado.", "IRepository<>");

            services.AddScoped<ApiLoggingFilter>();
            logger.LogInformation("Filtro de API registrado: {FilterName}", nameof(ApiLoggingFilter));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            logger.LogInformation("Serviço {ServiceName} registrado.", nameof(IUnitOfWork));


            return services;
        }
        public static IServiceCollection AddDIPSingletonClasse(this IServiceCollection services, ILogger logger)
        {
            logger.LogInformation("Registrando dependências Singletons");


            return services;
        }

        public static IServiceCollection AddDIPTransientClasse(this IServiceCollection services)
        {
            return services;
        }
    }
}
