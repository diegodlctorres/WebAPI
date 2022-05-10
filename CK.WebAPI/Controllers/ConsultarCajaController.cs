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
    public class ConsultarCajaController : ControllerBase
    {
        private readonly IConsultarCajaService service;

        public ConsultarCajaController(IConsultarCajaService service)
        {
            this.service = service;
        }

        [HttpGet("Listar")]
        public async Task<object> ListarSPdelMongol()
        {
            var resultado = await service.Listar();
            return resultado;
        }

        [HttpGet("Error")]
        public async Task<object> MaicolFueError()
        {
            int cf = 50505;
            int clave = 1234;
            var resultado = await service.PruebaError(cf,clave);
            return resultado;
        }


    }
}
