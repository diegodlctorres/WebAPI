using CK.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace CK.Services
{
    public class UsuarioService : IUsuarioService
    {
        private ModelContext context;

        public UsuarioService(ModelContext context)
        {
            this.context = context;
        }

        public async Task<ResponseService<CkUser>> BuscarPorCodFuncionario(decimal codFuncionario)
        {
            var respuesta = new ResponseService<CkUser>();
            var usuario = await context.CkUsers.FirstOrDefaultAsync(x => x.CodFuncionario == codFuncionario);

            if (usuario != null)
                respuesta.Objeto = usuario;
            else
                respuesta.AgregarBadRequest("Usuario no registrado, comunicarse con sistemas.");

            return respuesta;
        }

        public async Task<ResponseService<Usuario>> BuscarEfic050CodFuncionatio(decimal codFuncionario)
        {
            var respuesta = new ResponseService<Usuario>();
            var usuario = await context.Efic050s.FirstOrDefaultAsync(x => x.CodFuncionario == codFuncionario);

            if (usuario != null)
            {
                Usuario app = new Usuario()
                {
                    CodFuncionario = (decimal)usuario.CodFuncionario,
                    //Contrasena = (int)usuario.ClaveAlt,
                    Nome = usuario.Nome
                };
                respuesta.Objeto = app;
            }
            else
            {
                Usuario app = new Usuario();
                respuesta.Objeto = app;
                respuesta.Objeto.Mensaje = "Código de Funcionario Inexistente.";
            }
                //respuesta.AgregarBadRequest("Código de Funcionario Inexistente.");

            return respuesta;
        }

        public async Task<ResponseService<Usuario>> GetValidateCkUser(Usuario userlogeado)
        {
            var respuesta = new ResponseService<Usuario>();
            CkUser usuario = new CkUser();
            usuario.CodFuncionario = userlogeado.CodFuncionario;
            usuario.ClaveAlt = (int)userlogeado.Contrasena;
            var userlogin = await context.CkUsers.FirstOrDefaultAsync(x => x.CodFuncionario == usuario.CodFuncionario && x.ClaveAlt == usuario.ClaveAlt);
            var userlogin02 = await context.Efic050s.FirstOrDefaultAsync(x => x.CodFuncionario == userlogeado.CodFuncionario);

            if (userlogin != null)
            {
                Usuario app = new Usuario()
                {
                    CodFuncionario = (decimal)userlogin.CodFuncionario,
                    Contrasena = (int)userlogin.ClaveAlt,
                    Nome = userlogin.Nombres
                };
                respuesta.Objeto = app;
            }
            else
            {
                //respuesta.AgregarBadRequest("Codigo de funcionario y contraseña no coinciden.");
                Usuario app = new Usuario();
                respuesta.Objeto = app;
                respuesta.Objeto.Mensaje = "Codigo de funcionario y contraseña no coinciden.";
            }
            return respuesta;
        }

        public async Task<ResponseService<Usuario>> GetAppUserCodFuncionario(decimal codFuncionario)
        {
            var respuesta = new ResponseService<Usuario>();
            var userlogin = await context.AppUsers.FirstOrDefaultAsync(x => x.CodFuncionario == codFuncionario);
            if (userlogin != null)
            {
                Usuario resultado = new Usuario()
                {
                    Contrasena = userlogin.Contrasena,
                    CodFuncionario = userlogin.CodFuncionario,                 
                };
                respuesta.Objeto = resultado;
            }
            else
            {
                //respuesta.AgregarBadRequest("Usuario no registrado, comunicarse con sistemas.");
                Usuario app = new Usuario();
                respuesta.Objeto = app;
                respuesta.Objeto.Mensaje = "Usuario no registrado, comunicarse con sistemas.";
            }
            return respuesta;
        }
        public async Task<ResponseService<Usuario>> GetIniciarSesion(Usuario userlogeado)
        {
            var respuesta = new ResponseService<Usuario>();
            Usuario usuario = new Usuario();
            usuario.CodFuncionario = userlogeado.CodFuncionario;
            usuario.Contrasena = (int)userlogeado.Contrasena;
            var userlogin = await context.AppUsers.FirstOrDefaultAsync(x => x.CodFuncionario == usuario.CodFuncionario && x.Contrasena == usuario.Contrasena);
            var userlogin02 = await context.CkUsers.FirstOrDefaultAsync(x => x.CodFuncionario == usuario.CodFuncionario && x.ClaveAlt == usuario.Contrasena);
            //var userlogin02 = await context.Efic050s.FirstOrDefaultAsync(x => x.CodFuncionario == userlogeado.CodFuncionario);

            if (userlogin != null)
            {
                Usuario app = new Usuario()
                {
                    CodFuncionario = (decimal)userlogin.CodFuncionario,
                    Contrasena = (int)userlogin.Contrasena,
                    Nome = userlogin02.Nombres
                };
                respuesta.Objeto = app;
            }
            else
            {
                //respuesta.AgregarBadRequest("Código de colaborador y contraseña no coinciden.");
                Usuario app = new Usuario();
                respuesta.Objeto = app;
                respuesta.Objeto.Mensaje = "Código de colaborador y contraseña no coinciden.";
            }
            return respuesta;
        }

        public async Task<ResponseService<AppUserAccess>> HoraIngreso(decimal codFuncionario)
        {
            var respuesta = new ResponseService<AppUserAccess>();
            var userlogin = await context.AppUserAccesses.FirstOrDefaultAsync(x => x.CodFuncionario == codFuncionario);
            var hora = System.DateTime.Now;
            if(userlogin != null)
            {
                userlogin.UltimoAcceso = hora;

                respuesta.Objeto = userlogin;
                await context.SaveChangesAsync();
            }
            else
            {
                respuesta.AgregarBadRequest("Usuario no registrado, comunicarse con sistemas.");
            }
            return respuesta;

        }

    }
}
