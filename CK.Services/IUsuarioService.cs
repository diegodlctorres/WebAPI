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
        Task<ResponseService<AppUserAccess>> HoraIngreso(decimal codFuncionario);
        Task<object> LoginSp(decimal codFuncionario, decimal constrasena);
    }
}
