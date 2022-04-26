using System;
using System.Collections.Generic;

#nullable disable

namespace CK.DataAccess.Models
{
    public partial class Pcpc321
    {
        public int NumeroVolume { get; set; }
        public int PedidoVenda { get; set; }
        public string Nivel { get; set; }
        public string Grupo { get; set; }
        public string Sub { get; set; }
        public string Item { get; set; }
        public byte? PeriodoOrdem { get; set; }
        public short? OrdemConfeccao { get; set; }
        public byte? SeqItemPedido { get; set; }
        public int? QtdePecasReal { get; set; }
        public int? QtdePecasSug { get; set; }
    }
}
