using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Caballo:Animal
    {
        private static int _patas;
        private string _nombre;

        static Caballo()
        {
            Caballo._patas = 4;
        }

        public Caballo(string nombre, int velocidadMaxima):base(Caballo._patas,velocidadMaxima)
        {
            this._nombre = nombre;
        }

        public static bool operator ==(Caballo c1, Caballo c2)
        {
            bool retorno = false; 
            if (c1._nombre == c2._nombre)
                retorno = true;
            return retorno;
        }

        public static bool operator !=(Caballo c1, Caballo c2)
        {
            return !(c1 == c2);
        }

        public string MostrarCaballo() 
        {
            string datos = String.Format("Nombre: {0}", this._nombre);
            return datos;
        }
    }
}
