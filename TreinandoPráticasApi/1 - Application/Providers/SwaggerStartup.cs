using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.OpenApi.Models;
using System.Reflection;

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
                //Documentação do Swagger
                 c.SwaggerDoc("v1", new OpenApiInfo
                 {
                     Title = "EcommerceBackEnd",
                     Version = "v1",
                     Description = "E-commerce genérico",
                     Contact = new OpenApiContact
                     {
                         Name = "Otavio",
                         Email = "oaugusto265@gmail.com",
                         Url = new Uri("https://www.linkedin.com/in/otavio-augusto-a0a71b225/")
                     },
                     License =  new OpenApiLicense
                     {
                         Name = "Usar sobre LICX",
                         Url = new Uri("https://www.linkedin.com/in/otavio-augusto-a0a71b225/")
                     }
                 });
                                                //Retorna o assembly Retorna o nome do assembly e Name retorna o nome como uma string
                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //Adiciona os comentários XML ao swagger usando InxludeXmlComments
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
            }); 

            return service;
        }
    }
}
