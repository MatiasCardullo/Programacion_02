using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Extensores
    {
        public static string MostrarElemento(this Fruta fruta)
        {
            return fruta.MostrarDatos();
        }
    }
}
