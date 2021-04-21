using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenWebApi.Entities
{
    public class Proveedor
    {

        public int ProveedorId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string NIT { get; set; }


        public virtual ICollection<ProveedorProducto> ProveedorProductos { get; set; }
        public virtual ICollection<OrdenCompra> OrdenCompras { get; set; }
    }
}
