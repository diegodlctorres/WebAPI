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
        Task<object> ConsultaCaja(int numCaja);

        Task<object> MoverCajas02(MoverCaja mover);

        Task<object> MoverCajas03(MoverCaja mover);

    }
}
