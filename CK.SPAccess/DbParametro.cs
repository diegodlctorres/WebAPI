using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CK.SPAccess
{
    [Serializable]
    public class DbParametro
    {
        private string nombre;
        private object valor;
        private ParameterDirection direccion;

        public DbParametro()
        {
            nombre = "";
            valor = null;
            direccion = ParameterDirection.Input;
        }

        public DbParametro(string Nombre, object Valor, ParameterDirection Direccion)
        {
            nombre = Nombre;
            valor = Valor;
            direccion = Direccion;
        }

        public DbParametro(string Nombre, object Valor)
        {
            nombre = Nombre;
            valor = Valor;
            direccion = ParameterDirection.Input;
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public object Valor
        {
            get
            {
                return valor;
            }
            set
            {
                valor = value;
            }
        }

        public ParameterDirection Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                direccion = value;
            }
        }
    }
}