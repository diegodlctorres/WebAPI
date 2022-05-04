using CK.DataAccess.Models;
using CK.DataTransferObject;

namespace CK.WebAPI.Mappings
{

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
        public static UsuarioDTO ToDataTransferObject(this Usuario model)  // Convierte de ModelContext a DTO
        {
            return new UsuarioDTO()
            {
                CodFuncionario = model.CodFuncionario,
                Contrasena=model.Contrasena ,
                Nome = model.Nome,
                Mensaje = model.Mensaje
             };
        }
    }

    public static partial class Mapper
    {
        public static Usuario ToModel(this UsuarioDTO dto)  // Convierte de DTO a ModelContext
        {
            return new Usuario()
            {
                CodFuncionario = dto.CodFuncionario,
                Contrasena = dto.Contrasena,
                Nome = dto.Nome,
                Mensaje = dto.Mensaje
            };
        }
    }



}
