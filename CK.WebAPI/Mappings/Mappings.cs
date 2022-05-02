using CK.DataAccess.Models;
using CK.DataTransferObject;

namespace CK.WebAPI.Mappings
{
    public static partial class Mapper
    {
        //Métodos de extensión
        public static UsuarioDTO ToDataTransferObject(this CkUser model)  // Convierte de ModelContext a DTO
        {
            return new UsuarioDTO()
            {
                Login = model.Login,
                Email = model.Email,
                Usrcre = model.Usrcre,
                Wkscre = model.Wkscre,
                Fchcre = model.Fchcre,
                Usrmod = model.Usrmod,
                Wksmod = model.Wksmod,
                Fchmod = model.Fchmod,
                Flgeli = model.Flgeli,
                Codperf = model.Codperf,
                Nombres = model.Nombres,
                Observacion = model.Observacion,
                Clave = model.Clave,
                Flgval = model.Flgval,
                Iso1 = model.Iso1,
                Iso2 = model.Iso2,
                CodEmpresa = model.CodEmpresa,
                CodFuncionario = model.CodFuncionario,
                Flgiso = model.Flgiso,
                Appversion = model.Appversion,
                FecAcceso = model.FecAcceso,
                ClaveAlt = model.ClaveAlt,
                SessionNumber = model.SessionNumber,
                ClaveApp = model.ClaveApp
            };
        }
    }

    public static partial class Mapper
    {
        public static CkUser ToModel(this UsuarioDTO dto)  // Convierte de DTO a ModelContext
        {
            return new CkUser()
            {
                Login = dto.Login,
                Email = dto.Email,
                Usrcre = dto.Usrcre,
                Wkscre = dto.Wkscre,
                Fchcre = dto.Fchcre,
                Usrmod = dto.Usrmod,
                Wksmod = dto.Wksmod,
                Fchmod = dto.Fchmod,
                Flgeli = dto.Flgeli,
                Codperf = dto.Codperf,
                Nombres = dto.Nombres,
                Observacion = dto.Observacion,
                Clave = dto.Clave,
                Flgval = dto.Flgval,
                Iso1 = dto.Iso1,
                Iso2 = dto.Iso2,
                CodEmpresa = dto.CodEmpresa,
                CodFuncionario = dto.CodFuncionario,
                Flgiso = dto.Flgiso,
                Appversion = dto.Appversion,
                FecAcceso = dto.FecAcceso,
                ClaveAlt = dto.ClaveAlt,
                SessionNumber = dto.SessionNumber,
                ClaveApp = dto.ClaveApp
            };
        }
    }

    //DTO EFIC_050
    public static partial class Mapper
    {
        //Métodos de extensión
        public static Efic050DTO ToDataTransferObject(this Efic050 model)  // Convierte de ModelContext a DTO
        {
            return new Efic050DTO()
            {

                CodEmpresa=model.CodEmpresa,
                CodFuncionario=model.CodFuncionario,
                Nome=model.Nome,
                Turno=model.Turno,
                LancaParada=model.LancaParada,
                LancaRejeicao=model.LancaRejeicao,
                CodigoCargo=model.CodigoCargo,
                CentroCusto=model.CentroCusto,
                DataNascimento=model.DataAdmissao,
                DataAdmissao=model.DataAdmissao,
                Sexo=model.Sexo,
                EstadoCivil=model.EstadoCivil,
                GrauInstrucao=model.GrauInstrucao,
                PlanoSaude=model.PlanoSaude,
                CpfFunc=model.CpfFunc,
                CustoHora=model.CustoHora,
                ResponsavelDados=model.ResponsavelDados,
                EMail=model.EMail,
                Ramal=model.Ramal,
                Observacao= model.Observacao,
                CrachaFuncionario=model.CrachaFuncionario,
                SetorResponsavel=model.SetorResponsavel,
                SitFuncionario=model.SitFuncionario,
                LancaHrsManu=model.LancaHrsManu,
                FlgDestajo=model.FlgDestajo
            };
        }
    }

    public static partial class Mapper
    {
        public static Efic050 ToModel(this Efic050DTO dto)  // Convierte de DTO a ModelContext
        {
            return new Efic050()
            {
                CodEmpresa = dto.CodEmpresa,
                CodFuncionario = dto.CodFuncionario,
                Nome = dto.Nome,
                Turno = dto.Turno,
                LancaParada = dto.LancaParada,
                LancaRejeicao = dto.LancaRejeicao,
                CodigoCargo = dto.CodigoCargo,
                CentroCusto = dto.CentroCusto,
                DataNascimento = dto.DataAdmissao,
                DataAdmissao = dto.DataAdmissao,
                Sexo = dto.Sexo,
                EstadoCivil = dto.EstadoCivil,
                GrauInstrucao = dto.GrauInstrucao,
                PlanoSaude = dto.PlanoSaude,
                CpfFunc = dto.CpfFunc,
                CustoHora = dto.CustoHora,
                ResponsavelDados = dto.ResponsavelDados,
                EMail = dto.EMail,
                Ramal = dto.Ramal,
                Observacao = dto.Observacao,
                CrachaFuncionario = dto.CrachaFuncionario,
                SetorResponsavel = dto.SetorResponsavel,
                SitFuncionario = dto.SitFuncionario,
                LancaHrsManu = dto.LancaHrsManu,
                FlgDestajo = dto.FlgDestajo
            };
        }
    }


    public static partial class Mapper
    {
        //Métodos de extensión
        public static UserLogeadoDTO ToDataTransferObject(this AppUserLogin model)  // Convierte de ModelContext a DTO
        {
            return new UserLogeadoDTO()
            {
                CodFuncionario = model.CodFuncionario,
                Contrasena=model.Contrasena ,
                Nome = model.Nome,
             };
        }
    }

    public static partial class Mapper
    {
        public static AppUserLogin ToModel(this UserLogeadoDTO dto)  // Convierte de DTO a ModelContext
        {
            return new AppUserLogin()
            {
                CodFuncionario = dto.CodFuncionario,
                Contrasena = dto.Contrasena,
                Nome = dto.Nome,
            };
        }
    }



}
