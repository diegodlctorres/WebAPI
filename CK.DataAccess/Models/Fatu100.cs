using System;
using System.Collections.Generic;

#nullable disable

namespace CK.DataAccess.Models
{
    public partial class Fatu100
    {
        public byte CodigoEmbalagem { get; set; }
        public string Descricao { get; set; }
        public decimal? PesoEmbalagem { get; set; }
        public decimal? QtdePecasEmb { get; set; }
        public decimal? MetrosCubicosEmb { get; set; }
        public string Dimensoes { get; set; }
        public string UmMedDimensao { get; set; }
        public decimal? PesoMinimo { get; set; }
        public decimal? PesoMaximo { get; set; }
        public byte? Alternativa { get; set; }
        public decimal? PesoFixo { get; set; }
        public decimal? PesoPcEmb { get; set; }
        public string Apresentacao { get; set; }
        public bool? AlteraQtdeEmb { get; set; }
    }
}
