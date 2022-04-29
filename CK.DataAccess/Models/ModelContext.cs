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

        public virtual DbSet<AppMobileInfo> AppMobileInfos { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<AppUserAccess> AppUserAccesses { get; set; }
        public virtual DbSet<CkPerfil> CkPerfils { get; set; }
        public virtual DbSet<CkUser> CkUsers { get; set; }
        public virtual DbSet<Efic050> Efic050s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("USYSTEX");

            modelBuilder.Entity<AppMobileInfo>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("APP_MOBILE_INFO_PK");

                entity.ToTable("APP_MOBILE_INFO");

                entity.Property(e => e.Codigo)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CODIGO");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Repositorio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REPOSITORIO");

                entity.Property(e => e.Version)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VERSION");
            });

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.CodFuncionario)
                    .HasName("APP_USER_PK");

                entity.ToTable("APP_USER");

                entity.Property(e => e.CodFuncionario)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("COD_FUNCIONARIO");

                entity.Property(e => e.Contrasena)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTRASENA");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasPrecision(1)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ESTADO")
                    .HasDefaultValueSql("1 ");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FECHA_ACTUALIZACION")
                    .HasDefaultValueSql("SYSDATE ");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("SYSDATE ");

                entity.Property(e => e.UsuarioActualizacion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USUARIO_ACTUALIZACION");

                entity.Property(e => e.UsuarioRegistro)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USUARIO_REGISTRO");
            });

            modelBuilder.Entity<AppUserAccess>(entity =>
            {
                entity.HasKey(e => e.CodFuncionario)
                    .HasName("APP_USER_ACCESS_PK");

                entity.ToTable("APP_USER_ACCESS");

                entity.Property(e => e.CodFuncionario)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("COD_FUNCIONARIO");

                entity.Property(e => e.CodigoApp)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CODIGO_APP");

                entity.Property(e => e.UltimoAcceso)
                    .HasColumnType("DATE")
                    .HasColumnName("ULTIMO_ACCESO");
            });

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

            modelBuilder.HasSequence("APP_MOBILE_INFO_SEQ");

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
