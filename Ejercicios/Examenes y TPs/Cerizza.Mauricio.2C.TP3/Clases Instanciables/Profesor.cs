using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using System.Xml.Serialization;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private List<Universidad.EClases> _clasesDelDia; //No se puede serializar una cola(No tiene constructor por defecto), así que usé una lista. 
        private static Random _random;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene una lista con las clases que da el profesor.
        /// </summary>
        public List<Universidad.EClases> ClasesDelDía
        {
            get
            {
                return this._clasesDelDia;
            }
            set
            {
                this._clasesDelDia = value;               
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de clase, inicializa el atributo Random.
        /// </summary>
        static Profesor()
        {
            _random = new Random();
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Profesor()
        {

        }

        /// <summary>
        /// Constructor público de instancia. Inicializa la cola de clases del día del profesor.
        /// También asigna dos clases al azar a dicha cola. 
        /// </summary>
        /// <param name="id">Legajo del profesor.</param>
        /// <param name="nombre">Nombre del profesor.</param>
        /// <param name="apellido">Apellido del profesor.</param>
        /// <param name="dni">DNI del profesor.</param>
        /// <param name="nacionalidad">Nacionalidad del profesor.</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new List<Universidad.EClases>();
            this._randomClases(); //Asigna dos clases al azar a la lista de clases del profesor. 
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Será igual si el profesor da la clase.
        /// </summary>
        /// <param name="i">Profesor a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>Devuelve true si el profesor da la clase, sino false.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach(Universidad.EClases c in i._clasesDelDia)
            {
                if(clase == c)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Será distinto si el profesor no da la clase.
        /// </summary>
        /// <param name="i">Profesor a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>Devuelve true si el profesor NO da la clase, sino false.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Asigna dos clases al azar a la cola de clases del día del profesor. 
        /// </summary>
        private void _randomClases()
        {
            this._clasesDelDia.Add((Universidad.EClases)Profesor._random.Next(0, 4));
            this._clasesDelDia.Add((Universidad.EClases)Profesor._random.Next(0, 4));
        }

        /// <summary>
        /// Muestra las clases que da el profesor.
        /// </summary>
        /// <returns>Devuelve una cadena "TOMA CLASE DE" junto al nombre de las clases que da el profesor.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder clases = new StringBuilder();
            clases.AppendLine("CLASES DEL DÍA:");
            foreach (Universidad.EClases c in this._clasesDelDia)
            {
                clases.AppendFormat("{0}\n", c);
            }
            return clases.ToString();
        }

        /// <summary>
        /// Muestra todos los datos del profesor. 
        /// </summary>
        /// <returns>Devuelve una cadena con todos los datos del profesor.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine(base.MostrarDatos());
            datos.AppendLine(this.ParticiparEnClase());
            return datos.ToString();
        }

        /// <summary>
        /// Hace públicos los datos del profesor.
        /// </summary>
        /// <returns>Devuelve una cadena con todos los datos del profesor.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
