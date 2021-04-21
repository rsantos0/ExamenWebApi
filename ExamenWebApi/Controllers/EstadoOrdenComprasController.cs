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
    public class EstadoOrdenComprasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstadoOrdenComprasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoOrdenCompra>>> GetEstadoOrdenCompra()
        {
            return await _context.EstadoOrdenCompra.ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoOrdenCompra>> GetEstadoOrdenCompra(int id)
        {
            var estadoOrdenCompra = await _context.EstadoOrdenCompra.FindAsync(id);

            if (estadoOrdenCompra == null)
            {
                return NotFound();
            }

            return estadoOrdenCompra;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoOrdenCompra(int id, EstadoOrdenCompra estadoOrdenCompra)
        {
            if (id != estadoOrdenCompra.EstadoOrdenCompraId)
            {
                return BadRequest();
            }

            _context.Entry(estadoOrdenCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoOrdenCompraExists(id))
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
        public async Task<ActionResult<EstadoOrdenCompra>> PostEstadoOrdenCompra(EstadoOrdenCompra estadoOrdenCompra)
        {
            _context.EstadoOrdenCompra.Add(estadoOrdenCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoOrdenCompra", new { id = estadoOrdenCompra.EstadoOrdenCompraId }, estadoOrdenCompra);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<EstadoOrdenCompra>> DeleteEstadoOrdenCompra(int id)
        {
            var estadoOrdenCompra = await _context.EstadoOrdenCompra.FindAsync(id);
            if (estadoOrdenCompra == null)
            {
                return NotFound();
            }

            _context.EstadoOrdenCompra.Remove(estadoOrdenCompra);
            await _context.SaveChangesAsync();

            return estadoOrdenCompra;
        }

        private bool EstadoOrdenCompraExists(int id)
        {
            return _context.EstadoOrdenCompra.Any(e => e.EstadoOrdenCompraId == id);
        }
    }
}
