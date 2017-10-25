using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public NacionalidadInvalidaException():this("Nacionalidad inválida.")
        {
                
        }

        /// <summary>
        /// Constructor permite setear un mensaje.
        /// </summary>
        /// <param name="message">Mensaje de la excepción</param>
        public NacionalidadInvalidaException(string message):base(message)
        {

        }
    }
}
