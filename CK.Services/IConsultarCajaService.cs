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

<<<<<<< HEAD
        Task<ResponseService<List<Caja>>> ConsultaCaja(int numCaja);

        Task<ResponseService<IEnumerable<T>>> traerCajas<T>(int numCaja);
=======
        Task<object> PruebaError(int cf, int clave);

>>>>>>> f2269d7cbd008ff56aa27832c4b62cad2042a8a1
    }
}
