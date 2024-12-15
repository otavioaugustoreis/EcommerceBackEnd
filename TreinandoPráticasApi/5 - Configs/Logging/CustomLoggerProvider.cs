using System.Collections.Concurrent;
using TreinandoPráticasApi.Logging;

namespace TreinandoPráticasApi.Configs.Logging
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        //Define a configuração para todos os logs criados
        private readonly CustomLoggerProviderConfiguration loggerConfig;

        //Dicionário de loggers
        private readonly ConcurrentDictionary<string, CustomLogger> loggers =
                                              new ConcurrentDictionary<string, CustomLogger>();
        public CustomLoggerProvider(CustomLoggerProviderConfiguration loggerConfig)
        {
            this.loggerConfig = loggerConfig;
        }

        //Usado para criar o log para  uma categoria existente
        public ILogger CreateLogger(string categoryName)
        {
            return loggers.GetOrAdd(categoryName, name => new CustomLogger(name, loggerConfig, loggerConfig.LogFile));
        }

        //Liberando recursos após a aplicação fechar
        public void Dispose()
        {
            loggers.Clear();
        }
    }
}
