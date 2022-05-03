using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.DataTransferObject
{
    public class UserLogeadoDTO
    {
        public decimal CodFuncionario { get; set; }
        public decimal Contrasena { get; set; }
        public string Nome { get; set; }
        public string Mensaje { get; set; }
    }
}
