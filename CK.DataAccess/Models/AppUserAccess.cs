using System;
using System.Collections.Generic;

#nullable disable

namespace CK.DataAccess.Models
{
    public partial class AppUserAccess
    {
        public decimal CodFuncionario { get; set; }
        public decimal CodigoApp { get; set; }
        public DateTime? UltimoAcceso { get; set; }
    }
}
