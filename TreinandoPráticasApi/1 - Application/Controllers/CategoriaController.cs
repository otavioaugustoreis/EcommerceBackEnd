using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using TreinandoPráticasApi._1___Application.Models;
using TreinandoPráticasApi.Configs.Filters;
using TreinandoPráticasApi.Entities;
using TreinandoPráticasApi.Repositories;
using TreinandoPráticasApi.Repositories.UnitOfWork;
using TreinandoPráticasApi.RepositoriesPattern;

namespace TreinandoPráticasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase, IControllerPattern<CategoriaModel>
    {

        private readonly IUnitOfWork _uof;

        //Classe para acessar os arquivos JSON
        private readonly IConfiguration configuration;
        private readonly IMapper _mapper;

        //Maneira mais padrão de inserir um loggin é pela interface ILogging
        public readonly ILogger _logger;

        public CategoriaController(IUnitOfWork _uof, IConfiguration configuration, IMapper mapper)
        {
            this._uof = _uof;
            this.configuration = configuration;
            this._mapper = mapper;
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
        public ActionResult<IEnumerable<CategoriaModel>> Get()
        {

            var categorias = _uof.CategoriaRepository.Get();

            if (!categorias.Any() || categorias is null) return BadRequest(categorias);

            var categoriaDto = _mapper.Map<IEnumerable<CategoriaModel>>(categorias);

            return Ok(categoriaDto);
        }


        [HttpGet("{id:int}")]
        public ActionResult<CategoriaModel> GetId(int id)
        {
            _logger.LogInformation("========== GET ID =========");
            
            CategoriaEntity c1 =  _uof.CategoriaRepository.GetId(x => x.Id == id);

            if (c1 is null) return BadRequest("Categoria não encontrada");

            var categoriaModel = _mapper.Map<CategoriaModel>(c1);

            return Ok(categoriaModel);
        }

        [HttpPost]
        public ActionResult<CategoriaModel> Post(CategoriaModel entidade)
        {
            if (entidade is null) return BadRequest();

            var categoria = _mapper.Map<CategoriaEntity>(entidade);

            _uof.CategoriaRepository.Post(categoria);

            return new CreatedAtRouteResult("GetCategoriaById", new { id = entidade.Id }, entidade);
        }


        [HttpPut("{id:int:min(1)}")]
        public ActionResult<CategoriaModel> Put(int id, CategoriaModel t)
        {
            CategoriaEntity c1 = _uof.CategoriaRepository.GetId(c => c.Id == id);
            
            if (c1 is null || t is null) return BadRequest("Categoria não encontrada");


            return Ok(_uof.CategoriaRepository.Put(c1));
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<CategoriaModel> Delete(int id)
        {
            CategoriaEntity c1 = _uof.CategoriaRepository.GetId(c => c.Id == id);
            if (c1 is null)
                return BadRequest("Categoria não encontrada");

            
            return Ok(_uof.CategoriaRepository.Delete(c1));

        }
    }
}
