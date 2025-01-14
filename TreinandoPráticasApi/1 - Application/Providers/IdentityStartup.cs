using Microsoft.AspNetCore.Identity;
using TreinandoPráticasApi.Data.Context;

namespace TreinandoPráticasApi._1___Application.Providers
{
    public static class IdentityStartup
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, ILogger logger)
        {
            logger.LogInformation("Adicionando configurações do Identity");

            //Configurando o Identity
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<AppDbContext>()
            //    .AddDefaultTokenProviders();
            return services;
        }
    }
}
