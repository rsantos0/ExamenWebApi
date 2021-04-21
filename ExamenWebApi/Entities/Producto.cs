using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenWebApi.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public decimal CostoUnit { get; set; }
        
        public string Imagen { get; set; }
        
        public int Existecia { get; set; }

        public virtual ICollection<ProveedorProducto> ProveedorProductos { get; set; }
        public virtual ICollection<OrdenCompraDetalle> OrdenCompraDetalles { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }
    }
}
