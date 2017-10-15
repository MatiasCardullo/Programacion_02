using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_17
{
    class MiLista<T> : IEnumerable,IEnumerator
    {
        private T[] array;

        public MiLista()
        {
            array = new T[1];
        }

        public int Count 
        { 
            get
            {
               return this.array.Length; 
            }        
        }

        public void Add(T cosito){
            Array.Resize(ref this.array, this.Count + 1);
            this.array[this.Count - 1] = cosito;
        }

        public void Remove(T cosito)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (!object.ReferenceEquals(this.array[i],null) && this.array[i].Equals(cosito))
                {
                    for (int j = i; j < this.Count - 1; j++)
                    {
                        this.array[j] = this.array[j + 1];
                    }
                    Array.Resize(ref this.array, this.Count - 1);
                    break;
                }
            }        
        }
        
        public IEnumerator GetEnumerator()
        {
            //Regresamos la estructura que nos interesa que recorra el foreach, esta debe implementar IEnumerator
            return this.array.GetEnumerator();
        }

        int position = -1; //Inicializo la posición con -1, cuando haga el primer "MoveNext" va a pasar a ser 0, el primer indice.

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public T Current //Propiedad Current
        {
            get
            {
                try
                {
                    return this.array[position]; //Regresa el elemento en el cual está posicionado. 
                }
                catch (IndexOutOfRangeException) //si se va del rango del arreglo lanza una excepción
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        { //Moverse al siguiente elemento e indicar si existe el siguiente elemento. 
            position++;
            return (position < this.Count);
        }

        public void Reset()
        {//Vuelve al inicio de la estructura. Position a -1.
            position = -1;
        }
    }
}
