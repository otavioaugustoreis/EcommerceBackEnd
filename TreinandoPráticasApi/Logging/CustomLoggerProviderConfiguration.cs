namespace TreinandoPráticasApi.Logging
{
    public class CustomLoggerProviderConfiguration
    {
        // Define o nivel mínimo de log a ser registrado, com o padreão LogLevel.Warning
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;

        //Define o Id do evento de log, com o padrão sendo 0
        public  int  EventId { get; set; }
    }
}
