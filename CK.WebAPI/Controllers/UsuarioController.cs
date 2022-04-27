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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService service;

        public UsuarioController(IUsuarioService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> Listar()
        {
            var retorno = await service.Listar();

            if (retorno.Objeto != null)
                //return retorno.Objeto.Select(x => x.ToDataTransferObject()).ToList();
                return retorno.Objeto.Select(Mapper.ToDataTransferObject).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpGet("{codFuncionario}")]
        public async Task<ActionResult<UsuarioDTO>> BuscarPorCodFuncionario(decimal codFuncionario)
        {
            var retorno = await service.BuscarPorCodFuncionario(codFuncionario);

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDataTransferObject();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }
    }
}
