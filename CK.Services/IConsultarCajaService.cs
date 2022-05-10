using CK.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Services
{
    public interface IConsultarCajaService
    {
        Task<object> Listar();
        Task<ResponseService<List<Caja>>> ConsultaCaja(int numCaja);

        Task<ResponseService<IEnumerable<T>>> traerCajas<T>(int numCaja);

        Task<object> PruebaError(int cf, int clave);

    }
}
