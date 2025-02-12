﻿

using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace TreinandoPráticasApi.Exceptions
{
    public static class ApiExceptionMiddlewareExtesions
    {
 
        // Classe para configuração de Exceção global, caso haja
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            //Configurando o middleware de tratamento de exceções 

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    //Definindo status code caso haja uma exceção
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    //Resposta no formato Json
                    context.Response.ContentType = "application/json";

                    //Feature de manipulação de exceções
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    //Verificando se uma exceção ocorreu
                    if (contextFeature != null)
                    {
                        // Log detalhado da exceção
                        logger.LogError($"Erro: {contextFeature.Error.Message}\n" +
                                        $"Código HTTP: {context.Response.StatusCode}\n" +
                                        $"Rastreamento: {contextFeature.Error.StackTrace}");

                        // Resposta de erro para o cliente
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
