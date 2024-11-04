using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TreinandoPráticasApi.Context;
using TreinandoPráticasApi.Exceptions;
using TreinandoPráticasApi.Filters;
using TreinandoPráticasApi.Logging;
using TreinandoPráticasApi.Repositories;
using TreinandoPráticasApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adiciona o provedor de log personalizado(CustomLoggerProvider) ao sistema de log do ASP.NET Core, 
//definindo o nível mínimo de log como o logLevel.Information
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
{
    LogLevel = LogLevel.Information
}));

//Ignorando referência ciclica com JSON
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

//Configurando conexão com banco de dados
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

//Conexão com o banco
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(
        mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)
  ));

var valor1 = builder.Configuration["chave1"];

//Vai criar uma instancia unica por request
builder.Services.AddScoped<IProduto, ProdutoService>();
builder.Services.AddScoped<IUsuario, UsuarioService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ApiLoggingFilter>();


var app = builder.Build();

//Aqui fazemos as configurações dos middlewares usando a variável app
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();
}


//Defino os middlewares para direcionar a aaplicação de http para https
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
