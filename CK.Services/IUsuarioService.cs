using CK.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Services
{
    public interface IUsuarioService
    {
        Task<ResponseService<List<CkUser>>> Listar();
        Task<ResponseService<CkUser>> BuscarPorCodFuncionario(decimal codFuncionario);

        Task<ResponseService<Efic050>> BuscarEfic050CodFuncionatio(decimal codFuncionaio);

        Task<ResponseService<AppUserLogin>> GetValidateCkUser(AppUserLogin userlogeado);

    }
}
