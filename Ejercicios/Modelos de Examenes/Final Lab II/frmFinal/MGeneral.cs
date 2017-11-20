using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace frmFinal
{
    public class MGeneral : Medico,IMedico
    {
        public MGeneral(string nombre, string apellido)
            : base(nombre, apellido)
        {
        }

        public void IniciarAtencion(Paciente p)
        {
            Thread thread = new Thread(Atender);
            base.AtenderA = p;
            thread.Start();
        }

        protected override void Atender()
        {
            Thread.Sleep(Medico.tiempoAleatorio.Next(1500, 2200));
            base.FinalizarAtencion();
        }


    }
}
