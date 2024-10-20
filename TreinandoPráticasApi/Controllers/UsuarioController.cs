using Microsoft.AspNetCore.Mvc;
using TreinandoPráticasApi.Context;
using TreinandoPráticasApi.Entities;
using TreinandoPráticasApi.RepositoriesPattern;
using TreinandoPráticasApi.Services;

namespace TreinandoPráticasApi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase, IControllerPattern<UsuarioEntity>
    {
        public UsuarioService _UsuarioService { get; set; }
        public AppDbContext _AppDbContext { get; set; }

        public UsuarioController(UsuarioService usuarioService, AppDbContext appDbContext)
        {
            _UsuarioService = usuarioService;
            _AppDbContext = appDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioEntity>> Get()
        {
            return Ok(_UsuarioService.Get());
        }


        [HttpGet("usuario/{id:int}")]
        public ActionResult<UsuarioEntity> GetId(int id)
        {
            UsuarioEntity u1 = _UsuarioService.GetId(g => g.Id == id);

            if(u1 is null) return NotFound(u1);

            return Ok(u1);  
        }


        [HttpPost]
        public ActionResult<UsuarioEntity> Post(UsuarioEntity entidade)
        {
            if (entidade is null) return BadRequest();

            _UsuarioService.Post(entidade);
            return new CreatedAtRouteResult("UsuarioCriado", new { id = entidade.Id }, entidade);
        }

        [HttpPut("{id:int}")]
        public ActionResult<UsuarioEntity> Put(int id, UsuarioEntity t)
        {
            _UsuarioService.Put(t); 
            return Ok(t);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<UsuarioEntity> Delete(int id)
        {
            UsuarioEntity u1 = _UsuarioService.GetId(g => g.Id == id);
            if (u1 is null) return NotFound(u1);

            _UsuarioService.Delete(u1);
            return Ok();
        }
    }
}
