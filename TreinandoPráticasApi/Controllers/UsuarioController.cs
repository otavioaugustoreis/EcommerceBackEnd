using Microsoft.AspNetCore.Mvc;
using TreinandoPráticasApi.Context;
using TreinandoPráticasApi.Entities;
using TreinandoPráticasApi.Repositories;
using TreinandoPráticasApi.RepositoriesPattern;
using TreinandoPráticasApi.Services;

namespace TreinandoPráticasApi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase, IControllerPattern<UsuarioEntity>
    {
        private readonly IUsuario _UsuarioService;

        public UsuarioController(IUsuario usuarioService)
        {
            _UsuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioEntity>> Get()
        {
            return Ok(_UsuarioService.Get());
        }

        [HttpGet("{id:int:min(1)}", Name = "GetUsuarioById")]
        public IActionResult GetId(int id)
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
            return new CreatedAtRouteResult("GetUsuarioById", new { id = entidade.Id }, entidade);
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult<UsuarioEntity> Put(int id, UsuarioEntity t)
        {
            _UsuarioService.Put(t); 
            return Ok(t);
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<UsuarioEntity> Delete(int id)
        {
            UsuarioEntity u1 = _UsuarioService.GetId(g => g.Id == id);
            if (u1 is null) return NotFound(u1);

            _UsuarioService.Delete(u1);
            return Ok();
        }
    }
}