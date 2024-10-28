using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TreinandoPráticasApi.Entities;
using TreinandoPráticasApi.Repositories;
using TreinandoPráticasApi.RepositoriesPattern;

namespace TreinandoPráticasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase, IControllerPattern<ProdutoEntity>
    {

        private readonly IProduto produto;
        private readonly ICategoria categoria;


        public ProdutoController(IProduto produto)
        {
            this.produto = produto;
        }

        [HttpDelete("{id:int}")]
            public ActionResult<ProdutoEntity> Delete(int id)
        {
            ProdutoEntity p1 = produto.GetId(p => p.Id == id);
            
            return Ok(produto.Delete(p1));
        }


        [HttpGet]
        public ActionResult<IEnumerable<ProdutoEntity>> Get()
        {
            return Ok(produto.Get());
        }

        [HttpGet("/{id:int:min(1)}", Name = "GetProdutoById")]
        public IActionResult GetId(int id)
        {
            ProdutoEntity p1 = produto.GetId(p => p.Id == id);

            return Ok(p1);
        }

        [HttpPost]
        public ActionResult<ProdutoEntity> Post(ProdutoEntity entidade)
        {
            if (entidade is null) return BadRequest();

            produto.Post(entidade);
            return new CreatedAtRouteResult("GetProdutoById", new { id = entidade.Id }, entidade);
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult<ProdutoEntity> Put(int id, ProdutoEntity t)
        {
            return Ok(produto.Put(t));
        }
    }
}
