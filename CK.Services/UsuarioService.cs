using CK.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    }
}
