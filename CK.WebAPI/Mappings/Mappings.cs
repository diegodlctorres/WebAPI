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
}
