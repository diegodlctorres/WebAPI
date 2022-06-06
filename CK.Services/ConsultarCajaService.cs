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

        public async Task<object> ConsultaCaja(int numCaja)
        {
            try
            {
                CottonData db = new CottonData();
                DbParametro[] parameters = new DbParametro[1];
                parameters[0] = new DbParametro("p_num_caja", numCaja);

                var linea = await db.GetData("SP_CEL_ALM_SLD_PRD_CONSULTA", parameters, "curSQL");

                var RespuestaCaja = new ResponseService<List<Caja>>();


                List<Caja> cajas = mapearCajas(linea);

                RespuestaCaja.Objeto = cajas;

                return RespuestaCaja.Objeto;
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

        public async Task<object> MoverCajas(int p_num_caja, string p_cb_prenda, int p_tipo)
        {
            try
            {
                CottonData db = new CottonData();
                DbParametro[] parameters = new DbParametro[3];
                parameters[0] = new DbParametro("p_num_caja", p_num_caja);
                parameters[1] = new DbParametro("p_cb_prenda", p_cb_prenda);
                parameters[2] = new DbParametro("p_tipo", p_tipo);

                var linea = await db.GetData02("SP_CEL_ALM_SLD_PRD_MNTCAJAS", parameters);
                return null;
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

        public async Task<object> MoverCajas02(MoverCaja mover)
        {
            try
            {
                CottonData db = new CottonData();
                DbParametro[] parameters = new DbParametro[3];
                parameters[0] = new DbParametro("p_num_caja", mover.p_num_caja);
                parameters[1] = new DbParametro("p_cb_prenda", mover.p_cb_prenda);
                parameters[2] = new DbParametro("p_tipo", mover.p_tipo);

                var linea = await db.GetData02("SP_CEL_ALM_SLD_PRD_MNTCAJAS", parameters);
                return null;
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
        public async Task<object> MoverCajas03(MoverCaja mover)
        {
            try
            {
                var cajita = 0;
                ParameterDirection Direccion=new ParameterDirection();
                CottonData db = new CottonData();
                DbParametro[] parameters = new DbParametro[5];
                parameters[0] = new DbParametro("p_num_caja", mover.p_num_caja);
                parameters[1] = new DbParametro("p_cb_prenda", mover.p_cb_prenda);
                parameters[2] = new DbParametro("p_tipo", mover.p_tipo);
                parameters[3] = new DbParametro("p_deposito", mover.p_deposito);
                parameters[4] = new DbParametro("p_new_caja", cajita, ParameterDirection.Output);

                var linea = await db.GetData03("SP_CEL_ALM_SLD_PRD_MNTCAJAS", parameters);
                
                if(string.IsNullOrEmpty(cajita.ToString()))
                {
                    return cajita;
                }
                else
                {
                    return null;
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
                caja.QTDE_PECAS_REAL = asd.QTDE_PECAS_REAL;
                caja.SUB = asd.SUB;
                caja.COLOR = asd.COLOR;
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
