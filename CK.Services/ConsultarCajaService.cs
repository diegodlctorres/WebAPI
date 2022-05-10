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

        public async Task<ResponseService<List<Caja>>> ConsultaCaja(int numCaja)
        {
            CottonData db = new CottonData();
            DbParametro[] parameters = new DbParametro[1];
            parameters[0] = new DbParametro("p_num_caja", numCaja);

            var linea = await db.GetData("SP_CEL_ALM_SLD_PRD_CONSULTA", parameters, "curSQL");
            
            var RespuestaCaja = new ResponseService<List<Caja>>();

            if (linea.GetType().Name.Contains("OracleException"))
            {
                RespuestaCaja.Error = linea.ToString();
                return RespuestaCaja;
            }

            List<Caja> cajas = mapearCajas(linea);

            RespuestaCaja.Objeto = cajas;

            return RespuestaCaja;
        }

        public async Task<ResponseService<IEnumerable<T>>> traerCajas<T>(int numCaja)
        {
            CottonData db = new CottonData();
            DbParametro[] parameters = new DbParametro[1];
            parameters[0] = new DbParametro("p_num_caja", numCaja);

            var linea = await db.GetDataClass<T>("SP_CEL_ALM_SLD_PRD_CONSULTA", parameters, "curSQL");

            var RespuestaCajitas = new ResponseService<IEnumerable<T>>
            {
                Objeto = (IEnumerable<T>)linea
            };

            return RespuestaCajitas;
            //return (IEnumerable<T>)linea;
        }

        private List<Caja> mapearCajas(object linea)
        {
            IEnumerable<dynamic> aux = (IEnumerable<dynamic>)linea;
            var AuxCajas = new List<Caja>();
            foreach (var asd in aux)
            {
                var caja = new Caja();
                caja.DEPOSITO_ENTRADA = asd.DEPOSITO_ENTRADA;
                caja.DESCRIPCION = asd.DESCRIPCION;
                caja.DESCRIPCION_DEPOSITO = asd.DESCRIPCION_DEPOSITO;
                caja.GRUPO = asd.GRUPO;
                caja.ITEM = asd.ITEM;
                caja.NIVEL = asd.NIVEL;
                caja.PEDIDO_VENDA = asd.PEDIDO_VENDA;
                caja.QTDE_PECAS_REAL = asd.PEDIDO_VENDA;
                caja.SUB = asd.SUB;
                AuxCajas.Add(caja);
            }
            return AuxCajas;
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
