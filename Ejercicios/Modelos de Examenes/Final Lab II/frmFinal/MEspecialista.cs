using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace frmFinal
{
    public class MEspecialista : Medico, IMedico
    {
        public enum Especialidad { Traumatologo, Odontologo}

        private Especialidad especialidad;

        public MEspecialista(string nombre, string apellido, Especialidad e)
            :base(nombre,apellido)
        {
            this.especialidad = e;
        }

        public void IniciarAtencion(Paciente p)
        {
            Thread thread = new Thread(Atender);
            base.AtenderA = p;
            thread.Start();            
        }

        protected override void Atender()
        {
            Thread.Sleep(Medico.tiempoAleatorio.Next(5000, 10000));
            base.FinalizarAtencion();
        }
    }
}
