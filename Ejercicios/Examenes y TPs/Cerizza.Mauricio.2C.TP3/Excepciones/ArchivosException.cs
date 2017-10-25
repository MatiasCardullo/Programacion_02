using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public ArchivosException():this("Excepción de archivo.")
        {
                
        }

        /// <summary>
        /// Constructor permite setear un mensaje.
        /// </summary>
        /// <param name="message">Mensaje de la excepción</param>
        public ArchivosException(string message):base(message) 
        {
        }
    }
}
