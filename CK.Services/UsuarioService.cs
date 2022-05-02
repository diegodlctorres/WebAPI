using CK.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CK.Services
{
    public class UsuarioService : IUsuarioService
    {
        private ModelContext context;

        public UsuarioService(ModelContext context)
        {
            this.context = context;
        }

        public async Task<ResponseService<List<CkUser>>> Listar()
        {
            var respuesta = new ResponseService<List<CkUser>>();
            var lista = await context.CkUsers.ToListAsync();

            if (lista != null)
                respuesta.Objeto = lista;
            else
                respuesta.AgregarInternalServerError("Se encontró un error.");

            return respuesta;
        }

        public async Task<ResponseService<CkUser>> BuscarPorCodFuncionario(decimal codFuncionario)
        {
            var respuesta = new ResponseService<CkUser>();
            var usuario = await context.CkUsers.FirstOrDefaultAsync(x => x.CodFuncionario == codFuncionario);

            if (usuario != null)
                respuesta.Objeto = usuario;
            else
                respuesta.AgregarBadRequest("El código de funcionario no está registrado.");

            return respuesta;
        }

        public async Task<ResponseService<Efic050>> BuscarEfic050CodFuncionatio(decimal codFuncionario)
        {
            var respuesta = new ResponseService<Efic050>();
            var usuario = await context.Efic050s.FirstOrDefaultAsync(x => x.CodFuncionario == codFuncionario);

            if (usuario != null)
                respuesta.Objeto = usuario;
            else
                respuesta.AgregarBadRequest("El código de funcionario no está registrado.");

            return respuesta;
        }

        public async Task<ResponseService<AppUserLogin>> GetValidateCkUser(AppUserLogin userlogeado)
        {
            var respuesta = new ResponseService<AppUserLogin>();
            CkUser usuario = new CkUser();
            usuario.CodFuncionario = userlogeado.CodFuncionario;
            usuario.ClaveAlt = (int)userlogeado.Contrasena;
            var userlogin = await context.CkUsers.FirstOrDefaultAsync(x => x.CodFuncionario == usuario.CodFuncionario && x.ClaveAlt == usuario.ClaveAlt);
            var userlogin02 = await context.Efic050s.FirstOrDefaultAsync(x => x.CodFuncionario == userlogeado.CodFuncionario);

            if (userlogin != null)
            {
                AppUserLogin app = new AppUserLogin()
                {
                    CodFuncionario = (decimal)userlogin.CodFuncionario,
                    Contrasena = (int)userlogin.ClaveAlt,
                    Nome = userlogin.Nombres
                };
                respuesta.Objeto = app;
            }
            else
            {
                respuesta.AgregarBadRequest("El código de funcionario no está registrado.");
            }
            return respuesta;
        }

        

    }
}
