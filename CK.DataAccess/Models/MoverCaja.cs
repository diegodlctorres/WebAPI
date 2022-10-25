using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.DataAccess.Models
{
    public partial class MoverCaja
    {
        public int p_num_caja { get; set; }
        public string p_cb_prenda { get; set; }
        public int p_tipo { get; set; }
        public int? p_deposito { get; set; }
        public int? p_new_caja { get; set; }
    }
}
