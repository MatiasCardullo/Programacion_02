using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_4
{
    class Sumador
    {
        private int cantidadSumas;

        public Sumador() {
            this.cantidadSumas = 0;            
        }

        public Sumador(int cantidadSumas){
            this.cantidadSumas = cantidadSumas;
        }

        public long Sumar(long a, long b)
        {
            long respuesta;

            this.cantidadSumas++;

            respuesta = a + b;

            return respuesta;       
        }

        public string Sumar(string a, string b)
        {
            string respuesta;

            this.cantidadSumas++;

            respuesta = a + b;

            return respuesta;
        }

        //public string sumar(string a, string b)
        //{
        //    string retorno = "error";
        //    long respuesta;
        //    long a_aux;
        //    long b_aux;

        //    if (long.tryparse(a, out a_aux) && long.tryparse(b, out b_aux))
        //    {
        //        respuesta = a_aux + b_aux;
        //        retorno = respuesta.tostring();
        //        this.cantidadsumas++;
        //    }

        //    return retorno;
        //}


        public static explicit operator int (Sumador obj){
            return obj.cantidadSumas;
        }

        public static long operator + (Sumador a, Sumador b){
            long retorno = a.cantidadSumas + b.cantidadSumas;
            return retorno;
        }

        public static bool operator | (Sumador a, Sumador b){
            return (a.cantidadSumas == b.cantidadSumas);
        }

       
    }
}
