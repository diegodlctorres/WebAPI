using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.DataAccess.Models
{
    public partial class Usuario
    {
        public decimal CodFuncionario { get; set; }
        public decimal Contrasena { get; set; }
        public string Nome { get; set; }
    }
}
