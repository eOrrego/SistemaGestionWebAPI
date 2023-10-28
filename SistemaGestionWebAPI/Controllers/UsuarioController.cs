using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionEntities;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // GET: api/Usuarios
        [HttpGet(Name = "GetUsuarios")]
        public IEnumerable<Usuario> Get()
        {
            return UsuarioBusiness.ListarUsuarios().ToArray();
        }

        // DELETE: api/Usuarios
        [HttpDelete(Name = "DeleteUsuario")]
        public IActionResult Delete([FromBody] int id)
        {
            var usuario = UsuarioBusiness.ObtenerUsuarioPorId(id);
            if (usuario.Id == 0)
            {
                return NotFound();
            }
            UsuarioBusiness.EliminarUsuario(id);
            return NoContent();
        }

        // PUT: api/Usuarios
        [HttpPut(Name = "PutUsuario")]
        public IActionResult Put([FromBody] Usuario usuario)
        {
            if (usuario.Id == 0)
            {
                return BadRequest();
            }
            UsuarioBusiness.ModificarUsuario(usuario);
            return NoContent();
        }

        // POST: api/Usuarios
        [HttpPost(Name = "PostUsuario")]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            if (usuario.Id != 0)
            {
                return BadRequest();
            }
            UsuarioBusiness.CrearUsuario(usuario);
            return CreatedAtRoute("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}", Name = "GetUsuario")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = UsuarioBusiness.ObtenerUsuarioPorId(id);
            if (usuario.Id == 0)
            {
                return NotFound();
            }
            return usuario;
        }
    }
}
