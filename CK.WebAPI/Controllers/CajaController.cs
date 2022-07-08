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
        //Consultar Caja - Módulo
        [HttpGet("Consulta/{numCaja}")]
        public async Task<object> ConsultaCaja(int numCaja)
        {
            var resultado = await service.ConsultaCaja(numCaja);
            return resultado;

        }
        //Quitar-Agregar Prenda en Caja
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
        //Crear Caja
        [HttpPost("Mover03")]
        public async Task<object> MoverCaja03(MoverCaja mover)
        {
            var respuesta = await service.MoverCajas03(mover);
            if (respuesta != null)
            {
                return respuesta;
            }
            else
            {
                return Ok();
            }
        }

    }
}
