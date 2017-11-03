using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;
        #endregion

        #region Propiedades
        /// <summary>
        /// Hace pública la lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }
            set
            {
                this._alumnos = value;
            }
        }

        /// <summary>
        /// Hace público el atributo _clase. 
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this._clase;
            }
            set
            {
                this._clase = value;
            }
        }

        /// <summary>
        /// Hace público el atributo _instructor.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this._instructor;
            }
            set
            {
                this._instructor = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto. Inicializa la lista de alumnos que participan de la clase.
        /// </summary>
        public Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor. Inicializa clase e instructor.
        /// </summary>
        /// <param name="clase">Clase en la que consistirá la jornada.</param>
        /// <param name="instructor">Profesor que dará la clase</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) :this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Una jornada será igual a un alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j">Jornada a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns>Devuelve true si el alumno participa de la jornada, sino false.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return j.Alumnos.Contains(a);
        }

        /// <summary>
        /// Una jornada será diferente a un alumno si el mismo NO participa de la clase.
        /// </summary>
        /// <param name="j">Jornada a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns>Devuelve true si el alumno NO participa de la jornada, sino false.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un nuevo alumno a la lista de alumnos. 
        /// </summary>
        /// <param name="j">Jornada en cuestión.</param>
        /// <param name="a">Nuevo alumno a agregar.</param>
        /// <returns>La jornada con el nuevo alumno incluído.</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            j.Alumnos.Add(a);
            return j;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Informa todos los datos de una jornada.
        /// </summary>
        /// <returns>Devuelve una cadena con los datos de la jornada.</returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendFormat("CLASE DE {0} POR {1}", this.Clase, this.Instructor.ToString());
            datos.AppendLine("ALUMNOS:");
            foreach(Alumno alumno in this.Alumnos)
            {
                datos.AppendLine(alumno.ToString());
            }

            return datos.ToString();
        }

        /// <summary>
        /// Guarda una jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada">Jornada a guardar.</param>
        public static void Guardar(Jornada jornada)
        {
            Texto aux = new Texto();
            if(aux.Guardar("Jornada.txt", jornada.ToString()) == false)
            { //Si no se pudo guardar, lanza una excepción. 
                throw new ArchivosException("No se pudo guardar la jornada.");
            }
        }

        /// <summary>
        /// Lee el archivo donde se almacenan las jornadas y retorna la información obtenida.
        /// </summary>
        /// <returns>Devuelve los datos leídos del archivo en formato string.</returns>
        public static string Leer()
        {
            Texto aux = new Texto();
            string datos;
            if (aux.Leer("Jornada.txt", out datos) == false)
            { //Si no se pudo leer, lanza una excepción. 
                throw new ArchivosException("No se pudo leer el archivo.");
            }

            return datos;
        }
        #endregion
    }
}
