using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Carrera
    {
        private List<Animal> _animales;
        private int _corredoresMax;

        private Carrera()
        {
            this._animales = new List<Animal>();
        }
        
        public Carrera(int corredoresMax):this()
        {
            this._corredoresMax = corredoresMax;        
        }

        public string mostrarCarrera()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine("------------------------CARRERA--------------------------------");
            datos.AppendFormat("Cant. Corredores Max: {0}", this._corredoresMax);
            datos.AppendLine("\nCOMPETIDORES:");
            for (int i = 0; i < this._animales.Count; i++)
            {
                datos.AppendLine("__________________________________________________");
                datos.AppendLine(this._animales[i].MostrarDatos());
                if (this._animales[i] is Perro)
                    datos.AppendLine(((Perro)this._animales[i]).MostrarPerro());
                else if (this._animales[i] is Caballo)
                    datos.AppendLine(((Caballo)this._animales[i]).MostrarCaballo());
                else if (this._animales[i] is Humano)
                    datos.AppendLine(((Humano)this._animales[i]).MostrarHumano());
                datos.AppendLine("__________________________________________________");
            }
            datos.AppendLine("----------------------------------------------------------------");

            return datos.ToString();
        }

        public static bool operator ==(Carrera c, Animal a)
        {
            bool retorno = false;
            foreach (Animal animal in c._animales)
            {
                if (animal.GetType() == a.GetType())
                {
                    if(a is Perro && ((Perro)a) == ((Perro)animal)){
                        retorno = true;
                        break;
                    }

                    if (a is Caballo && ((Caballo)a) == ((Caballo)animal))
                    {
                        retorno = true;
                        break;
                    }

                    if (a is Humano && ((Humano)a) == ((Humano)animal))
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }

        public static bool operator !=(Carrera c, Animal a)
        {
            return !(c == a);
        }

        public static Carrera operator +(Carrera c, Animal a)
        {
            if (c != a && c._animales.Count < c._corredoresMax)
            {
                c._animales.Add(a);
            }
            return c;
        }


    }
}
