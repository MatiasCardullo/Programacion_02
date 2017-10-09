using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Animal
    {
        protected int _cantidadPatas;
        protected static Random _distanciaRecorrida;
        protected int _velocidadMaxima;

        public int CantidadPatas
        {
            get { return this._cantidadPatas; }
            set
            {
                if (value <= 4 && value > 0)
                {
                    this._cantidadPatas = value;
                }
                else
                {
                    this._cantidadPatas = 4;
                }
            }
        }

        public int VelocidadMaxima
        {
            get { return this._velocidadMaxima; }
            set
            {
                if (value <= 60 && value > 0)
                {
                    this._velocidadMaxima = value;
                }
                else
                {
                    this._velocidadMaxima = 60;
                }
            }
        }

        public int DistanciaRecorrida
        {
            get
            {
                return Animal._distanciaRecorrida.Next(10, this.VelocidadMaxima);
            }
        }

        static Animal()
        {
            Animal._distanciaRecorrida = new Random(DateTime.Now.Millisecond);
        }

        public Animal(int cantidadPatas, int velocidadMaxima)
        {
            this.CantidadPatas = cantidadPatas;
            this.VelocidadMaxima = velocidadMaxima;

        }

        public string MostrarDatos()
        {
            string datos = String.Format("Cantidad Patas: {0}, Distancia Recorrida: {1}, Velocidad Maxima: {2}", this.CantidadPatas, this.DistanciaRecorrida, this.VelocidadMaxima);
            return datos;
        }
    }    
}