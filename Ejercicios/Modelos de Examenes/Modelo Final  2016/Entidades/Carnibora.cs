using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    // Generar las clases públicas Fruta, Verdura y Carnibora. Las 3 heredarán de ReinoVegetal.
    // Carnibora contendrá el atributo _tamanio:int y _tipo:Captura,
    // siendo las Capturas disponibles: Pinzas, Pelos, Caída, Mecánicas, Combinada

    // A las tres clases generarle un constructor que reciba 3 parámetros.
    // A Carnibora generarle otro constructor que reciba 4 parámetros.

    // Los atributos de Fruta, Verdura y Carnibora generados en el punto anterior
    // deberán tener propiedades publicas de sólo lectura que expongan sus datos.
    // Fruta, Verdura y Carnibora contendrá una conversión implicita a String.

    // Generar la interfaz pública IVegetales, con la firma del método MostrarDatos:string.
    // Implementar la interfaz en Fruta, Verdura y Carnibora. Siempre rehutilizar código.
    // Canasta sólo deberá aceptar tipos T que implementen la interfaz.
    // Sobrecargar ToString de canasta para mostrar todos los datos de los elementos de la lista.
    public class Carnibora : ReinoVegetal, IVegetales
    {
        public enum Captura { Pinzas, Pelos, Caída, Mecánicas, Combinada }
        private Captura _tipo;
        private int _tamanio;

        public Captura TipoCaptura
        {
            get
            {
                return this._tipo;
            }
        }

        public int Tamanio
        {
            get
            {
                return this._tamanio;
            }
        }

        public static implicit operator string(Carnibora carnibora)
        {
            return String.Format("FRUTA. Tipo Captura: {0}, Tamaño: {1}. {2}", carnibora._tipo, carnibora._tamanio, (string)((ReinoVegetal)carnibora));
        }

        public Carnibora(float valor, Gusto gusto, Captura captura)
            :base(valor, gusto)
        {
            this._tipo = captura;
        }

        public Carnibora(float valor, Gusto gusto, Captura captura, int tamanio)
            :this(valor,gusto,captura)
        {
            this._tamanio = tamanio;
        }

        public string MostrarDatos()
        {
            return this;
        }
    }
}
