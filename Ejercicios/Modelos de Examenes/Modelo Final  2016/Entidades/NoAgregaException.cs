using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    // Generar la Excepción propia NoAgregaException con un único constructor que reciba el mensaje a mostrar.
    public class NoAgregaException : Exception
    {
        public NoAgregaException(string message) 
            :base(message)
        {

        }
    }
}
