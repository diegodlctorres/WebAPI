using CK.DataAccess.Models;
using CK.DataTransferObject;
using CK.Services;
using CK.WebAPI.Mappings;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CK.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CajaController : ControllerBase
    {
        private readonly IConsultarCajaService service;

        public CajaController(IConsultarCajaService service)
        {
            this.service = service;
        }

        [HttpGet("Listar")]
        public async Task<object> ListarSPdelMongol()
        {
            var resultado = await service.Listar();
            return resultado;
        }

        [HttpGet("Consulta")]
        public async Task<ResponseService<List<CajaDTO>>> ConsultaCaja(int numCaja)
        {
                var resultado = await service.ConsultaCaja(numCaja);

            CajaDTO cajas = new CajaDTO();


            var resultado2 = new ResponseService<List<CajaDTO>>();

            if (resultado.Objeto == null)
            {
                resultado2.Error = resultado.Error;
                return resultado2;
            }

            resultado2.Objeto = resultado.Objeto.ToDataTransferObject();
            return resultado2;

        }

        [HttpGet("Consulta2")]
        public async Task<ResponseService<IEnumerable<Caja>>> traerCajas(int numCaja)
        {
            CajaDTO cajas = new CajaDTO();
            var resultado = await service.traerCajas<Caja>(numCaja);
            //cambiar el responseService<list<cajaz>> a responseService<list<cajadto>>
            return resultado;
        }

    }
}
