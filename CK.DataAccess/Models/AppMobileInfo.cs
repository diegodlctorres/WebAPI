using System;
using System.Collections.Generic;

#nullable disable

namespace CK.DataAccess.Models
{
    public partial class AppMobileInfo
    {
        public decimal Codigo { get; set; }
        public string Nombre { get; set; }
        public string Version { get; set; }
        public string Repositorio { get; set; }
    }
}
