using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Dapper;
using Dapper.Oracle;
//using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace CK.SPAccess
{
    public class CottonData : ICottonData
    {
        public async Task<object> GetData(string stored, DbParametro[] parametro, string pcursor = "PCURSOR")
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                for (int i = 0; i < parametro.Length; i++)
                {
                    dyParam.Add(parametro[i].Nombre, parametro[i].Valor);
                }

                dyParam.Add(pcursor, null, OracleMappingType.RefCursor, ParameterDirection.Output);
                var conn = this.GetConnection();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    var query = stored;
                    result = await SqlMapper.QueryAsync(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
            return result;
        }

        public async Task<bool> SetData(string stored, DbParametro[] parametro)
        {
            bool ber = false;
            try
            {
                var dyParam = new OracleDynamicParameters();

                for (int i = 0; i < parametro.Length; i++)
                {
                    dyParam.Add(parametro[i].Nombre, parametro[i].Valor);
                }
                var conn = this.GetConnection();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    var query = stored;
                    var result = await SqlMapper.ExecuteAsync(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    ber = result == -1 ? true : false;
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ber;
        }

        public async Task<IEnumerable<T>> GetDataClass<T>(string stored, DbParametro[] parametro, string Nombrecursor = "PCURSOR")
        {
            var conn = GetConnection();
            conn.Open();
            var p = new OracleDynamicParameters();
            for (int i = 0; i < parametro.Length; i++)
            {
                p.Add(parametro[i].Nombre, parametro[i].Valor);
            }
            p.Add(Nombrecursor, dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            dynamic obj = await SqlMapper.QueryAsync<T>(conn, stored, param: p, commandType: CommandType.StoredProcedure);
            conn.Close();
            return obj;
        }


        //public IConfigurationRoot appJson()
        //{
        //    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();
        //    return builder;
        //}
        public IDbConnection GetConnection()
        {
            string connectionString = "";//appJson().GetSection("ConnectionStrings").GetSection("BDConnection").Value.ToString();
            var conn = new OracleConnection(connectionString);
            return conn;
        }
    }
}

