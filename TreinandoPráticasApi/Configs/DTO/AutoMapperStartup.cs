using System.Security.Policy;
using TreinandoPráticasApi.DTO;

namespace TreinandoPráticasApi.Configs.DTO
{
    public static class AutoMapperStartup 
    {
        public static IServiceCollection AddMapperStartup(this IServiceCollection services) 
        {
            services.AddAutoMapper(typeof(DomainDTOMappingProfile));

            return services;
        }
    }
}
