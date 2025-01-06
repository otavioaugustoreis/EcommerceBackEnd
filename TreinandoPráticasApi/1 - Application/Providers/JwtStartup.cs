namespace TreinandoPráticasApi._1___Application.Providers
{
    public static class JwtStartup
    {
        public static IServiceCollection AddJWTAutorization(this IServiceCollection service, ILogger loggers)
        {

            loggers.LogInformation("Incluindo autorização e autenticação do token");

            service.AddAuthorization();
            service.AddAuthentication("Bearer").AddJwtBearer();

            return service;
        }
    }
}
