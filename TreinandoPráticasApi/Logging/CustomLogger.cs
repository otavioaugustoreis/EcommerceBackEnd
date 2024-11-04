
namespace TreinandoPráticasApi.Logging
{
    public class CustomLogger : ILogger
    {
        private readonly string loggerName;

        private readonly CustomLoggerProviderConfiguration loggerConfig;

        public CustomLogger(string loggerName, CustomLoggerProviderConfiguration loggerConfig)
        {
            this.loggerName = loggerName;
            this.loggerConfig = loggerConfig;
        }

        //Verifica se o nivel(Warning) de log desejado esta habilitado para a configuração
        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == loggerConfig.LogLevel;
        }

        //Permite criar o escopo para mensagens de log
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
           return null;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            //Formatando a mensagem
            string mensagem = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";
            EscreverTextoNoArquivo(mensagem);
        }

        private void EscreverTextoNoArquivo(string mensgem)
        {
            //escrevendo o log a onde eu pedi no arquivo
            string caminhoArquivoLog = @"C:\Users\oaugu\source\repos\otavioaugustoreis\ApiDeProdutos\logs\log.txt";

            using (StreamWriter streamWriter =  new StreamWriter(caminhoArquivoLog, true))
            {
                try
                {
                    streamWriter.WriteLine(mensgem);
                    streamWriter.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
