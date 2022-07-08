using CK.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Oracle.ManagedDataAccess.Client;
using CK.SPAccess;
using System.Linq;

namespace CK.Services
{
    public class UsuarioService : IUsuarioService
    {
        private ModelContext context;

        public UsuarioService(ModelContext context)
        {
            this.context = context;
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

        public async Task<object> LoginSp(decimal codFuncionario, decimal contrasena)
        {
            var usuario = new ResponseService<Usuario>();
            try
            {
                CottonData db = new CottonData();
                DbParametro[] parameters = new DbParametro[3];
                parameters[0] = new DbParametro("p_cod_funcionario", codFuncionario);
                parameters[1] = new DbParametro("p_contrasena", contrasena);
                parameters[2] = new DbParametro("p_codigo_aplicacion", 3);

                IEnumerable<dynamic> linea = await db.getDynamic("getck_app_login", parameters);//Nombre del store

                mapear(linea, usuario);
                Usuario app = new Usuario();
                app = usuario.Objeto;

                return usuario.Objeto;

            }
            catch (OracleException e)
            {
                Error error = new Error()
                {
                    Code = e.ErrorCode,
                    Mensaje = e.Message
                };
                return error;
            }
        }

        public void mapear(IEnumerable<dynamic> resultado, ResponseService<Usuario> modelo)
        {
            Usuario app = new Usuario();
            modelo.Objeto = app;
            for (int i = 0; i < resultado.Count() ; i++)
            {
                modelo.Objeto.CodFuncionario = Convert.ToDecimal(resultado.ElementAt(i).COD_FUNCIONARIO);
                modelo.Objeto.Contrasena = Convert.ToDecimal(resultado.ElementAt(i).CONTRASENA);
                modelo.Objeto.Nome = resultado.ElementAt(i).NOME;
            }
            
        }
    }
}
