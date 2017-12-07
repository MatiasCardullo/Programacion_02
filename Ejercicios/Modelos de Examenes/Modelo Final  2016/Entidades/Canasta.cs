using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    // Generar la clase Canasta con los atributos _plantas:List del tipo genérico.
    // (este sólo se podrá inicializar en el constructor por defécto, que además será privado)
    // y _capacidad:int (generar un constructor que lo reciba como parámetros).

    // Al sumar una canasta con un elemento del ReinoVegetal se deberá a gregar a la lista de _plantas
    // SÓLO si el tipo genérico de la Canasta es igual al elemento del ReinoVegetal (Fruta, Verdura, Carnibora)
    // y aun hay lugar en la canasta.
    // Si no son del mismo tipo, el mensaje deberá ser "El elemento es del tipo {0}. Se esperaba {1}.".
    // ¡Se deberá utilizar Format de String!
    // Si la capacidad está al límite, el mensaje será "Capacidad completa.".
    // Utilizar T aux = (T)Convert.ChangeType(reinoVegetal, typeof(T)); para convertir un ReinoVegetal en T (tipo genérico).

    // Generar la interfaz pública IVegetales, con la firma del método MostrarDatos:string.
    // Implementar la interfaz en Fruta, Verdura y Carnibora. Siempre rehutilizar código.
    // Canasta sólo deberá aceptar tipos T que implementen la interfaz.
    // Sobrecargar ToString de canasta para mostrar todos los datos de los elementos de la lista.
    public class Canasta <T>
        where T: IVegetales
    {
        private List<T> _plantas;
        private int _capacidad;

        private Canasta()
        {
            this._plantas = new List<T>();
        }

        public Canasta(int capacidad)
            :this()
        {
            this._capacidad = capacidad;
        }

        public static Canasta<T> operator +(Canasta<T> canasta, ReinoVegetal vegetal)
        {            
            if (vegetal is T && canasta._plantas.Count < canasta._capacidad)
            {
                T aux = (T)Convert.ChangeType(vegetal, typeof(T));
                canasta._plantas.Add(aux);
            }
            else if(!(vegetal is T))
            {
                throw new NoAgregaException(String.Format("El elemento es del tipo {0}. Se esperaba {1}.", vegetal.GetType(), typeof(T)));
            }
            else if(canasta._plantas.Count >= canasta._capacidad)
            {
                throw new NoAgregaException("Capacidad Completa.");
            }

            return canasta;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(T planta in this._plantas)
            {
                sb.AppendLine(planta.MostrarDatos());
            }
            return sb.ToString();
        }

    }
}
