using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_15
{
    class ErrorParserException : Exception
    {
        private string mensaje;
        
        public ErrorParserException(string mensaje) :this(mensaje,null) 
        {}

        public ErrorParserException(string mensaje, Exception innerException) :base(mensaje,innerException)
        {}



    }

}
