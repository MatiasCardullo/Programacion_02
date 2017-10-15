﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_30
{
    class Program
    {
        static void Main(string[] args)
        {
            Competencia<VehiculoDeCarrera> c1 = new Competencia<VehiculoDeCarrera>(15, 3, Competencia<VehiculoDeCarrera>.TipoCompetencia.MotoCross);
            AutoF1 a1 = new AutoF1(1, "Mercedes");
            AutoF1 a2 = new AutoF1(2, "Ferrari");
            AutoF1 a3 = new AutoF1(3, "RedBull");
            MotoCross m1 = new MotoCross(4, "escuderia",3);
            
            try
            {
                if (c1 + m1)
                {
                    Console.WriteLine(c1.mostrarDatos());
                }
            }
            catch (CompetenciaNoDisponibleException e)
            {
                Console.WriteLine(e.ToString());
            }
       
            try
            {
                if (c1 + a2)
                {
                    Console.WriteLine(c1.mostrarDatos());
                }
            }
            catch (CompetenciaNoDisponibleException e)
            {
                Console.WriteLine(e.ToString()); 
            }

            Console.ReadKey();

        }
    }
}
