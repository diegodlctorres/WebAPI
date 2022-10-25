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
    public class PrendasController : ControllerBase
    {
        private readonly IPrendasService service;
        public PrendasController(IPrendasService service)
        {
            this.service = service;
        }

        [HttpGet("imagen/{codPrenda}")]
        public async Task<object> ConsultarPrenda(string codPrenda)
        {
            var respuesta = await service.ConsultarPrenda(codPrenda);
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
