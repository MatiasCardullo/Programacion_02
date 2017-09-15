using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Sumador objeto = new Sumador();
            Sumador otroObjeto = new Sumador();

            otroObjeto.Sumar(4, 3);
            
            Console.Write("{0}\n",objeto.Sumar(2, 3));
            Console.Write("{0}", objeto.Sumar("Hola ", "Mundo"));

            Console.Write("\n{0} {1}", objeto + otroObjeto, objeto | otroObjeto);
            Console.ReadKey();
        }
    }
}
