using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ProfesorRepetidoException : Exception
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public ProfesorRepetidoException() :base("Profesor repetido.")
        {

        }
    }
}
