using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenWebApi.Entities
{
    public class Venta
    {
        public int VentaId { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }
    }
}
