using ExamenWebApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenWebApi.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }

        public DbSet<Proveedor> Proveedor { get; set; }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<DetalleVenta> DetalleVenta { get; set; }
        public DbSet<EstadoOrdenCompra> EstadoOrdenCompra { get; set; }
        public DbSet<OrdenCompra> OrdenCompra { get; set; }
        public DbSet<OrdenCompraDetalle> OrdenCompraDetalle { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProveedorProducto> ProveedorProducto { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Venta> Venta { get; set; }
    }
}
