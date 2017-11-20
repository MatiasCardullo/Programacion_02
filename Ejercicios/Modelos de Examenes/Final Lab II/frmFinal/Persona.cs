using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmFinal
{
    public abstract class Persona
    {
        protected string apellido;
        protected string nombre;

        public Persona(string nombre,string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }
    }
}
