using CK.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CK.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private ModelContext context;
        public UsuarioController(ModelContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<CkUser>> Listar()
        {
            return await context.CkUsers.ToListAsync();
        }

        [HttpGet("{CodFuncionario}")]
        public async Task<ActionResult<CkUser>> BuscarPorId(decimal CodFuncionario)
        {
            var usuario = await context.CkUsers.FirstOrDefaultAsync(x => x.CodFuncionario == CodFuncionario);

            if (usuario != null)
                return usuario;
            else
                return NotFound();
        }

        //[HttpPost]
        //public async Task<ActionResult<CkUser>> Guardar(CkUser c)
        //{
        //    try
        //    {
        //        await context.CkUsers.AddAsync(c);
        //        await context.SaveChangesAsync();
        //        c.Id = await context.CkUsers.MaxAsync(u => u.Id);

        //        return c;
        //    }
        //    catch (DbUpdateException)
        //    {
        //        return StatusCode(500, "Se encontró un error");
        //    }
        //}

        //[HttpPut]
        //public async Task<ActionResult<CkUser>> Actualizar(CkUser c)
        //{
        //    if (c == null || c.Id == 0)
        //        return BadRequest("Faltan datos");

        //    CkUser cat = await context.CkUsers.FirstOrDefaultAsync(x => x.Id == c.Id);

        //    if (cat == null)
        //        return NotFound();

        //    try
        //    {
        //        cat.Nombre = c.Nombre;
        //        context.CkUsers.Update(cat);
        //        await context.SaveChangesAsync();

        //        return cat;
        //    }
        //    catch (DbUpdateException)
        //    {
        //        return StatusCode(500, "Se encontró un error");
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<bool>> Eliminar(decimal id)
        //{
        //    CkUser cat = await context.CkUsers.FirstOrDefaultAsync(x => x.Id == id);

        //    if (cat == null)
        //        return NotFound();

        //    try
        //    {
        //        context.CkUsers.Remove(cat);
        //        await context.SaveChangesAsync();
        //        return true;
        //    }
        //    catch (DbUpdateException)
        //    {
        //        return StatusCode(500, "Se encontró un error");
        //    }
        //}
    }
}
