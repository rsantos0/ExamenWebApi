﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenWebApi.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Contraseña { get; set; }
        [Required]
        public string Nombre { get; set; }

        [Required]
        public int RolId { get; set; }

        public Rol Rol { get; set; }
    }
}
