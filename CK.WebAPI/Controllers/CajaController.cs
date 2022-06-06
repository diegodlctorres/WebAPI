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

        [HttpGet("Consulta/{numCaja}")]
        public async Task<object> ConsultaCaja(int numCaja)
        {
            var resultado = await service.ConsultaCaja(numCaja);
            return resultado;

        }

        [HttpGet("Consulta2")]
        public async Task<ResponseService<IEnumerable<Caja>>> traerCajas(int numCaja)
        {
            CajaDTO cajas = new CajaDTO();
            var resultado = await service.traerCajas<Caja>(numCaja);
            //cambiar el responseService<list<cajaz>> a responseService<list<cajadto>>
            return resultado;
        }

        [HttpPost("Mover")]
        public async Task<object> MoverCaja(int p_num_caja, string p_cb_prenda, int p_tipo)
        {
            var respuesta = await service.MoverCajas(p_num_caja, p_cb_prenda, p_tipo);
            if(respuesta is null)
            {
                return Ok();
            }
            else
            {
                return respuesta;
            }                       
        }

        [HttpPost("Mover02")]
        public async Task<object> MoverCaja02(MoverCaja mover)
        {
            var respuesta = await service.MoverCajas02(mover);
            if (respuesta is null)
            {
                return Ok();
            }
            else
            {
                return respuesta;
            }
        }

        [HttpPost("Mover03")]
        public async Task<object> MoverCaja03(MoverCaja mover)
        {
            var respuesta = await service.MoverCajas03(mover);
            if (mover.p_new_caja > 1)
            {
                return mover.p_new_caja;
            }
            if (respuesta is null)
            {
                return Ok();
            }
            else
            {
                return respuesta;
            }
        }

    }
}
