using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Perro:Animal
    {
        public enum Razas {Galgo, OvejeroAleman}
        private static int _patas;
        private Razas _raza;

        static Perro()
        {
            Perro._patas = 4;
        }

        public Perro(int velocidadMaxima):base(Perro._patas,velocidadMaxima)
        { }

        public Perro(Razas raza, int velocidadMaxima):this(velocidadMaxima)
        {
            this._raza = raza;
        }

        public static bool operator ==(Perro p1, Perro p2)
        {
            bool retorno = false; 
            if (p1._raza == p2._raza && p1._velocidadMaxima == p2._velocidadMaxima)
                retorno = true;
            return retorno;
        }

        public static bool operator !=(Perro p1, Perro p2)
        {
            return !(p1 == p2);
        }

        public string MostrarPerro() 
        {
            string datos = String.Format("Raza: {0}", this._raza);
            return datos;
        }

    }
}
