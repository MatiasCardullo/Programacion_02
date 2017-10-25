using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Permite guardar lo datos en formato texto. 
        /// </summary>
        /// <param name="archivo">PATH donde se guardará el archivo.</param>
        /// <param name="datos">Datos a guardar.</param>
        /// <returns>Devuelve true si no se produjeron excepciones al guardar, false si
        /// se produjeron excepciones.</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter file = null;
            bool retorno = true; //Devuelve true si no se produjeron excepciones.
            try
            {
                file = new StreamWriter(archivo, false);
                file.Write(datos);
            }
            catch (Exception)
            {
                retorno = false; //Devuelve false si se produjeron excepciones. 
            }
            finally
            {
                file.Close();
            }
            return retorno;
        }

        /// <summary>
        /// Permite leer lo datos en formato texto. 
        /// </summary>
        /// <param name="archivo">PATH donde se guarda el archivo a leer.</param>
        /// <param name="datos">Parametro de salida donde se guardarán los datos leídos.</param>
        /// <returns>Devuelve true si no se produjeron excepciones al leer, false si
        /// se produjeron excepciones.</returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader file = null;
            bool retorno = true; //Devuelve true si no se produjeron excepciones.
            try
            {
                file = new StreamReader(archivo);
                datos = file.ReadToEnd();
            }
            catch (Exception)
            {
                datos = null;
                retorno = false; //Devuelve false si se produjeron excepciones. 
            }
            finally
            {
                file.Close();
            }
            return retorno;
        }
    }
}
