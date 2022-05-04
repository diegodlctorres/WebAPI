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

        //POST para el usuario login en la app móvil.
        [HttpPost("movil")]
        public async Task<ActionResult<UsuarioDTO>> Login(UsuarioDTO userlogeado)
        {
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
                    UsuarioDTO usuario = new UsuarioDTO
                    {
                        CodFuncionario = efic050.Objeto.CodFuncionario,
                        Contrasena = (int)ckuser.Objeto.ClaveAlt,
                        Nome = efic050.Objeto.Nome
                    };
                    return ckuserTrue.Objeto.ToDataTransferObject();
                }
            }
        }

        //Obtener Login para el Usuario en la App móvil según la tabla AppUser y EFIC_050.
        [HttpGet("login/{codFuncionario}/{contrasena}")]
        public async Task<ActionResult<UsuarioDTO>> IniciarSesión02(int codFuncionario, decimal contrasena)
        {
            UsuarioDTO userlogeado = new UsuarioDTO();
            userlogeado.CodFuncionario = codFuncionario;
            userlogeado.Contrasena = contrasena;
            var ckuser = await service.GetAppUserCodFuncionario((decimal)userlogeado.CodFuncionario);
            if (ckuser.Objeto.Mensaje != null)
            {
                var efic050 = await service.BuscarEfic050CodFuncionatio((decimal)userlogeado.CodFuncionario);
                if (efic050.Objeto.Mensaje != null)
                {
                    //return StatusCode(efic050.Status, efic050.Error);
                    return efic050.Objeto.ToDataTransferObject();
                }
                else
                {
                    //return StatusCode(ckuser.Status, ckuser.Error);
                    return ckuser.Objeto.ToDataTransferObject();
                }
            }
            else
            {
                var ckuserTrue = await service.GetIniciarSesion(Mapper.ToModel(userlogeado));
                if (ckuserTrue.Objeto.Mensaje != null)
                {
                    //return StatusCode(ckuserTrue.Status, ckuser.Error);
                    return ckuserTrue.Objeto.ToDataTransferObject();
                }
                else
                {
                    await service.HoraIngreso(userlogeado.CodFuncionario);
                    return ckuserTrue.Objeto.ToDataTransferObject();
                }
            }

        }
    }
}
