using TreinandoPráticasApi.Configs.Logging;
using TreinandoPráticasApi.Logging;

namespace TreinandoPráticasApi.Configs.Providers
{
    public static class LoggerStartup
    {

        public static ILoggingBuilder AddConfigurationsLogger(this ILoggingBuilder logging, string file)
        {

            logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
            {
                LogLevel = LogLevel.Information,
                LogFile = file,
            }));

            return logging;
        }


   
    }
}
