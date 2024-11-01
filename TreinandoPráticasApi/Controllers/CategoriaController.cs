using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using TreinandoPráticasApi.Entities;
using TreinandoPráticasApi.Filters;
using TreinandoPráticasApi.Repositories;
using TreinandoPráticasApi.RepositoriesPattern;

namespace TreinandoPráticasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase, IControllerPattern<CategoriaEntity>
    {

        private readonly ICategoria categoria;

        private readonly IConfiguration configuration;

        //Maneira mais padrão de inserir um loggin é pela interface ILogging
        public readonly ILogger _logger;

        public CategoriaController(ICategoria categoria, IConfiguration configuration, ILogger<CategoriaController> logger)
        {
            this.categoria = categoria;
            this.configuration = configuration;
            this. _logger = logger;
        }


        //Lendo arquivo de configuração
        [HttpGet("Lendo arquivo de configuração")]
        public string GetValores() 
        {
            var valor1 = configuration["chave1"];
            var valor2 = configuration["secao1:chave1"];

            return $"{valor1} e {valor2}";
        }

        [HttpGet]
        //Filtro está relacionado com o Logging!!
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public ActionResult<IEnumerable<CategoriaEntity>> Get()
        {
            return Ok(categoria.Get());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetId(int id)
        {

            _logger.LogInformation("========== GET ID =========");
            CategoriaEntity c1 = categoria.GetId(x => x.Id == id);
            if (c1 is null)
                return BadRequest("Categoria não encontrada");
            
            return Ok(c1);
        }

        [HttpPost]
        public ActionResult<CategoriaEntity> Post(CategoriaEntity entidade)
        {
            if (entidade is null) return BadRequest();

            categoria.Post(entidade);
            return new CreatedAtRouteResult("GetCategoriaById", new { id = entidade.Id }, entidade);
        }


        [HttpPut("{id:int:min(1)}")]
        public ActionResult<CategoriaEntity> Put(int id, CategoriaEntity t)
        {
            CategoriaEntity c1 = categoria.GetId(c => c.Id == id);
            if (c1 is null || t is null)
                return BadRequest("Categoria não encontrada");

            return Ok(categoria.Put(t));
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult<CategoriaEntity> Delete(int id)
        {
            CategoriaEntity c1 = categoria.GetId(c => c.Id == id);
            if (c1 is null)
                return BadRequest("Categoria não encontrada");

            return Ok(categoria.Delete(c1));

        }
    }
}
