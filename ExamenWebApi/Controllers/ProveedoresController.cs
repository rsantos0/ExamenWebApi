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
    public class ProveedoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProveedoresController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<object> Get(int id = 0)
        {
            if (id > 0)
            {
                var proveedor = _context.Proveedor.FirstOrDefault(p => p.ProveedorId == id);

                if (proveedor == null)
                {
                    return NotFound();
                }

                return proveedor;
            }
            else
            {
                var proveedores = _context.Proveedor
                .ToList();

                if (proveedores == null)
                {
                    return NotFound();
                }

                return proveedores;
            }

        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Proveedor proveedor)
        {

            if (id != proveedor.ProveedorId)
            {
                return BadRequest();
            }

            _context.Entry(proveedor).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Proveedor> Post([FromBody] Proveedor proveedor)
        {
            proveedor.ProveedorId = 0;

            _context.Proveedor.Add(proveedor);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = proveedor.ProveedorId }, proveedor);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var proveedor = _context.Proveedor.FirstOrDefault(p => p.ProveedorId == id);

            if (proveedor == null)
            {
                return NotFound();
            }

            _context.Proveedor.Remove(proveedor);
            _context.SaveChanges();

            return NoContent();
        }

        private bool ProveedorExists(int id)
        {
            return _context.Proveedor.Any(e => e.ProveedorId == id);
        }
    }
}
