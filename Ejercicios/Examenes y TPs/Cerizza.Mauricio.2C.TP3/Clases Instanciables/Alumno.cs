using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta { Becado, Deudor, AlDia}

        #region Atributos
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene/Establece la clase que toma el alumno.
        /// </summary>
        public Universidad.EClases ClaseQueToma {
            get
            {
                return this._claseQueToma;
            }
            set
            {
                this._claseQueToma = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor público de instancia. 
        /// </summary>
        /// <param name="id">Legajo del alumno.</param>
        /// <param name="nombre">Nombre del alumno.</param>
        /// <param name="apellido">Apellido del alumno.</param>
        /// <param name="dni">DNI del alumno.</param>
        /// <param name="nacionalidad">Nacionalidad del alumno, Argentino o Extranjero.</param>
        /// <param name="claseQueToma">La clase que toma el alumno: Laboratorio, Programacion, Legislacion o SPD.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.ClaseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor público de instancia.
        /// </summary>
        /// <param name="id">Legajo del alumno.</param>
        /// <param name="nombre">Nombre del alumno.</param>
        /// <param name="apellido">Apellido del alumno.</param>
        /// <param name="dni">DNI del alumno.</param>
        /// <param name="nacionalidad">Nacionalidad del alumno, Argentino o Extranjero.</param>
        /// <param name="claseQueToma">La clase que toma el alumno: Laboratorio, Programacion, Legislacion o SPD.</param>
        /// <param name="estadoCuenta">El estado de cuenta del alumno: Becado, Deudor o AlDia.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta)
            :this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a">Alumno a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>Devuelve true si el alumno toma la clase y su estado de cuenta es distinto de Deudor, sino false.</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase
        /// </summary>
        /// <param name="a">Alumno a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>Devuelve true si el alumno no toma la clase, sino false.</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a._claseQueToma != clase);
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Muestra todos los datos del alumno. 
        /// </summary>
        /// <returns>Devuelve una cadena con todos los datos del alumno.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine(base.MostrarDatos());
            if(this._estadoCuenta == EEstadoCuenta.AlDia)
            {
                datos.AppendLine("ESTADO DE CUENTA: Cuota al día");
            }
            else
            {
                datos.AppendFormat("ESTADO DE CUENTA: {0}\n", this._estadoCuenta);
            }
            datos.AppendLine(this.ParticiparEnClase());

            return datos.ToString();
        }

        /// <summary>
        /// Muestra la clase que toma el alumno.
        /// </summary>
        /// <returns>Devuelve una cadena "TOMA CLASE DE" junto al nombre de la clase que toma el alumno.</returns>
        protected override string ParticiparEnClase()
        {
            return String.Format("TOMA CLASES DE {0}", this._claseQueToma);
        }

        /// <summary>
        /// Hace públicos los datos del alumno.
        /// </summary>
        /// <returns>Devuelve una cadena con todos los datos del alumno.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
