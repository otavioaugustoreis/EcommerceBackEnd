using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TreinandoPr�ticasApi._1___Application.Providers;
using TreinandoPr�ticasApi._4__Data;
using TreinandoPr�ticasApi.Configs.DTO;
using TreinandoPr�ticasApi.Configs.Filters;
using TreinandoPr�ticasApi.Configs.Logging;
using TreinandoPr�ticasApi.Configs.Providers;
using TreinandoPr�ticasApi.Data.Context;
using TreinandoPr�ticasApi.Exceptions;
using TreinandoPr�ticasApi.Logging;
using TreinandoPr�ticasApi.Providers;
using TreinandoPr�ticasApi.Repositories;
using TreinandoPr�ticasApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerStartup();
//Nome da politica criada
var OrigensComAcessoPermitido = "_origensComAcessoPermitido";

string file = Environment.GetEnvironmentVariable(@"LOG_FILE_PATH") ?? @"C:\Users\oaugu\source\repos\TreinandoPr�ticasApi\log.txt";

builder.Logging.AddConfigurationsLogger(file);

if (builder?.Logging == null)
{
    throw new InvalidOperationException("O sistema de logging n�o foi inicializado corretamente.");
}

var loggers = builder.Services.BuildServiceProvider()
    .GetRequiredService<ILoggerFactory>()
    .CreateLogger<Program>();

builder.Services.AddJWTAutorization(builder.Configuration ,loggers);
builder.Services.AddDIPScoppedClasse(loggers);
builder.Services.AddDIPSingletonClasse(loggers);
builder.Services.AddMapperStartup();
builder.Services.AddCofigurationJson();
builder.Services.AddCorsStartup(OrigensComAcessoPermitido);
string dbPassWord = Environment.GetEnvironmentVariable("DB_PASSWORD");

//Configurando conex�o com banco de dados
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection")
    .Replace("DB_PASSWORD", dbPassWord);

builder.Services.AddConectionBD(mySqlConnection);
builder.Services.AddIdentityConfiguration(loggers);


var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var seedingService = services.GetRequiredService<SeedingServiceData>();
        seedingService.Seeding(); // Executa o m�todo de seeding
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao executar o seeding: {ex.Message}");
    }
}

//Aqui fazemos as configura��es dos middlewares usando a vari�vel app
// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler(logger);
}


//Defino os middlewares para direcionar a aplica��o de http para https
app.UseHttpsRedirection();
//app.Use(async (context, next) =>
//        {
//            //adicionar c�digo antes do request
//            await next(context);
//            //Adicionar c�digo depois do request 
//        });

// Define o middleware de autoriza��o para verificar os acessos



app.UseStaticFiles();
app.UseRouting();
//Mapeamento dos controladores



//Usado apra adiconar um middleware terminal tambem
app.Use(async (context, next) =>
{
    logger.LogInformation("Requisi��o: {Method} {Path}, Headers: {Headers}", context.Request.Method, context.Request.Path, context.Request.Headers);
    await next();
    logger.LogInformation("Resposta: {StatusCode}", context.Response.StatusCode);
});

logger.LogInformation("Aplica��o iniciada em modo {Environment}.", app.Environment.EnvironmentName);

app.UseCors(OrigensComAcessoPermitido);
app.UseAuthorization();
app.MapControllers();
app.Run();
