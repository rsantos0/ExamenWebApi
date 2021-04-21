using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenWebApi.Entities
{
    public class DetalleVenta
    {

        public int DetalleVentaId { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public int ProductoId { get; set; }
        [Required]
        public int VentaId { get; set; }

        public Venta Venta { get; set; }
        public Producto Producto { get; set; }
    }
}
