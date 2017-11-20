using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmFinal
{
    public abstract class Medico : Persona
    {
        public delegate void FinAtencionPaciente(Paciente p, Medico m);
        public event FinAtencionPaciente AtencionFinalizada;

        private Paciente pacienteActual;
        protected static Random tiempoAleatorio;

        public Paciente AtenderA
        {
            set
            {
                this.pacienteActual = value;
            }
        }

        public virtual string EstaAtendiendoA
        {
            get
            {
                return this.pacienteActual.ToString();
            }
        }

        static Medico()
        {
            Medico.tiempoAleatorio = new Random();
        }

        public Medico(string nombre, string apellido)
            :base(nombre,apellido)
        {
        }

        protected abstract void Atender();

        protected void FinalizarAtencion()
        {
            AtencionFinalizada(this.pacienteActual, this);
            this.pacienteActual = null;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", base.nombre, base.apellido);
        }

    }
}
