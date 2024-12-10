using Microsoft.AspNetCore.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using System.Net;

namespace TreinandoPráticasApi.Exceptions
{
    public static class ApiExceptionMiddlewareExtesions
    {
        // Classe para configuração de Exception
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            //Configurando o middleware de tratamento de exceções 
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    //Definindo status caso haja uma exceção
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    //Resposta no formato Json
                    context.Response.ContentType = "application/json";

                    //Feature de manipulação de exceções
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    
                    //Verificando se uma seção ocorreu
                    if(contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Trace = contextFeature.Error.StackTrace
                        }.ToString());
                    }
                });
            });

        }
    }
}
