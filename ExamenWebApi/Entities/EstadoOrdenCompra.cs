using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenWebApi.Entities
{
    public class EstadoOrdenCompra
    {

        public int EstadoOrdenCompraId { get; set; }
        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<OrdenCompra> OrdenCompras { get; set; }
    }
}
