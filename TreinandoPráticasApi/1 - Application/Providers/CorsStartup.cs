namespace TreinandoPráticasApi._1___Application.Providers
{
    public static  class CorsStartup
    {

        public static IServiceCollection AddCorsStartup(this IServiceCollection services, string OrigensComAcessoPermitido)
        {

            services.AddCors(options =>
            {
                //Adicionando politicas personalizadas
                options.AddPolicy(name: OrigensComAcessoPermitido, policy =>
                {
                    //mostranso quais origens tem permissão para 
                    policy.WithOrigins("http://www.apirequest.io");
                    //Permite cors de todas as origens
                    //poliy.AllowAnyOrigin()
                    //Permite qualquer método http(GET, POST, PUT, DELETE)
                    //policy.WithOrigins("http://www.apirequest.io").AllowAnyMethod()
                    //Restringe os verbos http
                    //policy.WithOrigins("http://www.apirequest.io").WithMethods("GET", "POST");
                    // Permite as credenciais entre as origens
                    //policy.WithOrigins("http://www.apirequest.io").AllowCredentiais();;
                });

                //Adicionando uma Policy padrão, ou seja, não precisa de um nome
                //options.AddDefaultPolicy( policy =>
                //{
                //    //mostranso quais origens tem permissão para 
                //    policy.WithOrigins("http://www.apirequest.io");
                //});
            });

            return services;
        }
    }
}
