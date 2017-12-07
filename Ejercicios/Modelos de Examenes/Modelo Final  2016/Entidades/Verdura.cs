using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    // Generar las clases públicas Fruta, Verdura y Carnibora. Las 3 heredarán de ReinoVegetal.
    // Verdura contendrá el atributo _tipo:TipoVerdura,
    // siendo los TipoVerdura disponibles: Semilla, Raíz, Tubérculo, Bulbo, Tallo, Hoja, Inflorescencia, Rizoma

    // A las tres clases generarle un constructor que reciba 3 parámetros.

    // Los atributos de Fruta, Verdura y Carnibora generados en el punto anterior
    // deberán tener propiedades publicas de sólo lectura que expongan sus datos.
    // Fruta, Verdura y Carnibora contendrá una conversión implicita a String.

    // Generar la interfaz pública IVegetales, con la firma del método MostrarDatos:string.
    // Implementar la interfaz en Fruta, Verdura y Carnibora. Siempre rehutilizar código.
    // Canasta sólo deberá aceptar tipos T que implementen la interfaz.
    // Sobrecargar ToString de canasta para mostrar todos los datos de los elementos de la lista.
    public class Verdura : ReinoVegetal, IVegetales
    {
        public enum TipoVerdura { Semilla, Raíz, Tubérculo, Bulbo, Tallo, Hoja, Inflorescencia, Rizoma}
        private TipoVerdura _tipo;

        public TipoVerdura Tipo
        {
            get
            {
                return this._tipo;
            }
        }

        public static implicit operator string(Verdura verdura)
        {
            return String.Format("VERDURA. Tipo: {0}. {1}", verdura._tipo, (string)((ReinoVegetal)verdura));
        }

        public Verdura(float valor, Gusto gusto, TipoVerdura tipo)
            :base(valor,gusto)
        {
            this._tipo = tipo;
        }

        public string MostrarDatos()
        {
            return this;
        }
    }
}
