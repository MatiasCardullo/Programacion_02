using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    // TODAS las clases deberán ir en una Biblioteca de Clases llamada Entidades
    // Realizar una clase llamada ReinoVegetal. Debe ser abstracta
    // y poseer los atributos protegidos _valor:float y _gusto:Gusto.
    // Enumerado Gusto contendrá Dulce, Salado y Toxica
    // Generar un constructor que reciba ambos parámetros.
    // Agregar un atributo estático calcularValor:Random. Este atributo sólo se podrá inicializar en un constructor estático.
    // Generar otro constructor que sólo reciba Gusto y asigne en _valor un número aleatorio entre 1 y 100.

    // ReinoVegetal contendrá una conversión explicita a String.
    public abstract class ReinoVegetal
    {
        public enum Gusto { Dulce, Salado, Toxica}
        protected float _valor;
        protected Gusto _gusto;
        private static Random calcularValor;

        static ReinoVegetal()
        {
            calcularValor = new Random();
        }

        public ReinoVegetal(float valor, Gusto gusto)
        {
            this._valor = valor;
            this._gusto = gusto;
        }

        public ReinoVegetal(Gusto gusto)
            :this(calcularValor.Next(1,100),gusto)
        {
        }

        public static explicit operator string(ReinoVegetal vegetal)
        {
            return String.Format("Gusto: {0}, Valor: {1}", vegetal._gusto, vegetal._valor);
        }

        // Dos elementos del tipo ReinoVegetal serán iguales si son del mismo Tipo (dos frutas, dos verduras o dos carniboras)
        // y tienen el mismo Gusto
        public static bool operator ==(ReinoVegetal a, ReinoVegetal b)
        {
            bool retorno = false;
            if(a.GetType() == b.GetType() && a._gusto == b._gusto)
            {
                retorno = true;   
            }
            return retorno;
        }

        public static bool operator !=(ReinoVegetal a, ReinoVegetal b)
        {
            return !(a == b);
        }
    }
}
