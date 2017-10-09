using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_Lab_II
{
    public class Perro:Mascota
    {
        private int edad;
        private bool esAlfa;

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura-escritura para el atributo edad.
        /// </summary>
        public int Edad { get { return this.edad; } set { this.edad = value; } }

        /// <summary>
        /// Propiedad de lectura-escritura para el atributo esAlfa.
        /// </summary>
        public bool EsAlfa { get { return this.esAlfa; } set { this.esAlfa = value; } }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor público. 
        /// </summary>
        /// <param name="nombre">Nombre de la mascota.</param>
        /// <param name="raza">Raza de la masota.</param>
        public Perro(string nombre, string raza):base(nombre,raza)
        {
            this.Edad = 0;
            this.EsAlfa = false;
        }

        /// <summary>
        /// Constructor público.
        /// </summary>
        /// <param name="nombre">Nombre de la mascota.</param>
        /// <param name="raza">Raza de la mascota.</param>
        /// <param name="edad">Edad de la mascota.</param>
        /// <param name="esAlfa">¿Es alfa?</param>
        public Perro(string nombre, string raza, int edad, bool esAlfa) : this(nombre, raza)
        {
            this.Edad = edad;
            this.EsAlfa = esAlfa;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Dos Perros serán iguales si comparten el mismo nombre, raza y edad. 
        /// </summary>
        /// <param name="p1">Perro 1 a comparar.</param>
        /// <param name="p2">Perro 2 a comparar.</param>
        /// <returns>Verdadero si son iguales, Falso si son diferentes.</returns>
        public static bool operator ==(Perro p1, Perro p2)
        {
            bool retorno = false;
            if (p1.Nombre == p2.Nombre && p1.Edad == p2.Edad && p1.Raza == p2.Raza)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Dos Perros serán diferentes si NO comparten el mismo nombre, raza y edad. 
        /// </summary>
        /// <param name="p1">Perro 1 a comparar.</param>
        /// <param name="p2">Perro 2 a comparar.</param>
        /// <returns>Verdadero si son diferentes, Falso si son iguales.</returns>
        public static bool operator !=(Perro p1, Perro p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Conversión explítita de Perro a entero. Retornará la edad del perro.
        /// </summary>
        /// <param name="perro"></param>
        public static explicit operator int(Perro perro)
        {
            return perro.Edad;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Retornará toda la información del perro en formato string.
        /// </summary>
        /// <returns>Información del perro en formato string.</returns>
        protected override string Ficha()
        {
            string datos;
            if (this.EsAlfa)
            {
                datos = string.Format("{0} {1}, alfa de la manada, edad {2}", this.Nombre, this.Raza, this.Edad);
            }
            else
            {
                datos = string.Format("{0} {1}, edad {2}", this.Nombre, this.Raza, this.Edad);
            }
            return datos;
        }

        /// <summary>
        /// Compara si dos perros son iguales. 
        /// </summary>
        /// <param name="obj">objeto a comparar</param>
        /// <returns>Devuelve true si son dos perros iguales, false si son diferentes o no son 2 perros.</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Perro)
            {
                retorno = (this == (Perro)obj);
            }

            return retorno;
        }

        /// <summary>
        /// Publica la información del perro. 
        /// </summary>
        /// <returns>Información del perro en formato string.</returns>
        public override string ToString()
        {
            return this.Ficha();
        }
        #endregion
    }
}
