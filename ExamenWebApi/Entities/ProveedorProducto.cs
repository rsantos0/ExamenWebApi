using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenWebApi.Entities
{
    public class ProveedorProducto
    {
        public int ProveedorProductoId { get; set; }
        [Required]
        public int ProductoId { get; set; }
        [Required]
        public int ProveedorId { get; set; }

        public Producto Producto { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
