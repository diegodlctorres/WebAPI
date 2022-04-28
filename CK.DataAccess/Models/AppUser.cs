using System;
using System.Collections.Generic;

#nullable disable

namespace CK.DataAccess.Models
{
    public partial class AppUser
    {
        public decimal CodFuncionario { get; set; }
        public decimal Contrasena { get; set; }
        public bool? Estado { get; set; }
        public string UsuarioRegistro { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
