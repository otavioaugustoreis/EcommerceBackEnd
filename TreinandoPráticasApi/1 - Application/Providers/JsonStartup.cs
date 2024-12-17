using System.Text.Json.Serialization;
using TreinandoPráticasApi.Exceptions;

namespace TreinandoPráticasApi.Configs.Providers
{
    public static class JsonStartup
    {
        //Ignorando referência ciclica
        public static object AddCofigurationJson(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            })

            return services;
        }
    }
}
