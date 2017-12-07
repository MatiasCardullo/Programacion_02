using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClasePrueba : ReinoVegetal
    {
        public ClasePrueba(ReinoVegetal.Gusto gusto)
            : base(gusto)
        {

        }

        public float Valor
        {
            get
            {
                return this._valor;
            }
        }
    }
}
