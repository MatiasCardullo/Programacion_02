using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_15
{
    static class Parser
    {
        public static bool TryParse(string cadena, out int salida)
        {
            bool retorno = false;
            try
            {
                salida = Parse(cadena);
                retorno = true;
            }
            catch(Exception e)
            {
                throw new ErrorParserException("El string no podrá ser convertido. ", e);

            }

            return retorno;

        }

        public static int Parse(string cadena)
        {
            try
            {
                return Int32.Parse(cadena);
            }
            catch (FormatException e)
            {
                throw new ErrorParserException("... por error de formato. ", e);

            }
            catch (OverflowException e)
            {
                throw new ErrorParserException("... por tamaño del dato.", e);
            }
            catch (Exception e)
            {
                throw new ErrorParserException("El string no podrá ser convertido. ", e);
            }         

        }


    }
}
