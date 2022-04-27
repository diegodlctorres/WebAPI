using CK.DataAccess.Models;
using CK.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CK.WebAPI.Mappings;
using CK.DataTransferObject;

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
        public async Task<ActionResult<List<CkUser>>> Listar()
        {
            var retorno = await service.Listar();

            if (retorno.Objeto != null)
                return retorno.Objeto;
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpGet("{CodFuncionario}")]
        public async Task<ActionResult<CkUser>> BuscarPorCodFuncionario(decimal codFuncionario)
        {
            var retorno = await service.BuscarPorCodFuncionario(codFuncionario);

            if (retorno.Objeto != null)
                return retorno.Objeto;
            else
                return StatusCode(retorno.Status, retorno.Error);
        }
    }
}
