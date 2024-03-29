﻿using CK.DataAccess.Models;
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

        public async Task<object> MoverCajas02(MoverCaja mover)
        {
            try
            {
                CottonData db = new CottonData();
                DbParametro[] parameters = new DbParametro[5];
                parameters[0] = new DbParametro("p_num_caja", mover.p_num_caja);
                parameters[1] = new DbParametro("p_cb_prenda", mover.p_cb_prenda);
                parameters[2] = new DbParametro("p_tipo", mover.p_tipo);
                parameters[3] = new DbParametro("p_deposito", 0);
                parameters[4] = new DbParametro("p_new_caja",null, ParameterDirection.Output);

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
                ParameterDirection Direccion=new ParameterDirection();
                CottonData db = new CottonData();
                DbParametro[] parameters = new DbParametro[5];
                parameters[0] = new DbParametro("p_num_caja", mover.p_num_caja);
                parameters[1] = new DbParametro("p_cb_prenda", mover.p_cb_prenda);
                parameters[2] = new DbParametro("p_tipo", mover.p_tipo);
                parameters[3] = new DbParametro("p_deposito", mover.p_deposito);
                parameters[4] = new DbParametro("p_new_caja", mover.p_new_caja, ParameterDirection.Output);

                var linea = await db.GetData03("SP_CEL_ALM_SLD_PRD_MNTCAJAS", parameters);
                
                if(linea != null)
                {
                    mover.p_new_caja = (int)linea;
                    return mover;
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
                decimal a1 = asd.DEPOSITO_ENTRADA;
                decimal a2 = asd.PEDIDO_VENDA;
                decimal a3 = asd.QTDE_PECAS_REAL;
                caja.DEPOSITO_ENTRADA = (int) a1;
                caja.DESCRIPCION = asd.DESCRIPCION;
                caja.DESCRIPCION_DEPOSITO = asd.DESCRIPCION_DEPOSITO;
                caja.GRUPO = asd.GRUPO;
                caja.ITEM = asd.ITEM;
                caja.NIVEL = asd.NIVEL;
                caja.PEDIDO_VENDA = (int)a2;
                caja.QTDE_PECAS_REAL = (int)a3;
                caja.SUB = asd.SUB;
                caja.COLOR = asd.COLOR;
                caja.CLIENTE = asd.CLIENTE;
                AuxCajas.Add(caja);
            }
            return AuxCajas;
        }
    }
}
