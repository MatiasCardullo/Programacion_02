using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_Lab_II
{
    public class Gato:Mascota
    {
        #region Constructores
        /// <summary>
        /// Constructor público. 
        /// </summary>
        /// <param name="nombre">Nombre de la mascota.</param>
        /// <param name="raza">Raza de la masota.</param>
        public Gato(string nombre, string raza):base(nombre,raza)
        {  }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Dos Gatos serán iguales si comparten el mismo nombre y raza. 
        /// </summary>
        /// <param name="p1">Gato 1 a comparar.</param>
        /// <param name="p2">Gato 2 a comparar.</param>
        /// <returns>Verdadero si son iguales, Falso si son diferentes.</returns>
        public static bool operator ==(Gato p1, Gato p2)
        {
            bool retorno = false;
            if (p1.Nombre == p2.Nombre && p1.Raza == p2.Raza)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Dos Gatos serán diferentes si NO comparten el mismo nombre y raza. 
        /// </summary>
        /// <param name="p1">Gato 1 a comparar.</param>
        /// <param name="p2">Gato 2 a comparar.</param>
        /// <returns>Verdadero si son diferentes, Falso si son iguales.</returns>
        public static bool operator !=(Gato p1, Gato p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Retornará toda la información del gato en formato string.
        /// </summary>
        /// <returns>Información del gato en formato string.</returns>
        protected override string Ficha()
        {
            string datos = string.Format("{0} {1}", this.Nombre, this.Raza);
            return datos;
        }

        /// <summary>
        /// Compara si dos gatos son iguales. 
        /// </summary>
        /// <param name="obj">objeto a comparar</param>
        /// <returns>Devuelve true si son iguales, false si son diferentes o no son 2 gatos.</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Gato)
            {
                retorno = (this == (Gato)obj);
            }

            return retorno;
        }

        /// <summary>
        /// Publica la información del gato. 
        /// </summary>
        /// <returns>Información del gato en formato string.</returns>
        public override string ToString()
        {
            return this.Ficha();
        }
        #endregion

    }
}
