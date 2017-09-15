using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso
{
    class Producto
    {
        private string _marca;
        private float _precio;
        private string _codigoDeBarra;

        public Producto(string marca, string codigo, float precio) 
        {
            this._marca = marca;
            this._precio = precio;
            this._codigoDeBarra = codigo;
        }

        public string GetMarca() 
        {
            return this._marca;
        }

        public float GetPrecio()
        {
            return this._precio;
        }

        public string MostrarProducto()
        {
            string retorno = "\n\nMarca: " + this._marca + "\nPrecio: " + this._precio + "\nCodigoDeBarra: " + this._codigoDeBarra;
            return retorno;
        }

        public static explicit operator string(Producto producto) 
        {
            return producto._codigoDeBarra;
        }

        public static bool operator ==(Producto a, Producto b)
        {
            bool retorno = false;
            if(a._marca == b._marca && a._codigoDeBarra == b._codigoDeBarra)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Producto a, Producto b)
        {
            bool retorno = true;
            if (a._marca == b._marca && a._codigoDeBarra == b._codigoDeBarra)
            {
                retorno = false;
            }

            return retorno;
        }

        public static bool operator ==(Producto a, string b)
        {
            bool retorno = false;
            if (a._marca == b)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Producto a, string b)
        {
            bool retorno = true;
            if (a._marca == b)
            {
                retorno = false;
            }

            return retorno;
        }



    }
}
