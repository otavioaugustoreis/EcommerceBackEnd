using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using TreinandoPráticasApi.Entities;
using TreinandoPráticasApi.Repositories;
using TreinandoPráticasApi.RepositoriesPattern;

namespace TreinandoPráticasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase, IControllerPattern<CategoriaEntity>
    {

        private readonly ICategoria categoria;

        public CategoriaController(ICategoria categoria)
        {
            this.categoria = categoria;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoriaEntity>> Get()
        {
            return Ok(categoria.Get());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetId(int id)
        {
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
