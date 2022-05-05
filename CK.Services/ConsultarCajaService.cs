using CK.DataAccess.Models;
using CK.SPAccess;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Services
{
    public class ConsultarCajaService : IConsultarCajaService
    {
        private ModelContext context;

        public ConsultarCajaService(ModelContext context)
        {
            this.context = context;
        }

        public async Task<object> Listar()
        {
            CottonData db = new CottonData();
            DbParametro[] parameters = new DbParametro[3];
            parameters[0] = new DbParametro("p_cod_funcionario", 1);
            parameters[1] = new DbParametro("p_contrasena", 1);
            parameters[2] = new DbParametro("p_codigo_aplicacion", 1);

            var linea = await db.GetData("CKPRUEBALOGIN", parameters);//Nombre del store
            return linea;

        }
        public async Task<object> PruebaError(int cf, int clave)
        {
            try
            {
                CottonData db = new CottonData();
                DbParametro[] parameters = new DbParametro[3];
                parameters[0] = new DbParametro("p_cod_funcionario", cf);
                parameters[1] = new DbParametro("p_contrasena", clave);
                parameters[2] = new DbParametro("p_codigo_aplicacion", 1);

                var linea = await db.GetData("getck_app_login", parameters);//Nombre del store
                return linea;
            }
            catch (OracleException e)
            {
                Error error = new Error(){
                    Code = e.ErrorCode,
                    Mensaje = e.Message
                };
                return error;
            }           
        }
    }
}
