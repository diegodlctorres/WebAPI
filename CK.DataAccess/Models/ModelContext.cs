using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CK.DataAccess.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CkPerfil> CkPerfils { get; set; }
        public virtual DbSet<CkUser> CkUsers { get; set; }
        public virtual DbSet<Efic050> Efic050s { get; set; }
        public virtual DbSet<Fatu100> Fatu100s { get; set; }
        public virtual DbSet<Pcpc300> Pcpc300s { get; set; }
        public virtual DbSet<Pcpc320> Pcpc320s { get; set; }
        public virtual DbSet<Pcpc321> Pcpc321s { get; set; }
        public virtual DbSet<Pcpc325> Pcpc325s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=USYSTEX; Password=oracle;Data Source=192.168.0.51:1521/dbsystex.cottonknit.com;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("USYSTEX");

            modelBuilder.Entity<CkPerfil>(entity =>
            {
                entity.HasKey(e => e.Codperf)
                    .HasName("CK_PERFIL_PK");

                entity.ToTable("CK_PERFIL");

                entity.Property(e => e.Codperf)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CODPERF")
                    .IsFixedLength(true);

                entity.Property(e => e.Dscperf)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DSCPERF");

                entity.Property(e => e.Fchcre)
                    .HasColumnType("DATE")
                    .HasColumnName("FCHCRE");

                entity.Property(e => e.Fchmod)
                    .HasColumnType("DATE")
                    .HasColumnName("FCHMOD");

                entity.Property(e => e.Flgeli)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FLGELI")
                    .HasDefaultValueSql("'0'")
                    .IsFixedLength(true);

                entity.Property(e => e.Usrcre)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("USRCRE");

                entity.Property(e => e.Usrmod)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("USRMOD");

                entity.Property(e => e.Wkscre)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("WKSCRE");

                entity.Property(e => e.Wksmod)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("WKSMOD");
            });

            modelBuilder.Entity<CkUser>(entity =>
            {
                entity.HasKey(e => e.Login)
                    .HasName("CK_USER_PK");

                entity.ToTable("CK_USER");

                entity.HasIndex(e => new { e.CodEmpresa, e.CodFuncionario }, "IDX_CODEM");

                entity.Property(e => e.Login)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("LOGIN");

                entity.Property(e => e.Appversion)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("APPVERSION");

                entity.Property(e => e.Clave)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("CLAVE");

                entity.Property(e => e.ClaveAlt)
                    .HasPrecision(4)
                    .HasColumnName("CLAVE_ALT");

                entity.Property(e => e.ClaveApp)
                    .HasPrecision(4)
                    .HasColumnName("CLAVE_APP");

                entity.Property(e => e.CodEmpresa)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("COD_EMPRESA");

                entity.Property(e => e.CodFuncionario)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("COD_FUNCIONARIO");

                entity.Property(e => e.Codperf)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CODPERF")
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fchcre)
                    .HasColumnType("DATE")
                    .HasColumnName("FCHCRE");

                entity.Property(e => e.Fchmod)
                    .HasColumnType("DATE")
                    .HasColumnName("FCHMOD");

                entity.Property(e => e.FecAcceso)
                    .HasColumnType("DATE")
                    .HasColumnName("FEC_ACCESO");

                entity.Property(e => e.Flgeli)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FLGELI")
                    .HasDefaultValueSql("'0'")
                    .IsFixedLength(true);

                entity.Property(e => e.Flgiso)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FLGISO")
                    .HasDefaultValueSql("'0'")
                    .IsFixedLength(true);

                entity.Property(e => e.Flgval)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FLGVAL")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Iso1)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ISO_1");

                entity.Property(e => e.Iso2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ISO_2");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRES");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("OBSERVACION");

                entity.Property(e => e.SessionNumber)
                    .HasPrecision(1)
                    .HasColumnName("SESSION_NUMBER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Usrcre)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("USRCRE");

                entity.Property(e => e.Usrmod)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("USRMOD");

                entity.Property(e => e.Wkscre)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("WKSCRE");

                entity.Property(e => e.Wksmod)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("WKSMOD");

                entity.HasOne(d => d.CodperfNavigation)
                    .WithMany(p => p.CkUsers)
                    .HasForeignKey(d => d.Codperf)
                    .HasConstraintName("CK_USER_R01");
            });

            modelBuilder.Entity<Efic050>(entity =>
            {
                entity.HasKey(e => new { e.CodEmpresa, e.CodFuncionario });

                entity.ToTable("EFIC_050");

                entity.HasIndex(e => e.CodFuncionario, "I_EFIC_050_1");

                entity.Property(e => e.CodEmpresa)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("COD_EMPRESA");

                entity.Property(e => e.CodFuncionario)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("COD_FUNCIONARIO");

                entity.Property(e => e.CentroCusto)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CENTRO_CUSTO");

                entity.Property(e => e.CodigoCargo)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CODIGO_CARGO");

                entity.Property(e => e.CpfFunc)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CPF_FUNC")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CrachaFuncionario)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CRACHA_FUNCIONARIO")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CustoHora)
                    .HasColumnType("NUMBER(7,2)")
                    .HasColumnName("CUSTO_HORA")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.DataAdmissao)
                    .HasColumnType("DATE")
                    .HasColumnName("DATA_ADMISSAO");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("DATE")
                    .HasColumnName("DATA_NASCIMENTO");

                entity.Property(e => e.EMail)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("E_MAIL")
                    .HasDefaultValueSql("' '");

                entity.Property(e => e.EstadoCivil)
                    .HasPrecision(1)
                    .HasColumnName("ESTADO_CIVIL")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FlgDestajo)
                    .HasPrecision(1)
                    .HasColumnName("FLG_DESTAJO");

                entity.Property(e => e.GrauInstrucao)
                    .HasPrecision(2)
                    .HasColumnName("GRAU_INSTRUCAO")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LancaHrsManu)
                    .HasPrecision(1)
                    .HasColumnName("LANCA_HRS_MANU")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.LancaParada)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LANCA_PARADA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LancaRejeicao)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LANCA_REJEICAO")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Nome)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NOME");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("OBSERVACAO")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PlanoSaude)
                    .HasPrecision(1)
                    .HasColumnName("PLANO_SAUDE")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Ramal)
                    .HasPrecision(8)
                    .HasColumnName("RAMAL")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ResponsavelDados)
                    .HasPrecision(1)
                    .HasColumnName("RESPONSAVEL_DADOS")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SetorResponsavel)
                    .HasPrecision(3)
                    .HasColumnName("SETOR_RESPONSAVEL")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Sexo)
                    .HasPrecision(1)
                    .HasColumnName("SEXO")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SitFuncionario)
                    .HasPrecision(1)
                    .HasColumnName("SIT_FUNCIONARIO")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Turno)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TURNO");
            });

            modelBuilder.Entity<Fatu100>(entity =>
            {
                entity.HasKey(e => e.CodigoEmbalagem);

                entity.ToTable("FATU_100");

                entity.Property(e => e.CodigoEmbalagem)
                    .HasPrecision(3)
                    .HasColumnName("CODIGO_EMBALAGEM")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.AlteraQtdeEmb)
                    .HasPrecision(1)
                    .HasColumnName("ALTERA_QTDE_EMB")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Alternativa)
                    .HasPrecision(3)
                    .HasColumnName("ALTERNATIVA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Apresentacao)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("APRESENTACAO")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DESCRICAO")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Dimensoes)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("DIMENSOES")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MetrosCubicosEmb)
                    .HasColumnType("NUMBER(11,5)")
                    .HasColumnName("METROS_CUBICOS_EMB")
                    .HasDefaultValueSql("0.00000");

                entity.Property(e => e.PesoEmbalagem)
                    .HasColumnType("NUMBER(8,4)")
                    .HasColumnName("PESO_EMBALAGEM")
                    .HasDefaultValueSql("0.0");

                entity.Property(e => e.PesoFixo)
                    .HasColumnType("NUMBER(9,4)")
                    .HasColumnName("PESO_FIXO")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.PesoMaximo)
                    .HasColumnType("NUMBER(13,4)")
                    .HasColumnName("PESO_MAXIMO")
                    .HasDefaultValueSql("0.0000");

                entity.Property(e => e.PesoMinimo)
                    .HasColumnType("NUMBER(13,4)")
                    .HasColumnName("PESO_MINIMO")
                    .HasDefaultValueSql("0.0000");

                entity.Property(e => e.PesoPcEmb)
                    .HasColumnType("NUMBER(9,4)")
                    .HasColumnName("PESO_PC_EMB")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.QtdePecasEmb)
                    .HasColumnType("NUMBER(15,3)")
                    .HasColumnName("QTDE_PECAS_EMB")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UmMedDimensao)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UM_MED_DIMENSAO")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Pcpc300>(entity =>
            {
                entity.HasKey(e => e.CodTipoVolume);

                entity.ToTable("PCPC_300");

                entity.HasIndex(e => new { e.Caracteristica, e.CodTipoVolume }, "PCPC_300_20");

                entity.Property(e => e.CodTipoVolume)
                    .HasPrecision(6)
                    .HasColumnName("COD_TIPO_VOLUME")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Caracteristica)
                    .HasPrecision(2)
                    .HasColumnName("CARACTERISTICA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CodEmbalagem)
                    .HasPrecision(3)
                    .HasColumnName("COD_EMBALAGEM")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CodPacoteCliente)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("COD_PACOTE_CLIENTE")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRICAO")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.FormaMontagem)
                    .HasPrecision(1)
                    .HasColumnName("FORMA_MONTAGEM")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IndControlaPeso)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IND_CONTROLA_PESO")
                    .HasDefaultValueSql("'S'");

                entity.Property(e => e.ObsPrePack1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("OBS_PRE_PACK1")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObsPrePack2)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("OBS_PRE_PACK2")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObsPrePack3)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("OBS_PRE_PACK3")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObsPrePack4)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("OBS_PRE_PACK4")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.QtdePecas)
                    .HasPrecision(6)
                    .HasColumnName("QTDE_PECAS")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Transacao)
                    .HasPrecision(3)
                    .HasColumnName("TRANSACAO")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Pcpc320>(entity =>
            {
                entity.HasKey(e => e.NumeroVolume);

                entity.ToTable("PCPC_320");

                entity.HasIndex(e => e.DataMontagem, "DATA_MONTAGEM_IDX");

                entity.HasIndex(e => new { e.NroDespacho, e.PedidoVenda }, "I_PCPC_320");

                entity.HasIndex(e => new { e.PedidoVenda, e.NroDespacho, e.SituacaoVolume, e.DepositoEntrada }, "I_PCPC_320_02");

                entity.HasIndex(e => new { e.PreRomaneio, e.SituacaoVolume, e.NumeroPrePack }, "I_PCPC_320_03");

                entity.HasIndex(e => new { e.NumeroVolume, e.DepositoEntrada, e.SituacaoVolume, e.NumeroPrePack }, "JT_INDEX");

                entity.HasIndex(e => new { e.CodTipoVolume, e.PedidoVenda, e.NotaFiscal, e.NrSolicitacao, e.NumeroVolume }, "PCPC_320_20");

                entity.HasIndex(e => e.EnderecoCaixaPeca, "PCPC_320_END");

                entity.HasIndex(e => e.NumeroPrePack, "PCPC_320_PRE_PACK");

                entity.Property(e => e.NumeroVolume)
                    .HasPrecision(9)
                    .HasColumnName("NUMERO_VOLUME")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Cnpj2Entrada)
                    .HasPrecision(2)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CNPJ2_ENTRADA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Cnpj4Entrada)
                    .HasPrecision(4)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CNPJ4_ENTRADA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Cnpj9Entrada)
                    .HasPrecision(9)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CNPJ9_ENTRADA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CodCancelamento)
                    .HasPrecision(3)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COD_CANCELAMENTO")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CodEmbalagem)
                    .HasPrecision(3)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COD_EMBALAGEM")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CodEmbarque)
                    .HasPrecision(9)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COD_EMBARQUE")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CodEmpresa)
                    .HasPrecision(3)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COD_EMPRESA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CodTipoVolume)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COD_TIPO_VOLUME")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CodUsuario)
                    .HasPrecision(5)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COD_USUARIO")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DataCancelamento)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DATA_CANCELAMENTO");

                entity.Property(e => e.DataMontagem)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DATA_MONTAGEM");

                entity.Property(e => e.DepositoEntrada)
                    .HasPrecision(3)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DEPOSITO_ENTRADA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DepositoSaida)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DEPOSITO_SAIDA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmpresaNotaEntrada)
                    .HasPrecision(9)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EMPRESA_NOTA_ENTRADA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmpresaTransf)
                    .HasPrecision(3)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EMPRESA_TRANSF")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EnderecoCaixaPeca)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ENDERECO_CAIXA_PECA")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ExecutaTrigger)
                    .HasPrecision(1)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EXECUTA_TRIGGER");

                entity.Property(e => e.FlgAuditado)
                    .HasPrecision(1)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FLG_AUDITADO")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FlgImpreso)
                    .HasPrecision(1)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FLG_IMPRESO")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.GrupoKit)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("GRUPO_KIT")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.HoraMontagem)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HORA_MONTAGEM");

                entity.Property(e => e.ItemKit)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ITEM_KIT")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LocalCaixa)
                    .HasPrecision(1)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOCAL_CAIXA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Montador)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MONTADOR")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NivelKit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NIVEL_KIT")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NotaFiscal)
                    .HasPrecision(9)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTA_FISCAL")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NotaFiscalEntrada)
                    .HasPrecision(9)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTA_FISCAL_ENTRADA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NotaTransf)
                    .HasPrecision(9)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTA_TRANSF")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NrSolicitacao)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NR_SOLICITACAO")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NroDespacho)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NRO_DESPACHO")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.NumeroColetaFaturamento)
                    .HasPrecision(9)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NUMERO_COLETA_FATURAMENTO")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NumeroKit)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NUMERO_KIT")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NumeroPrePack)
                    .HasPrecision(9)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NUMERO_PRE_PACK")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NumeroVolumeExp)
                    .HasPrecision(9)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NUMERO_VOLUME_EXP")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PedidoVenda)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PEDIDO_VENDA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PesoEmbalagem)
                    .HasColumnType("NUMBER(12,2)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PESO_EMBALAGEM")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.PesoVolume)
                    .HasColumnType("NUMBER(10,2)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PESO_VOLUME")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.PreRomaneio)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRE_ROMANEIO")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QtdePecasSug)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("QTDE_PECAS_SUG")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SerieNota)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SERIE_NOTA")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SerieNotaEntrada)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SERIE_NOTA_ENTRADA")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SerieTransf)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SERIE_TRANSF")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SitAnterior)
                    .HasPrecision(1)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SIT_ANTERIOR")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SituacaoKit)
                    .HasPrecision(1)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SITUACAO_KIT")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SituacaoVolume)
                    .HasPrecision(1)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SITUACAO_VOLUME")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SubKit)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SUB_KIT")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TipoEndereco)
                    .HasPrecision(9)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TIPO_ENDERECO")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TransacaoEntrada)
                    .HasPrecision(3)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TRANSACAO_ENTRADA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TransacaoSaida)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TRANSACAO_SAIDA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Turno)
                    .HasPrecision(1)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TURNO")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Pcpc321>(entity =>
            {
                entity.HasKey(e => new { e.NumeroVolume, e.Nivel, e.Grupo, e.Sub, e.Item, e.PedidoVenda });

                entity.ToTable("PCPC_321");

                entity.HasIndex(e => e.NumeroVolume, "IDX_NUM_VOLUME");

                entity.HasIndex(e => new { e.PedidoVenda, e.Nivel, e.Grupo, e.Sub, e.Item }, "PCPC_321_01");

                entity.Property(e => e.NumeroVolume)
                    .HasPrecision(9)
                    .HasColumnName("NUMERO_VOLUME")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Nivel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NIVEL")
                    .HasDefaultValueSql("'' ");

                entity.Property(e => e.Grupo)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("GRUPO")
                    .HasDefaultValueSql("'' ");

                entity.Property(e => e.Sub)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SUB")
                    .HasDefaultValueSql("'' ");

                entity.Property(e => e.Item)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("ITEM")
                    .HasDefaultValueSql("'' ");

                entity.Property(e => e.PedidoVenda)
                    .HasPrecision(6)
                    .HasColumnName("PEDIDO_VENDA")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.OrdemConfeccao)
                    .HasPrecision(5)
                    .HasColumnName("ORDEM_CONFECCAO")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PeriodoOrdem)
                    .HasPrecision(4)
                    .HasColumnName("PERIODO_ORDEM")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QtdePecasReal)
                    .HasPrecision(6)
                    .HasColumnName("QTDE_PECAS_REAL")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QtdePecasSug)
                    .HasPrecision(6)
                    .HasColumnName("QTDE_PECAS_SUG")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SeqItemPedido)
                    .HasPrecision(3)
                    .HasColumnName("SEQ_ITEM_PEDIDO")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Pcpc325>(entity =>
            {
                entity.HasKey(e => new { e.NumeroVolume, e.Nivel, e.Grupo, e.Sub, e.Item, e.PeriodoOrdem, e.OrdemConfeccao, e.SeqItemPedido });

                entity.ToTable("PCPC_325");

                entity.Property(e => e.NumeroVolume)
                    .HasPrecision(9)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NUMERO_VOLUME")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Nivel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NIVEL")
                    .HasDefaultValueSql("'' ");

                entity.Property(e => e.Grupo)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("GRUPO")
                    .HasDefaultValueSql("'' ");

                entity.Property(e => e.Sub)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SUB")
                    .HasDefaultValueSql("'' ");

                entity.Property(e => e.Item)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ITEM")
                    .HasDefaultValueSql("'' ");

                entity.Property(e => e.PeriodoOrdem)
                    .HasPrecision(4)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PERIODO_ORDEM")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.OrdemConfeccao)
                    .HasPrecision(5)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORDEM_CONFECCAO")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.SeqItemPedido)
                    .HasPrecision(3)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SEQ_ITEM_PEDIDO")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.ArtigoProduto)
                    .HasPrecision(4)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ARTIGO_PRODUTO")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.ExecutaTrigger)
                    .HasPrecision(1)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EXECUTA_TRIGGER");

                entity.Property(e => e.GrupoEstoque)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("GRUPO_ESTOQUE")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ItemEstoque)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ITEM_ESTOQUE")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NivelEstoque)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NIVEL_ESTOQUE")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NumeroKit)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NUMERO_KIT")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QtdePecasReal)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("QTDE_PECAS_REAL")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QtdePecasSug)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("QTDE_PECAS_SUG")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QtdeQuilosEstoque)
                    .HasColumnType("NUMBER(8,3)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("QTDE_QUILOS_ESTOQUE")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.QtdeQuilosReal)
                    .HasColumnType("NUMBER(11,3)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("QTDE_QUILOS_REAL")
                    .HasDefaultValueSql("0.000");

                entity.Property(e => e.SubEstoque)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SUB_ESTOQUE")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.HasSequence("ID_REPROG_TINTO");

            modelBuilder.HasSequence("NR_DOC_TRANSFERENCIA");

            modelBuilder.HasSequence("SEC_LIQ");

            modelBuilder.HasSequence("SEQ_AGRUPAMENTO_ORDENS");

            modelBuilder.HasSequence("SEQ_BASI_095");

            modelBuilder.HasSequence("SEQ_CORTE");

            modelBuilder.HasSequence("SEQ_ESTQ_061");

            modelBuilder.HasSequence("SEQ_ESTQ_062");

            modelBuilder.HasSequence("SEQ_ESTQ_063");

            modelBuilder.HasSequence("SEQ_ESTQ_064");

            modelBuilder.HasSequence("SEQ_ESTQ_065");

            modelBuilder.HasSequence("SEQ_ESTQ_066");

            modelBuilder.HasSequence("SEQ_ESTQ_067");

            modelBuilder.HasSequence("SEQ_ESTQ_068");

            modelBuilder.HasSequence("SEQ_ESTQ_069");

            modelBuilder.HasSequence("SEQ_ESTQ_070");

            modelBuilder.HasSequence("SEQ_ESTQ_071");

            modelBuilder.HasSequence("SEQ_ESTQ_072");

            modelBuilder.HasSequence("SEQ_ESTQ_081").IsCyclic();

            modelBuilder.HasSequence("SEQ_ESTQ_302").IsCyclic();

            modelBuilder.HasSequence("SEQ_ESTQ_XXX");

            modelBuilder.HasSequence("SEQ_FINA_490").IsCyclic();

            modelBuilder.HasSequence("SEQ_HDOC_820");

            modelBuilder.HasSequence("SEQ_HIST_100");

            modelBuilder.HasSequence("SEQ_IMPORTACAO").IsCyclic();

            modelBuilder.HasSequence("SEQ_INTE_100");

            modelBuilder.HasSequence("SEQ_INTE_110");

            modelBuilder.HasSequence("SEQ_INTE_810").IsCyclic();

            modelBuilder.HasSequence("SEQ_MAQ");

            modelBuilder.HasSequence("SEQ_MAQNOPROG");

            modelBuilder.HasSequence("SEQ_MEDICIONPH");

            modelBuilder.HasSequence("SEQ_OBRF_150").IsCyclic();

            modelBuilder.HasSequence("SEQ_OBRF_150_LOG").IsCyclic();

            modelBuilder.HasSequence("SEQ_OBRF_151").IsCyclic();

            modelBuilder.HasSequence("SEQ_OBRF_152").IsCyclic();

            modelBuilder.HasSequence("SEQ_OBRF_153").IsCyclic();

            modelBuilder.HasSequence("SEQ_OBRF_154").IsCyclic();

            modelBuilder.HasSequence("SEQ_OBRF_155").IsCyclic();

            modelBuilder.HasSequence("SEQ_OBRF_156").IsCyclic();

            modelBuilder.HasSequence("SEQ_OBRF_157").IsCyclic();

            modelBuilder.HasSequence("SEQ_OBRF_158").IsCyclic();

            modelBuilder.HasSequence("SEQ_OBRF_159").IsCyclic();

            modelBuilder.HasSequence("SEQ_OPER");

            modelBuilder.HasSequence("SEQ_OPER_002").IsCyclic();

            modelBuilder.HasSequence("SEQ_ORD_AGRUP");

            modelBuilder.HasSequence("SEQ_ORD_COMPRA");

            modelBuilder.HasSequence("SEQ_PCPB_170");

            modelBuilder.HasSequence("SEQ_PCPC_070").IsCyclic();

            modelBuilder.HasSequence("SEQ_PCPC_128");

            modelBuilder.HasSequence("SEQ_PCPC_760");

            modelBuilder.HasSequence("SEQ_PEDI_665");

            modelBuilder.HasSequence("SEQ_PEDIDO_COMPRA");

            modelBuilder.HasSequence("SEQ_PROCESOS");

            modelBuilder.HasSequence("SEQ_REGMAE");

            modelBuilder.HasSequence("SEQ_RELATORIO");

            modelBuilder.HasSequence("SEQ_SUPR_510");

            modelBuilder.HasSequence("SEQ_TEJEDURIA");

            modelBuilder.HasSequence("SEQ_TINTORERIA");

            modelBuilder.HasSequence("SEQ_TMRP_635");

            modelBuilder.HasSequence("SEQ_TMRP_636");

            modelBuilder.HasSequence("SEQ_TMRP_650");

            modelBuilder.HasSequence("SEQ_TMRP_720");

            modelBuilder.HasSequence("SEQ_TMRP_731");

            modelBuilder.HasSequence("SEQ_XX_GRUPO_PLANEJAMENTO");

            modelBuilder.HasSequence("SQHND");

            modelBuilder.HasSequence("SQMAI");

            modelBuilder.HasSequence("SQPLAY");

            modelBuilder.HasSequence("SQSQL");

            modelBuilder.HasSequence("SQTAR");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
