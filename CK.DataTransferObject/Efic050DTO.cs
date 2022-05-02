using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.DataTransferObject
{
    public class Efic050DTO
    {
        public decimal CodEmpresa { get; set; }
        public decimal CodFuncionario { get; set; }
        public string Nome { get; set; }
        public decimal? Turno { get; set; }
        public decimal? LancaParada { get; set; }
        public decimal? LancaRejeicao { get; set; }
        public decimal? CodigoCargo { get; set; }
        public decimal? CentroCusto { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public bool? Sexo { get; set; }
        public bool? EstadoCivil { get; set; }
        public byte? GrauInstrucao { get; set; }
        public bool? PlanoSaude { get; set; }
        public string CpfFunc { get; set; }
        public decimal? CustoHora { get; set; }
        public bool? ResponsavelDados { get; set; }
        public string EMail { get; set; }
        public int? Ramal { get; set; }
        public string Observacao { get; set; }
        public string CrachaFuncionario { get; set; }
        public byte? SetorResponsavel { get; set; }
        public bool? SitFuncionario { get; set; }
        public bool? LancaHrsManu { get; set; }
        public bool? FlgDestajo { get; set; }

    }
}
