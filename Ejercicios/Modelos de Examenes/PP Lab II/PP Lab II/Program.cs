using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_Lab_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Grupo m1 = new Grupo("Río", Grupo.TipoManada.unica);
            Mascota p1 = new Perro("Moro", "Pitbull");
            Perro p2 = new Perro("Julio", "Cruza", 13, false);
            Mascota p3 = new Perro("Ramón", "Salchicha", 2, true);
            Mascota p4 = new Perro("Ramón", "Salchicha", 2, true);
            Mascota g1 = new Gato("José", "Angora");
            Gato g2 = new Gato("Hernán", "Cruza");
            Gato g3 = new Gato("Fer", "Siames");
            Gato g4 = new Gato("Fer", "Siames");

            m1 += p1;
            m1 += p2;
            m1 += p3;
            m1 += p4; //No debería agregar otra vez a ramón.
            m1 += g1;
            m1 += g2;
            m1 += g3;
            m1 += g4; //No debería agregar otra vez a Fer Siames.
            Console.Write((string)m1);
            Console.ReadKey();

            m1 -= p1; //Lo saco, ya no debería estar en la lista Moro Pitbull.
            m1 -= g3; //Lo saco, ya no debería estar en la lista Fer Siames.
            Console.Write((string)m1);
            Console.ReadKey();



        }
    }
}
