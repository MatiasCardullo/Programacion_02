using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_Lab_II
{
    public abstract class Mascota
    {
        private string nombre;
        private string raza;

        #region Propiedades
        /// <summary>
        /// Propiedad de sólo lectura. Devuelve el nombre de la mascota. 
        /// </summary>
        public string Nombre { get { return this.nombre; } } 

        /// <summary>
        /// Propiedad de sólo lectura. Devuelve la raza de la mascota.
        /// </summary>
        public string Raza { get { return this.raza; } }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor público.
        /// </summary>
        /// <param name="nombre">Nombre de la mascota.</param>
        /// <param name="raza">Raza de la mascota</param>
        public Mascota(string nombre, string raza)
        {
            this.nombre = nombre;
            this.raza = raza;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método virtual. Devuelve los datos de la mascota.
        /// </summary>
        /// <returns>Retorna el nombre y la raza con el formato "Nombre Raza".</returns>
        protected virtual string DatosCompletos() {
            return String.Format("{0} {1}", this.Nombre, this.Raza);
        }

        /// <summary>
        /// Método abstracto. 
        /// </summary>
        /// <returns></returns>
        protected abstract string Ficha();
        #endregion
        

    }
}
