using System.Security.Policy;
using TreinandoPráticasApi._1___Application.Models;

namespace TreinandoPráticasApi.Configs.DTO
{
    public static class AutoMapperStartup 
    {
        public static IServiceCollection AddMapperStartup(this IServiceCollection services) 
        {
            services.AddAutoMapper(typeof(DomainModelMappingProfile));

            return services;
        }
    }
}
