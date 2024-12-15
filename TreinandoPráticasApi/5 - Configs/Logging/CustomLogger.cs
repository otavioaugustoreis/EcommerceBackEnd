
using TreinandoPráticasApi.Configs.Logging;

namespace TreinandoPráticasApi.Logging
{
    public class CustomLogger : ILogger
    {
        private readonly string loggerName;

        private readonly CustomLoggerProviderConfiguration loggerConfig;
        private readonly string caminhoArquivoLog;
        public CustomLogger(string loggerName, CustomLoggerProviderConfiguration loggerConfig, string caminhoArquivo)
        {
            this.loggerName = loggerName;
            this.loggerConfig = loggerConfig;
            this.caminhoArquivoLog = caminhoArquivo;
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
            string mensagem = formatter(state, exception);

            // Detalha o log se houver exceção
            if (exception != null)
            {
                mensagem += $"\nExceção: {exception.Message}\n" +
                            $"Rastreamento: {exception.StackTrace}";
            }

            EscreverTextoNoArquivo($"{logLevel}: {eventId.Id} - {mensagem}");
        }

        private void EscreverTextoNoArquivo(string mensagem)
        {
            using (StreamWriter streamWriter = new StreamWriter(caminhoArquivoLog, true))
            {
                try
                {
                    streamWriter.WriteLine($"[{DateTime.Now}] {mensagem}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao escrever no log: {ex.Message}");
                }
            }
        }
    }
}
