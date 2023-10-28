using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionEntities;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        // GET: api/Productos
        [HttpGet(Name = "GetProductos")]
        public IEnumerable<Producto> Get()
        {
            return ProductoBusiness.ListarProductos().ToArray();
        }

        // DELETE: api/Productos
        [HttpDelete(Name = "DeleteProducto")]
        public IActionResult Delete([FromBody] int id)
        {
            var producto = ProductoBusiness.ObtenerProductoPorId(id);
            if (producto.Id == 0)
            {
                return NotFound();
            }
            ProductoBusiness.EliminarProducto(id);
            return NoContent();
        }

        // PUT: api/Productos
        [HttpPut(Name = "PutProducto")]
        public IActionResult Put([FromBody] Producto producto)
        {
            if (producto.Id == 0)
            {
                return BadRequest();
            }
            ProductoBusiness.ModificarProducto(producto);
            return NoContent();
        }

        // POST: api/Productos
        [HttpPost(Name = "PostProducto")]
        public IActionResult Post([FromBody] Producto producto)
        {
            if (producto.Id != 0)
            {
                return BadRequest();
            }
            ProductoBusiness.CrearProducto(producto);
            return CreatedAtRoute("GetProducto", new { id = producto.Id }, producto);
        }

        // GET: api/Productos/5
        [HttpGet("{id}", Name = "GetProducto")]
        public ActionResult<Producto> Get(int id)
        {
            var producto = ProductoBusiness.ObtenerProductoPorId(id);
            if (producto.Id == 0)
            {
                return NotFound();
            }
            return Ok(producto);
        }
    }
}
