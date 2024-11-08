using System.Text.Json.Serialization;

namespace TreinandoPráticasApi.Configs.Providers
{
    public static class JsonStartup
    {
        //Ignorando referência ciclica
        public static IServiceCollection AddCofigurationJson(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            return services;
        }
    }
}
