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
    }
}
