using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso
{
    class Estante
    {
        private int _capacidadMaxima;
        private int _ubicacion;
        private Producto[] _productos;

        private Estante(int cantidad) 
        {
            this._productos = new Producto [cantidad];
        }

        public Estante(int capacidad, int ubicacion) :this(capacidad)
        {
            this._capacidadMaxima = capacidad;
            this._ubicacion = ubicacion;
        }

        public Producto[] GetProductos()
        {
            return this._productos;
        }

        public string MostrarEstante()
        {
            string retorno = "Capacidad Maxima: " + this._capacidadMaxima + "\nUbicacion: " + this._ubicacion + "\nProductos:";
            
            for (int i = 0; i < this._productos.Length; i++)
            {
                if(!(object.ReferenceEquals(this._productos[i], null)))
                    retorno = retorno + this._productos[i].MostrarProducto();
            }
            
            return retorno;
        }

        public static bool operator ==(Estante estante, Producto producto)
        {
            bool retorno = false;

            for (int i = 0; i < estante._productos.Length; i++)
            {
                if (!(object.ReferenceEquals(estante._productos[i], null)) && estante._productos[i] == producto) 
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        public static bool operator !=(Estante estante, Producto producto)
        {
            bool retorno = true;

            for (int i = 0; i < estante._productos.Length; i++)
            {
                if (!(object.ReferenceEquals(estante._productos[i], null)) && estante._productos[i] == producto)
                {
                    retorno = false;
                    break;
                }
            }

            return retorno;
        }
        
        public static bool operator +(Estante estante, Producto producto)
        {
            bool retorno = false;
            
            if(estante != producto)
            {
                for (int i = 0; i < estante._productos.Length; i++)
                {
                    if(object.ReferenceEquals(estante._productos[i], null))
                    {
                        estante._productos[i] = producto;
                        retorno = true;
                        break;
                    }
                }

                
            }

            return retorno;
        }

        public static Estante operator -(Estante estante, Producto producto)
        {          
            for (int i = 0; i < estante._productos.Length; i++)
            {
                if (estante._productos[i] == producto)
                {
                    estante._productos[i] = null;
                    break;
                }
            }            

            return estante;
        }

    }
}
