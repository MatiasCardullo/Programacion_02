using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

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
            FileStream fs = null;
            bool retorno = false;
            string datosAux = "";
            try
            {
                fs = new FileStream(this.archivo, FileMode.OpenOrCreate);
                //Tuve que crear mi propio "Append" porque el de FileStream por alguna razón no funciona.
                BinaryFormatter bf = new BinaryFormatter();
                if(fs.Length != 0) //Si no es cero deserializo todo el contenido en datosAux.
                    datosAux = bf.Deserialize(fs).ToString();
                fs.Close(); //Cierro el stream.

                string texto = String.Format(datosAux + datos); //Sumo al historial (datosAux) una nueva pagina (datos) 
                fs = new FileStream(this.archivo, FileMode.Create); //Lo vuelvo a abrir para serializar los datos.
                bf.Serialize(fs, texto);
                retorno = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                fs.Close();
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
            FileStream fs = null;
            bool retorno = false;
            datos = new List<string>();
            string datosAux = "";

            try
            {
                fs = new FileStream(this.archivo, FileMode.OpenOrCreate);
                if (fs.Length != 0) //Si no está vacío.
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    datosAux = (string)bf.Deserialize(fs); //Deserializo todo el bloque de texto.
                    StringReader reader = new StringReader(datosAux);
                    string line;
                    while (true)
                    {
                        line = reader.ReadLine(); //Voy leyendo línea por línea.
                        if (line != null) //Si no es null...
                        {
                            datos.Add(reader.ReadLine()); //Agrego a la lista de datos.
                        }
                        else
                        {
                            break; //Si es null salgo del bucle while.
                        }
                    }
                }
                
                retorno = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                fs.Close();
            }

            return retorno;
        }
    }
}
