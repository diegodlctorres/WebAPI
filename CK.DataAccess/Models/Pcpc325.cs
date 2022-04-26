using System;
using System.Collections.Generic;

#nullable disable

namespace CK.DataAccess.Models
{
    public partial class Pcpc325
    {
        public int NumeroVolume { get; set; }
        public string Nivel { get; set; }
        public string Grupo { get; set; }
        public string Sub { get; set; }
        public string Item { get; set; }
        public byte PeriodoOrdem { get; set; }
        public short OrdemConfeccao { get; set; }
        public int? QtdePecasReal { get; set; }
        public int? QtdePecasSug { get; set; }
        public int? NumeroKit { get; set; }
        public string NivelEstoque { get; set; }
        public string GrupoEstoque { get; set; }
        public string SubEstoque { get; set; }
        public string ItemEstoque { get; set; }
        public decimal? QtdeQuilosEstoque { get; set; }
        public byte ArtigoProduto { get; set; }
        public byte SeqItemPedido { get; set; }
        public decimal? QtdeQuilosReal { get; set; }
        public bool? ExecutaTrigger { get; set; }
    }
}
