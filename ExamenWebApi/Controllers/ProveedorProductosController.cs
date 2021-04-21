using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenWebApi.Contexts;
using ExamenWebApi.Entities;

namespace ExamenWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProveedorProductosController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<object> Get(int id)
        {
            if (id > 0)
            {
                var proveedorProducto = await _context.ProveedorProducto.FindAsync(id);

                if (proveedorProducto == null)
                {
                    return NotFound();
                }

                return proveedorProducto;
            }
            else
            {
                var proveedorProductos = await _context.ProveedorProducto.ToListAsync();

                if (proveedorProductos == null)
                {
                    return NotFound();
                }

                return proveedorProductos;
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProveedorProducto proveedorProducto)
        {
            if (id != proveedorProducto.ProveedorProductoId)
            {
                return BadRequest();
            }

            _context.Entry(proveedorProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoProveedorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<ProveedorProducto>> Post(ProveedorProducto proveedorProducto)
        {
            _context.ProveedorProducto.Add(proveedorProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = proveedorProducto.ProveedorProductoId }, proveedorProducto);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ProveedorProducto>> Delete(int id)
        {
            var proveedorProducto = await _context.ProveedorProducto.FindAsync(id);

            if (proveedorProducto == null)
            {
                return NotFound();
            }

            _context.ProveedorProducto.Remove(proveedorProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoProveedorExists(int id)
        {
            return _context.ProveedorProducto.Any(e => e.ProveedorProductoId == id);
        }
    }
}
