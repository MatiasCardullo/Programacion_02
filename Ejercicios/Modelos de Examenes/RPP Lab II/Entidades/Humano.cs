using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Humano:Animal
    {
        private string _apellido;
        private string _nombre;
        private static int _piernas;

        static Humano()
        {
            Humano._piernas = 2;
        }

        public Humano(int velocidadMaxima):base(Humano._piernas,velocidadMaxima)
        { }

        public Humano(string nombre, string apellido, int velocidadMaxima):this(velocidadMaxima)
        {
            this._nombre = nombre;
            this._apellido = apellido;
        }

        public static bool operator ==(Humano h1, Humano h2)
        {
            bool retorno = false; 
            if (h1._apellido == h2._apellido && h1._nombre == h2._nombre)
                retorno = true;
            return retorno;
        }

        public static bool operator !=(Humano h1, Humano h2)
        {
            return !(h1 == h2);
        }

        public string MostrarHumano() 
        {
            string datos = String.Format("Nombre: {0}, Apellido: {1}", this._nombre, this._apellido);
            return datos;
        }


    }
}
