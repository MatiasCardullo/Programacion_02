using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    // Generar las clases públicas Fruta, Verdura y Carnibora. Las 3 heredarán de ReinoVegetal.
    // Fruta contendrá el atributo _color:ConsoleColor

    // A las tres clases generarle un constructor que reciba 3 parámetros.

    // Los atributos de Fruta, Verdura y Carnibora generados en el punto anterior
    // deberán tener propiedades publicas de sólo lectura que expongan sus datos.

    // Fruta, Verdura y Carnibora contendrá una conversión implicita a String.

    // Generar la interfaz pública IVegetales, con la firma del método MostrarDatos:string.
    // Implementar la interfaz en Fruta, Verdura y Carnibora. Siempre rehutilizar código.
    // Canasta sólo deberá aceptar tipos T que implementen la interfaz.
    // Sobrecargar ToString de canasta para mostrar todos los datos de los elementos de la lista.
    public class Fruta : ReinoVegetal, IVegetales
    {
        private ConsoleColor _color;

        public ConsoleColor Color
        {
            get
            {
                return this._color;
            }
        }

        public static implicit operator string(Fruta fruta)
        {
            return String.Format("FRUTA. Color: {0}. {1}", fruta._color, (string)((ReinoVegetal)fruta));
        }

        public Fruta(float valor, Gusto gusto, ConsoleColor color)
            :base(valor,gusto)
        {
            this._color = color;
        }

        public string MostrarDatos()
        {
            return this;
        }
    }
}
