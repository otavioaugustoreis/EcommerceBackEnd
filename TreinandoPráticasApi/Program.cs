using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using TreinandoPráticasApi.Context;
using TreinandoPráticasApi.Exceptions;
using TreinandoPráticasApi.Filters;
using TreinandoPráticasApi.Logging;
using TreinandoPráticasApi.Providers;
using TreinandoPráticasApi.Repositories;
using TreinandoPráticasApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adiciona o provedor de log personalizado(CustomLoggerProvider) ao sistema de log do ASP.NET Core, 
//definindo o nível mínimo de log como o logLevel.Information
builder.Logging.AddConfigurationsLogger();

builder.Services.AddConfigurationJson();

//Configurando conexão com banco de dados
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddConectionBD(mySqlConnection);

//Configurando injeção de dependência
builder.Services.AddDIPScoppedClasse();

var app = builder.Build();

//Aqui fazemos as configurações dos middlewares usando a variável app
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();
}


//Defino os middlewares para direcionar a aplicação de http para https
app.UseHttpsRedirection();
//app.Use(async (context, next) =>
//        {
//            //adicionar código antes do request
//            await next(context); 
//            //Adicionar código depois do request 
//        });
// Define o middleware de autorização para verificar os acessos
app.UseAuthorization();
//Mapeamento dos controladores
app.MapControllers();
//Usado apra adiconar um middleware terminal tambem
app.Run();
