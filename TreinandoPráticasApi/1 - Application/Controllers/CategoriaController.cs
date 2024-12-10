using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using TreinandoPráticasApi._1___Application.Models;
using TreinandoPráticasApi.Configs.Filters;
using TreinandoPráticasApi.Entities;
using TreinandoPráticasApi.Repositories;
using TreinandoPráticasApi.RepositoriesPattern;

namespace TreinandoPráticasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase //, IControllerPattern<CategoriaModel>
    {

        private readonly ICategoria categoria;

        //Classe para acessar os arquivos JSON
        private readonly IConfiguration configuration;

        private readonly IMapper mapper;

        //Maneira mais padrão de inserir um loggin é pela interface ILogging
       // public readonly ILogger _logger;

        public CategoriaController(ICategoria categoria, IConfiguration configuration, IMapper mapper)
        {
            this.categoria = categoria;
            this.configuration = configuration;
            this.mapper = mapper;
        }


        ////Lendo arquivo de configuração
        //[HttpGet("Lendo arquivo de configuração")]
        //public string GetValores() 
        //{
        //    var valor1 = configuration["chave1"];
        //    var valor2 = configuration["secao1:chave1"];

        //    return $"{valor1} e {valor2}";
        //}

        //[HttpGet]
        ////Filtro está relacionado com o Logging!!
        //[ServiceFilter(typeof(ApiLoggingFilter))]
        //public ActionResult<IEnumerable<CategoriaModel>> Get()
        //{
        //    return Ok(categoria.Get());
        //}

        //[HttpGet("{id:int}")]
        //public IActionResult GetId(int id)
        //{
        //    //_logger.LogInformation("========== GET ID =========");
        //    CategoriaModel c1 = categoria.GetId(x => x.Id == id);
        //    if (c1 is null)
        //        return BadRequest("Categoria não encontrada");
            
        //    return Ok(c1);
        //}

        //[HttpPost]
        //public ActionResult<CategoriaModel> Post(CategoriaModel entidade)
        //{
        //    if (entidade is null) return BadRequest();

        //    categoria.Post(entidade);
        //    return new CreatedAtRouteResult("GetCategoriaById", new { id = entidade.Id }, entidade);
        //}


        //[HttpPut("{id:int:min(1)}")]
        //public ActionResult<CategoriaModel> Put(int id, CategoriaModel t)
        //{
        //    CategoriaModel c1 = categoria.GetId(c => c.Id == id);
        //    if (c1 is null || t is null)
        //        return BadRequest("Categoria não encontrada");

        //    return Ok(categoria.Put(t));
        //}

        //[HttpPut("{id:int:min(1)}")]
        //public ActionResult<CategoriaModel> Delete(int id)
        //{
        //    CategoriaModel c1 = categoria.GetId(c => c.Id == id);
        //    if (c1 is null)
        //        return BadRequest("Categoria não encontrada");

        //    return Ok(categoria.Delete(c1));

        //}
    }
}
