﻿using CK.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Services
{
    public interface IPrendasService
    {
        Task<object> ConsultarPrenda(string codPrenda);
    }
}
