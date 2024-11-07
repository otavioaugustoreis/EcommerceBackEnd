﻿using TreinandoPráticasApi.Logging;

namespace TreinandoPráticasApi.Providers
{
    public static class LoggerStartup
    {

        public static ILoggingBuilder AddConfigurationsLogger(this ILoggingBuilder logging)
        {
            logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
            {
                LogLevel = LogLevel.Information
            }));

            return logging;
        }
    }
}
