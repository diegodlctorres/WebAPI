﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CK.SPAccess
{
    public interface ICottonData
    {
        //Task<object> GetData(string stored, DbParametro[] parametro,string pcursor);
        Task<bool> SetData(string stored, DbParametro[] parametro);

        Task<Object> GetDataClass<T>(string stored, DbParametro[] parametro, string Nombrecursor = "PCURSOR");

        Task<Object> GetDataClassSingle<T>(string stored, DbParametro[] parametro, string Nombrecursor = "PCURSOR");

        //Task<IEnumerable<dynamic>> getDynamic(string stored, DbParametro[] parametro, string pcursor);
    }
}
