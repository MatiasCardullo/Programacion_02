using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Permite serializar datos en formato XML. 
        /// </summary>
        /// <param name="archivo">PATH donde se guardará el archivo.</param>
        /// <param name="datos">Datos a guardar.</param>
        /// <returns>Devuelve true si no se produjeron excepciones al guardar, false si
        /// se produjeron excepciones.</returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlTextWriter writer = null;
            bool retorno = true; //Devuelve true si no se produjeron excepciones.
            try
            {
                writer = new XmlTextWriter(archivo, null);
                ser.Serialize(writer, datos);                
            }
            catch (Exception)
            {
                retorno = false; //Devuelve false si se produjeron excepciones. 
            }
            finally
            {
                writer.Close();
            }
            return retorno;
        }

        /// <summary>
        /// Permite deserializar datos en formato XML.
        /// </summary>
        /// <param name="archivo">PATH del archivo a deserializar.</param>
        /// <param name="datos">Parámetro de salida donde se almacenarán los datos leídos.</param>
        /// <returns>Devuelve true si no se produjeron excepciones al leer, false si
        /// se produjeron excepciones.</returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlTextReader reader = null;
            bool retorno = true; //Devuelve true si no se produjeron excepciones.            

            try
            {
                reader = new XmlTextReader(archivo);
                datos = (T)ser.Deserialize(reader);
            }
            catch (Exception)
            {
                datos = default(T); //Como no se pudo leer, carga con el valor nulo por defecto para el tipo de dato.
                retorno = false; //Devuelve false si se produjeron excepciones. 
            }
            finally
            {
                reader.Close();
            }
            return retorno;
        }
    }
}
