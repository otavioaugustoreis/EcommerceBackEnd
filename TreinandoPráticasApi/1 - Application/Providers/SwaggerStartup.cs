using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.OpenApi.Models;

namespace TreinandoPráticasApi._1___Application.Providers
{
    public static  class SwaggerStartup
    {
        //Configuração do swagger para receber o token jwt
        public static IServiceCollection AddSwaggerStartup(this IServiceCollection service)
        {
            service.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,//Autenticação feit apor chave api
                    Scheme = "Bearer",//Especifica o portador do token
                    BearerFormat = "JWT",//Tipo do token/formato
                    In = ParameterLocation.Header,// especifica que o token deve ser incluso no request
                    Description = "Bearer JWT"
                });
                //Configurando um esquema de segurança que as requisições são feitas por uma segurança do tipo Bearer
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }                    
                });
            }); 

            return service;
        }
    }
}
