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

        Task<object> ConsultaCaja(int numCaja);

        Task<ResponseService<IEnumerable<T>>> traerCajas<T>(int numCaja);

        Task<object> PruebaError(int cf, int clave);

        Task<object> MoverCajas(int p_num_caja, string p_cb_prenda, int p_tipo);

        Task<object> MoverCajas02(MoverCaja mover);

        Task<object> MoverCajas03(MoverCaja mover);

    }
}
