using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace Clases_Abstractas
{
    abstract public class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero }

        #region Atributos
        private string _nombre;
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        #endregion

        #region Propiedades
        /// <summary>
        /// Establece/Obtiene el DNI de una Persona (Validado). 
        /// </summary>
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Establece/Obtiene el nombre de una Persona (Validado). 
        /// </summary>
        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Establece/Obtiene la nacionalidad de una Persona (Argentino o Extranjero). 
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        /// <summary>
        /// Establece/Obtiene el DNI de una Persona (Validado). 
        /// </summary>
        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = ValidarDNI(this.Nacionalidad, value);    
            }
        }

        /// <summary>
        /// Convierte un DNI pasado como string a int. Valida que esté correctamente escrito y lo setea. 
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this._dni = ValidarDNI(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Constructor de instancia público.
        /// </summary>
        /// <param name="nombre">Nombre/s de la persona. </param>
        /// <param name="apellido">Apellido/s de la persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona, Argentino o Extranjero.</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de instancia público.
        /// </summary>
        /// <param name="nombre">Nombre/s de la persona. </param>
        /// <param name="apellido">Apellido/s de la persona.</param>
        /// <param name="dni">DNI de la persona en formato INT.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona, Argentino o Extranjero.</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor de instancia público.
        /// </summary>
        /// <param name="nombre">Nombre/s de la persona. </param>
        /// <param name="apellido">Apellido/s de la persona.</param>
        /// <param name="dni">DNI de la persona en formato STRING.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona, Argentino o Extranjero.</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Métodos

        #region Sobrescritos
        /// <summary>
        /// Sobrescritura del método ToString(). Retorna los datos de la Persona en formato string. 
        /// </summary>
        /// <returns>Nombre completo y nacionalidad de la persona.</returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre);
            datos.AppendFormat("\nNACIONALIDAD: {0}", this.Nacionalidad);
            return datos.ToString();
        }
        #endregion

        #region Validaciones
        /// <summary>
        /// Valida que:
        /// Si es ARGENTINO: Esté entre 1 y 89999999 (Incluídos)
        /// Si es EXTRANJERO: Esté entre 89999999 (Sin incluir) y 99999999 (incluído)
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">DNI de la persona.</param>
        /// <returns>DNI valido ó lanza DniInvalidoException caso contrario.</returns>
        private static int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            if(dato < 1 || dato > 99999999) //Si está fuera de los rangos permitidos para cualquier nacionalidad.
            {
                throw new DniInvalidoException("DNI en rango inválido.");
            }
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato > 89999999) //Fuera del rango para Argentinos.
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI."); 
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato <= 89999999) //Fuera del rango para extranjeros.
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI.");
                    }
                    break;
            }
            return dato;
        }

        /// <summary>
        /// Convierte un DNI pasado como string a int. Valida que esté correctamente escrito.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">DNI de la persona.</param>
        /// <returns>DNI valido ó lanza DniInvalidoException caso contrario.</returns>
        private static int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            int dniInt;

            if (Regex.IsMatch(dato, @"^[0-9]+[0-9\.]*$")) //Contiene al menos 1 numero y luego, numeros o puntos. 
            {                
                dato = dato.Replace(".", ""); //Quito los puntos. 
                Int32.TryParse(dato, out dniInt); //Parseo a Int. 
            }
            else //Si el DNI ingresado no tiene un formato válido... DNIInvalidoException. 
            {
                throw new DniInvalidoException("DNI ingresado tiene un formato inválido.");
            }

            return ValidarDNI(nacionalidad,dniInt); //Lo envía al otro método para que valide el rango. 
        }

        /// <summary>
        /// Valida que el apellido/nombre sea sólo letras, con opción de poner un espacio seguido de un segundo apellido/nombre. 
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>Apellido/nombre validado o cadena vacía.</returns>
        private static string ValidarNombreApellido(string dato)
        {
            if (Regex.IsMatch(dato, @"^([a-zA-Záéíóú]+)(\s[a-zA-Záéíóú]+)*$"))
            {
                return dato;
            }
            return "";
        }        
        #endregion

        #endregion
    }
}
