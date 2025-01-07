using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TreinandoPráticasApi._1___Application.Providers
{
    public static class JwtStartup
    {
        public static IServiceCollection AddJWTAutorization(this IServiceCollection service, IConfiguration configuration, ILogger loggers)
        {
            loggers.LogInformation("Incluindo autorização e autenticação do token");

            var secretKey = configuration["JWT:SecretKey"]
                            ?? throw new ArgumentException("Invalid secret key!!");

            service.AddAuthorization();
            //Configurando autenticação
            service.AddAuthentication(options =>
            {
                //Configurando que por padrão o sistema de autenticação vai usar o token JWT para verificação
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //Caso alguem tente acessar algo sem fornecer o token  a aplicação vai lançar o "desafio" que seria solicitar para o usuário para fazer o login
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                //Em produção é true e indica se é https 
                options.RequireHttpsMetadata = false;
                //Classe para configurar os parametros de configuração do token
                options.TokenValidationParameters = new()
                {
                    //Valida o emissor a audiencia e a validade do token
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    //Valida a chave de assinatura
                    ValidateIssuerSigningKey = true,
                    //Ajusta o tempo entre o servidor de aplicação e de autenticação para não haver nenhum delay
                    ClockSkew = TimeSpan.Zero,
                    //Dando valores a audiência e ao emissor
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                                        Encoding.UTF8.GetBytes(secretKey))
                };
            });

            

            return service;
        }
    }
}
