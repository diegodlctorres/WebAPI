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

        //[HttpGet("Listar")]
        //public async Task<object> ListarSPdelMongol()
        //{
        //    var resultado = await service.Listar();
        //    return resultado;
        //}

        //[HttpGet("Consulta/{numCaja}")]
        //public async Task<object> ConsultaCaja(int numCaja)
        //{
        //    var resultado = await service.ConsultaCaja(numCaja);
        //    return resultado;

        //}

        [HttpGet("Consulta/{numCaja}")]
        public async Task<ResponseService<IEnumerable<CajaDTO>>> ConsultaCaja(int numCaja)
        {
            var response = new ResponseService<IEnumerable<CajaDTO>>();
            var seeker = await service.ConsultaCaja<Caja>(numCaja);

            if (seeker.Objeto != null)
                response.Objeto = seeker.Objeto.ToDataTransferObject();
            else
                response.AgregarBadRequest(seeker.Error);
            return response;

            //CajaDTO cajas = new CajaDTO();
            //var resultado = await service.ConsultaCaja<Caja>(numCaja);
            ////cambiar el responseService<list<cajaz>> a responseService<list<cajadto>>
            //return resultado;
        }

    }
}
