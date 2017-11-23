using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Path al archivo.
        /// </summary>
        string archivo;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="archivo">Path al archivo.</param>
        public Texto(string archivo)
        {
            this.archivo = archivo;
        }

        /// <summary>
        /// Guardar serializa un string pasado por parámetro en un archivo binario.
        /// </summary>
        /// <param name="datos">Datos a serializar.</param>
        /// <returns>Devuelve true si se guardó correctamente.</returns>
        public bool guardar(string datos)
        {
            StreamWriter sw = null;
            bool retorno = false;

            try
            {
                sw = new StreamWriter(this.archivo, true);
                sw.WriteLine(datos);
                retorno = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sw.Close();
            }

            return retorno;
        }

        /// <summary>
        /// Leer deserializa el archivo binario y lo carga en una lista de strings.
        /// </summary>
        /// <param name="datos">Parámetro a cargar con la lista de datos separados línea a línea</param>
        /// <returns>Devuelve true si se leyó correctamente.</returns>
        public bool leer(out List<string> datos)
        {
            StreamReader sr = null;
            bool retorno = false;
            datos = new List<string>();
            string datosAux = "";
            try
            {
                sr = new StreamReader(this.archivo);

                while ((datosAux = sr.ReadLine()) != null)
                {
                    datos.Add(datosAux);
                }

                retorno = true;
            }
            catch (FileNotFoundException)
            {
                retorno = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if(sr != null)
                    sr.Close();
            }

            return retorno;
        }
    }
}
