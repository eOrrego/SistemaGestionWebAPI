using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionEntities;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        // GET: api/Ventas
        [HttpGet(Name = "GetVentas")]
        public IEnumerable<Venta> Get()
        {
            return VentaBusiness.ListarVentas().ToArray();
        }

        // DELETE: api/Ventas
        [HttpDelete(Name = "DeleteVenta")]
        public IActionResult Delete([FromBody] int id)
        {
            var venta = VentaBusiness.ObtenerVentaPorId(id);
            if (venta.Id == 0)
            {
                return NotFound();
            }
            VentaBusiness.EliminarVenta(id);
            return NoContent();
        }

        // PUT: api/Ventas
        [HttpPut(Name = "PutVenta")]
        public IActionResult Put([FromBody] Venta venta)
        {
            if (venta.Id == 0)
            {
                return BadRequest();
            }
            VentaBusiness.ModificarVenta(venta);
            return NoContent();
        }

        // POST: api/Ventas
        [HttpPost(Name = "PostVenta")]
        public IActionResult Post([FromBody] Venta venta)
        {
            if (venta.Id != 0)
            {
                return BadRequest();
            }
            VentaBusiness.CrearVenta(venta);
            return CreatedAtRoute("GetVenta", new { id = venta.Id }, venta);
        }

        // GET: api/Ventas/5
        [HttpGet("{id}", Name = "GetVenta")]
        public ActionResult<Venta> Get(int id)
        {
            var venta = VentaBusiness.ObtenerVentaPorId(id);
            if (venta.Id == 0)
            {
                return NotFound();
            }
            return venta;
        }
    }
}
