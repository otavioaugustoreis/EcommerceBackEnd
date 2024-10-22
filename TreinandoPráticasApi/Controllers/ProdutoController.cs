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

        public ProdutoController(IProduto produto)
        {
            this.produto = produto;
        }

        public ActionResult<ProdutoEntity> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult<IEnumerable<ProdutoEntity>> Get()
        {
            throw new NotImplementedException();
        }

        public IActionResult GetId(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult<ProdutoEntity> Post(ProdutoEntity entidade)
        {
            throw new NotImplementedException();
        }

        public ActionResult<ProdutoEntity> Put(int id, ProdutoEntity t)
        {
            throw new NotImplementedException();
        }
    }
}
