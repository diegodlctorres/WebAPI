using CK.DataAccess.Models;
using CK.SPAccess;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Services
{
    public class PrendasService : IPrendasService
    {
        private ModelContext context;

        public PrendasService(ModelContext context)
        {
            this.context = context;
        }
        public async Task<object> ConsultarPrenda(string codPrenda)
        {
            try
            {
                CottonData db = new CottonData();
                DbParametro[] parameters = new DbParametro[1];
                parameters[0] = new DbParametro("p_cb_prenda", codPrenda);

                var linea = await db.GetData("SP_CEL_ALM_SLD_PRD_RUTA_IMG", parameters, "curSQL");//Nombre del store
                IEnumerable<dynamic> aux = (IEnumerable<dynamic>)linea;               
                if (aux.Count() == 0 )
                {
                    return linea;
                }
                else
                {
                    var PrendaResultado = new List<Prenda>();
                    foreach (var asd in aux)
                    {
                        var prenda = new Prenda();
                        prenda.urlPrenda = asd.RUTA_ARCHIVO;
                        PrendaResultado.Add(prenda);
                    }
                    return PrendaResultado[0];
                }
                
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
    }
}
