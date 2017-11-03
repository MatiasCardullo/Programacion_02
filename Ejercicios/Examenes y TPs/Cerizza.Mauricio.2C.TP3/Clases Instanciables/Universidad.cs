using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases { Laboratorio, Programacion, Legislacion, SPD }

        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades
        /// <summary>
        /// Hace pública la lista de Alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Hace pública la lista de Jornadas.
        /// </summary>
        public List<Jornada> Jornadas {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }

        /// <summary>
        /// Hace pública la lista de Profesores.
        /// </summary>
        public List<Profesor> Profesores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Indexador para las jornadas.
        /// </summary>
        /// <param name="i">Índice de la jornada.</param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.Jornadas.Count)
                    return this.Jornadas[i];
                else
                    return null;
            }
            set
            {
                if (i >= 0 && i < this.Jornadas.Count)
                    this.Jornadas[i] = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto. Inicializa las listas de Alumnos, Profesores y Jornadas.
        /// </summary>
        public Universidad()
        {
            this.Jornadas = new List<Jornada>();
            this.Profesores = new List<Profesor>();
            this.Alumnos = new List<Alumno>();
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Una universidad es igual a un alumno si ese alumno está inscripto en la universidad. 
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns>Devuelve true si el alumno está inscripto en la universidad, sino false.</returns>
        public static bool operator == (Universidad g, Alumno a)
        {
            return g.Alumnos.Contains(a);
        }

        /// <summary>
        /// Una universidad es distinta a un alumno si ese alumno NO está inscripto en la universidad. 
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns>Devuelve true si el alumno NO está inscripto en la universidad, sino false.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Una universidad es igual a un profesor si ese profesor es parte de la universidad. 
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="a">Profesor a comparar.</param>
        /// <returns>Devuelve true si el profesor es parte de la universidad, sino false.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            return g.Profesores.Contains(i);
        }

        /// <summary>
        /// Una universidad es distinta a un profesor si ese profesor NO es parte de la universidad. 
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="a">Profesor a comparar.</param>
        /// <returns>Devuelve true si el profesor NO es parte de la universidad, sino false.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Devuelve el primer profesor de esa universidad que de esa clase.
        /// </summary>
        /// <param name="g">Universidad a evaluar.</param>
        /// <param name="clase">Clase que debe dar el profesor.</param>
        /// <returns>Devuelve el primer profesor que de esa clase. Si no hay ninguno lanza 
        /// SinProfesorException.</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach(Profesor p in g.Profesores)
            {
                if(p == clase) //Será igual si el profesor da la clase
                {
                    return p;
                }
            }
            // Si no encontró profesor que de la clase lanza SinProfesorException...
            throw new SinProfesorException();
        }

        /// Devuelve el primer profesor de esa universidad que NO de esa clase.
        /// </summary>
        /// <param name="g">Universidad a evaluar.</param>
        /// <param name="clase">Clase que NO debe dar el profesor.</param>
        /// <returns>Devuelve el primer profesor que NO de esa clase. Si no hay ninguno lanza 
        /// SinProfesorException.</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor p in g.Profesores)
            {
                if (p != clase) //Será distinto si el profesor no da la clase.
                {
                    return p;
                }
            }
            // Si no encontró profesor que NO de la clase lanza SinProfesorException...
            throw new SinProfesorException();
        }

        /// <summary>
        /// Inscribe a un alumno a la universidad (Siempre que no esté ya inscripto).
        /// </summary>
        /// <param name="g">Universidad en cuestión.</param>
        /// <param name="a">Alumno a inscribir.</param>
        /// <returns>Devuelve la universidad con el nuevo alumno cargado. 
        /// En el caso que el alumno ya estuviera inscripto, devuelve AlumnoRepetidoException</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if(g != a) //Si el alumno no está inscripto en la universidad...
            {
                g.Alumnos.Add(a);
                return g;
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
        }

        /// <summary>
        /// Agrega a un profesor a la universidad (Siempre que éste no sea ya parte de la misma).
        /// </summary>
        /// <param name="g">Universidad en cuestión.</param>
        /// <param name="a">Profesor a agregar.</param>
        /// <returns>Devuelve la universidad con el nuevo profesor cargado. 
        /// En el caso que el profesor ya fuera parte, devuelve ProfesorRepetidoException</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i) //Si el profesor no es parte de la universidad...
            {
                g.Profesores.Add(i);
                return g;
            }
            else
            {
                throw new ProfesorRepetidoException();
            }
        }

        /// <summary>
        /// Agrega una nueva jornada de clase. Asigna un profesor a la misma 
        /// y a los alumnos que tomen esa clase.
        /// </summary>
        /// <param name="g">Universidad en cuestión.</param>
        /// <param name="clase">Clase a agregar.</param>
        /// <returns>La universidad con la nueva jornada de clase cargada.</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            // "g == clase" devuelve un profesor que de la clase
            Jornada jornada = new Jornada(clase, g == clase);
            foreach(Alumno alumno in g.Alumnos) //Por cada alumno inscripto en la universidad...
            {
                if(alumno == clase) //Será igual si toma esa clase y no es deudor...
                {
                    jornada.Alumnos.Add(alumno); //Lo agrega a lista de alumnos de la clase...
                }                
            }
            g.Jornadas.Add(jornada);

            return g;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Serializa una universidad en formato XML.
        /// </summary>
        /// <param name="gim">Universidad a serializar.</param>
        public static void Guardar(Universidad gim)
        {
            Xml<Universidad> aux = new Xml<Universidad>();
            if (aux.Guardar("Universidad.xml", gim) == false)
            { //Si no se pudo guardar lanza la excepción.
                throw new ArchivosException("No se pudo guardar la universidad.");
            }
        }

        /// <summary>
        /// Deserializa una universidad guardada en formato XML.
        /// </summary>
        /// <returns>Objeto tipo Universidad con todos los datos guardados en el XML.</returns>
        public static Universidad Leer()
        {
            Universidad retorno;
            Xml<Universidad> aux = new Xml<Universidad>();
            if (aux.Leer("Universidad.xml", out retorno) == false)
            { //Si no se pudo guardar lanza la excepción.
                throw new ArchivosException("No se pudo leer la universidad.");
            }
            return retorno;
        }

        /// <summary>
        /// Genera una cadena con los datos de la universidad.
        /// </summary>
        /// <param name="gim">Universidad de la que se quiere mostrar los datos.</param>
        /// <returns>Cadena con los datos de la universidad.</returns>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder datos = new StringBuilder();

            foreach(Jornada jornada in gim.Jornadas)
            {
                datos.AppendLine("JORNADA:");
                datos.AppendLine(jornada.ToString());
                datos.AppendLine("< ------------------------------------------------------------------- >");
            }

            return datos.ToString();
        }

        /// <summary>
        /// Hace públicos los datos de la universidad.
        /// </summary>
        /// <returns>Cadena con los datos de la universidad.</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion
    }
}
