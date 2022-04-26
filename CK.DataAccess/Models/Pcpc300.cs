using System;
using System.Collections.Generic;

#nullable disable

namespace CK.DataAccess.Models
{
    public partial class Pcpc300
    {
        public int CodTipoVolume { get; set; }
        public string Descricao { get; set; }
        public byte? Caracteristica { get; set; }
        public int? QtdePecas { get; set; }
        public byte? CodEmbalagem { get; set; }
        public byte? Transacao { get; set; }
        public string CodPacoteCliente { get; set; }
        public bool? FormaMontagem { get; set; }
        public string ObsPrePack1 { get; set; }
        public string ObsPrePack2 { get; set; }
        public string ObsPrePack3 { get; set; }
        public string ObsPrePack4 { get; set; }
        public string IndControlaPeso { get; set; }
    }
}
