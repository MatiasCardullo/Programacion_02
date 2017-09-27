using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Practico_01
{
    class Numero
    {
        #region Atributos
        private double numero;
        #endregion

        #region Constructores
        //Constructor por defecto. Inicializa el atributo numero en cero.
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor recibe un double y carga en el atributo numero.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        //Constructor recibe un string, valida y carga en el atributo numero.
        public Numero(string numero)
        {
            this.setNumero(numero);
        }
        #endregion

        #region Métodos
        //Método valida que se trate de un double válido, caso contrario retorna 0.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns></returns>
        private static double validarNumero(string numeroString)
        {
            double retorno = 0;
            double buffer;

            if (double.TryParse(numeroString, out buffer))
            {
                retorno = buffer;
            }

            return retorno;
        }

        //Setter del atributo numero cuando se le pasa un string.
        private void setNumero(string numero)
        {
            this.numero = validarNumero(numero);
        }

        //Getter del atributo numero.
        public double getNumero()
        {
            return this.numero;
        }
        #endregion
    }
}
