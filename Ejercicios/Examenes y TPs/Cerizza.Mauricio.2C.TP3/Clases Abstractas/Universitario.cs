using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor público por defecto. 
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Constructor público de instancia. 
        /// </summary>
        /// <param name="legajo">Legajo del universitario.</param>
        /// <param name="nombre">Nombre/s del universitario.</param>
        /// <param name="apellido">Apellido/s del universitario.</param>
        /// <param name="dni">DNI del universitario.</param>
        /// <param name="nacionalidad">Nacionalidad del universitario. Argentino o Extranjero.</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Compara dos objetos tipo Universitario. 
        /// </summary>
        /// <param name="obj">Objeto tipo Universitario a comparar. </param>
        /// <returns>Si su DNI y Legajo son iguales devuelve true, sino false.</returns>
        public override bool Equals(object obj)
        {
            if(!ReferenceEquals(obj,null) && obj is Universitario)
            {
                Universitario objeto = (Universitario)obj;
                if(objeto.legajo == this.legajo && objeto.DNI == this.DNI)
                {
                    return true; 
                }                
            }
            return false;
        }

        /// <summary>
        /// Compara dos objetos tipo Universitario. 
        /// </summary>
        /// <param name="pg1">Objeto tipo Universitario a comparar.</param>
        /// <param name="pg2">Objeto tipo Universitario a comparar.</param>
        /// <returns>Si su DNI y Legajo son iguales devuelve true, sino false.</returns>
        public static bool operator ==(Universitario pg1,Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        /// <summary>
        /// Compara dos objetos tipo Universitario. 
        /// </summary>
        /// <param name="pg1">Objeto tipo Universitario a comparar.</param>
        /// <param name="pg2">Objeto tipo Universitario a comparar.</param>
        /// <returns>Si su DNI y Legajo son iguales devuelve false, sino true.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Retorna todos los datos del universitario.
        /// </summary>
        /// <returns>Legajo y datos del universitario en formato string.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine(base.ToString());
            datos.AppendFormat("\nLEGAJO NÚMERO: {0}", this.legajo);
            return datos.ToString();
        }

        /// <summary>
        /// Método abstracto. 
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion
    }
}
