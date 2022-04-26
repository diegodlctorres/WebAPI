using System;
using System.Collections.Generic;

#nullable disable

namespace CK.DataAccess.Models
{
    public partial class Pcpc320
    {
        public int NumeroVolume { get; set; }
        public int? NumeroKit { get; set; }
        public string NivelKit { get; set; }
        public string GrupoKit { get; set; }
        public string SubKit { get; set; }
        public string ItemKit { get; set; }
        public int? Montador { get; set; }
        public DateTime? DataMontagem { get; set; }
        public bool? Turno { get; set; }
        public DateTime? HoraMontagem { get; set; }
        public bool? SituacaoKit { get; set; }
        public bool? SituacaoVolume { get; set; }
        public decimal? PesoVolume { get; set; }
        public int? PedidoVenda { get; set; }
        public int? NrSolicitacao { get; set; }
        public short? CodUsuario { get; set; }
        public int? CodTipoVolume { get; set; }
        public byte? DepositoEntrada { get; set; }
        public byte? TransacaoEntrada { get; set; }
        public byte? CodEmpresa { get; set; }
        public int? NotaFiscal { get; set; }
        public string SerieNota { get; set; }
        public byte? CodCancelamento { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public decimal? DepositoSaida { get; set; }
        public decimal? TransacaoSaida { get; set; }
        public decimal? PesoEmbalagem { get; set; }
        public int? NumeroVolumeExp { get; set; }
        public bool? LocalCaixa { get; set; }
        public int? EmpresaNotaEntrada { get; set; }
        public int? NotaFiscalEntrada { get; set; }
        public string SerieNotaEntrada { get; set; }
        public int? Cnpj9Entrada { get; set; }
        public byte? Cnpj4Entrada { get; set; }
        public byte? Cnpj2Entrada { get; set; }
        public int? NumeroColetaFaturamento { get; set; }
        public bool? SitAnterior { get; set; }
        public int? TipoEndereco { get; set; }
        public int? QtdePecasSug { get; set; }
        public byte? CodEmbalagem { get; set; }
        public bool? ExecutaTrigger { get; set; }
        public int? PreRomaneio { get; set; }
        public byte? EmpresaTransf { get; set; }
        public int? NotaTransf { get; set; }
        public string SerieTransf { get; set; }
        public int? NumeroPrePack { get; set; }
        public string EnderecoCaixaPeca { get; set; }
        public int? NroDespacho { get; set; }
        public bool? FlgImpreso { get; set; }
        public bool? FlgAuditado { get; set; }
        public int? CodEmbarque { get; set; }
    }
}
