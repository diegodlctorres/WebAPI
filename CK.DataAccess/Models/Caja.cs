using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.DataAccess.Models
{
    public partial class Caja
    {
        public int DEPOSITO_ENTRADA { get; set; }

        public string DESCRIPCION_DEPOSITO { get; set; }

        public int PEDIDO_VENDA { get; set; }

        public string NIVEL { get; set; }

        public string GRUPO { get; set; }

        public string SUB { get; set; }

        public string ITEM { get; set; }

        public int QTDE_PECAS_REAL { get; set; }

        public string DESCRIPCION { get; set; }
    }
}
