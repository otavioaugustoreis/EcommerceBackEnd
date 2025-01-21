using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace TreinandoPráticasApi._1___Application.Providers
{
    public static class RateLimitingStartup
    {
        public static IServiceCollection AddRateLimiting(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                //Definir algoritmo de limitação de taxa


                /*Algoritmo limitador de janela fixa, divide o tempo em janelas fixas e permite um numero fixo de requests dentro de uma janela
                 de tempo especifica e todos os request subsequerentes são postergados*/
                options.AddFixedWindowLimiter("fixed", options =>
                {
                    //Numero máximo de requisições durante a janeça fixada
                    options.PermitLimit = 3;
                    //Defino o tempo que a requisição vai ser contada, ou seja permite 3 requests a cada 10 seg
                    options.Window = TimeSpan.FromSeconds(10);
                    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    options.QueueLimit = 1;
                });
                //Define o cód retornado caso ele extrapole a quantidade fornecida por request(3)
                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

                //Configurando o RateLimiting globalmente para janela fixa
                //options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpcontext =>
                //{
                //    RateLimitPartition.GetFixedWindowLimiter(
                //            partitionKey: httpcontext.User.Identity?.Name ??
                //                           httpcontext.Request.Headers.Host.ToString(),
                //            factory: partition => new FixedWindowRateLimiterOptions
                //            {
                //                AutoReplenishment = true,
                //                PermitLimit = 5,
                //                QueueLimit = 0,
                //                Window = TimeSpan.FromSeconds(10)
                //            });
                //});
            });


            return services;
        }
    }
}
