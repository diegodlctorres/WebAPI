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

        [HttpGet("ckuser/{codFuncionario}")]
        public async Task<ActionResult<UsuarioDTO>> BuscarPorCodFuncionario(decimal codFuncionario)
        {
            var retorno = await service.BuscarPorCodFuncionario(codFuncionario);

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDataTransferObject();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpGet("efic050/{codFuncionario02}")]
        public async Task<ActionResult<Efic050DTO>> BuscarEfic050CodFuncionatio(decimal codFuncionario02)
        {
            var retorno = await service.BuscarEfic050CodFuncionatio(codFuncionario02);

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDataTransferObject();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpPost("movil/{cf}/{contra}")]
        public async Task<ActionResult<UserLogeadoDTO>> Login(int cf , decimal contra)
        {
            UserLogeadoDTO userlogeado = new UserLogeadoDTO();
            userlogeado.CodFuncionario = cf;
            userlogeado.Contrasena = contra;
            var ckuser = await service.BuscarPorCodFuncionario((decimal)userlogeado.CodFuncionario);
            if (ckuser.Error != null)
            {
                var efic050 = await service.BuscarEfic050CodFuncionatio((decimal)userlogeado.CodFuncionario);
                if (efic050.Error != null)
                {
                    return StatusCode(efic050.Status, efic050.Error);
                }
                else
                {
                    return StatusCode(ckuser.Status, ckuser.Error);
                }
            }
            else
            {
                var ckuserTrue = await service.GetValidateCkUser(Mapper.ToModel(userlogeado));
                if (ckuserTrue.Error != null)
                {
                    return StatusCode(ckuserTrue.Status, ckuserTrue.Error);
                }
                else
                {
                    var efic050 = await service.BuscarEfic050CodFuncionatio((decimal)userlogeado.CodFuncionario);
                    UserLogeadoDTO usuario = new UserLogeadoDTO
                    {
                        CodFuncionario = efic050.Objeto.CodFuncionario,
                        Contrasena = (int)ckuser.Objeto.ClaveAlt,
                        Nome = efic050.Objeto.Nome
                    };
                    return ckuserTrue.Objeto.ToDataTransferObject();
                }
            }
        }

        [HttpPost("sp/{cf}/{contra}")]
        public async Task<ActionResult<UserLogeadoDTO>> IniciarSesión(int cf, decimal contra)
        {
            UserLogeadoDTO userlogeado = new UserLogeadoDTO();
            userlogeado.CodFuncionario = cf;
            userlogeado.Contrasena = contra;
            var ckuser = await service.GetAppUserCodFuncionario((decimal)cf);
            if (ckuser.Error != null)
            {
                var efic050 = await service.BuscarEfic050CodFuncionatio((decimal)userlogeado.CodFuncionario);
                if (efic050.Error != null)
                {
                    return StatusCode(efic050.Status, efic050.Error);
                }
                else
                {
                    return StatusCode(ckuser.Status, ckuser.Error);
                }
            }
            else
            {
                var ckuserTrue = await service.GetIniciarSesion(Mapper.ToModel(userlogeado));
                if (ckuserTrue.Error != null)
                {
                    return StatusCode(ckuserTrue.Status, ckuserTrue.Error);
                }
                else
                {
                    await service.HoraIngreso(cf);
                    return ckuserTrue.Objeto.ToDataTransferObject();
                }
            }

        }
    }
}
