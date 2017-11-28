using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EntidadesHechas
{
    public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            StreamWriter file = null;
            bool retorno = false;
            try
            {
                file = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) +"/"+ archivo, true);
                file.WriteLine(texto);
                retorno = true;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }

            return retorno;
        }
    }
}
