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
        //Task<object> Listar();

        //Task<object> ConsultaCaja(int numCaja);

        Task<ResponseService<IEnumerable<T>>> ConsultaCaja<T>(int numCaja);

        //Task<object> PruebaError(int cf, int clave);

    }
}
