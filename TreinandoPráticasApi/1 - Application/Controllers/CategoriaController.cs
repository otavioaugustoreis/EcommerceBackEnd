using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography.Xml;
using TreinandoPráticasApi._1___Application.Models;
using TreinandoPráticasApi._1___Application.Pagination;
using TreinandoPráticasApi.Configs.Filters;
using TreinandoPráticasApi.Entities;
using TreinandoPráticasApi.Repositories;
using TreinandoPráticasApi.Repositories.UnitOfWork;
using TreinandoPráticasApi.RepositoriesPattern;

namespace TreinandoPráticasApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly IUnitOfWork _uof;
        private readonly IConfiguration configuration;
        private readonly IMapper _mapper;


        public CategoriaController(IUnitOfWork _uof, IConfiguration configuration, IMapper mapper)
        {
            this._uof = _uof;
            this.configuration = configuration;
            this._mapper = mapper;
        }


        //Lendo arquivo de configuração
        //[HttpGet("Lendo arquivo de configuração")]
        //public string GetValores()
        //{
        //    var valor1 = configuration["chave1"];
        //    var valor2 = configuration["secao1:chave1"];

        //    return $"{valor1} e {valor2}";
        //}


        //Filtro está relacionado com o Logging!!
        // [ServiceFilter(typeof(ApiLoggingFilter))]

        //Get com paginação
        [HttpGet("paginacao/")]
        public ActionResult<IEnumerable<CategoriaModelResponse>> GetPaginacao([FromQuery] CategoriaParameters categoriaParameters)
        { 
            var categorias = _uof.CategoriaRepository.GetCategoriasAsync(categoriaParameters);

            var metadata = new
            {
                categorias.TotalCount,
                categorias.PageSize,
                categorias.CurrentPage,
                categorias.TotalPages,
                categorias.HasNext,
                categorias.HasPrevius

            };

            //Serializando os objetos do metadata no formato Json, Headers, são as informações do retorno da API

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            var categoriaDto = _mapper.Map<IEnumerable<CategoriaModelResponse>>(categorias);

            return Ok(categoriaDto);
        }

            [Authorize]
            [HttpGet]
        public ActionResult<IEnumerable<CategoriaModelResponse>> Get()
        {

            var categorias = _uof.CategoriaRepository.Get();

            if (!categorias.Any() || categorias is null) return BadRequest("Não existe categoria");

            var categoriaDto = _mapper.Map<IEnumerable<CategoriaModelResponse>>(categorias);

            return Ok(categoriaDto);
        }

        //Especificando a policy para o Authorize
        [Authorize(Policy = "AdminOnly")]
        [HttpGet("categoriaAsync/")]
        public async Task<ActionResult<IEnumerable<CategoriaModelResponse>>> GetAsync()
        {

            var categoriaAsync = await  _uof.CategoriaRepository.GetAsync();

            if (categoriaAsync is null) return BadRequest("Não existe categoria"); 

            var categoriaDto = _mapper.Map<IEnumerable<CategoriaModelResponse>>(categoriaAsync);

            return Ok(categoriaDto);
        }

        //Esse GetId é FromQuery, ou seja, você escreve via URL e não no HTTP
        //QueryString
        [HttpGet("categoria/", Name = "GetCategoriaById")]
        public ActionResult<CategoriaModelResponse> GetId([FromQuery] int id)
        {
            CategoriaEntity c1 = _uof.CategoriaRepository.GetId(x => x.Id == id);

            if (c1 is null) return BadRequest("Categoria não encontrada");

            var categoriaModel = _mapper.Map<CategoriaModelResponse>(c1);

            return Ok(categoriaModel);
        }

        [HttpPost]
        public ActionResult<CategoriaModelResponse> Post([FromBody] CategoriaModelResponse entidade)
        {
            if (entidade is { DsNome: null }) return BadRequest();

            var categoria = _mapper.Map<CategoriaEntity>(entidade);

            _uof.CategoriaRepository.Post(categoria);
            

            var novoProdutoDto = _mapper.Map<CategoriaModelResponse>(categoria);

            return new CreatedAtRouteResult("GetCategoriaById", new { id = novoProdutoDto.Id }, novoProdutoDto);
        }


        [HttpPut("{id:int:min(1)}")]
        public ActionResult<CategoriaModelResponse> Put(int id, CategoriaModelResponse t)
        {
            if (id != t.Id) return BadRequest("Id diferente.");

            CategoriaEntity c1 = _uof.CategoriaRepository.GetId(c => c.Id == id);

            if (c1.Id != t.Id || t is null) return NotFound("Categoria não encontrada");

            var dto = _mapper.Map(t, c1);

            _uof.CategoriaRepository.Put(dto);
            _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<CategoriaModelResponse> Delete(int id)
        {
            CategoriaEntity c1 = _uof.CategoriaRepository.GetId(c => c.Id == id);

            if (c1 is null) return NotFound("Categoria não encontrada ");

            _uof.CategoriaRepository.Delete(c1);
            _uof.Commit();

            return NoContent();
        }

        [HttpPatch("{id}/UpdatePartial")]
        public ActionResult<CategoriaModelResponse> Patch(int id,
            JsonPatchDocument<CategoriaModelUpdateRequest> patchCategoria)
        {
            if (patchCategoria is null || id <= 0)
            {
                return BadRequest();
            }

            var categoriaEntity = _uof.CategoriaRepository.GetId(c => c.Id == id);

            var categoriaDto = _mapper.Map<CategoriaModelUpdateRequest>(categoriaEntity);

            try
            {
                patchCategoria.ApplyTo(categoriaDto, ModelState);
            }
            catch (JsonPatchException ex)
            {
                return BadRequest($"Erro ao aplicar o patch: {ex.Message}");
            }

            if (!ModelState.IsValid ) return BadRequest(ModelState);

            _mapper.Map(categoriaDto, categoriaEntity);
            _uof.CategoriaRepository.Put(categoriaEntity);
            _uof.Commit();
            return Ok(_mapper.Map<CategoriaModelResponse>(categoriaEntity));

        }

    }
}
