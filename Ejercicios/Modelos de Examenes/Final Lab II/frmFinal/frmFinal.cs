using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace frmFinal
{
    public partial class frmFinal : Form
    {
        private MEspecialista medicoEspecialista;
        private MGeneral medicoGeneral;
        private Thread mocker;
        private Queue<Paciente> pacientesEnEspera;        

        public frmFinal()
        {
            InitializeComponent();
            this.pacientesEnEspera = new Queue<Paciente>();
            this.medicoGeneral = new MGeneral("Luis", "Salinas");
            this.medicoEspecialista = new MEspecialista("Jorge", "Iglesias", MEspecialista.Especialidad.Traumatologo);
            
        }

        private void frmFinal_Load(object sender, EventArgs e)
        {
            this.mocker = new Thread(MockPacientes);
            this.mocker.Start();
            this.medicoGeneral.AtencionFinalizada += this.FinAtencion;
            this.medicoEspecialista.AtencionFinalizada += this.FinAtencion;
        }

        private void frmFinal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.mocker.IsAlive == true)
            {
                this.mocker.Abort();
            }
        }

        private void MockPacientes()
        {
            while(true)
            {
                this.pacientesEnEspera.Enqueue(new Paciente("Paciente", "Aleatorio"));
                Thread.Sleep(5000);
            }
        }

        private void AtenderPacientes(IMedico iMedico)
        {
            if(this.pacientesEnEspera.Count > 0)
            {
                iMedico.IniciarAtencion(this.pacientesEnEspera.Dequeue());

                if(iMedico is MGeneral)
                {
                    btnGeneral.Enabled = false;
                }
                else
                {
                    btnEspecialista.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("No hay pacientes para atender.");
            }
        }

        private void FinAtencion(Paciente p, Medico  m)
        {
            MessageBox.Show(String.Format("Finalizó la atención de {0} por {1}!", m.EstaAtendiendoA, m.ToString()));

            if (m is MGeneral)
            {
                if (this.btnGeneral.InvokeRequired)
                {
                    this.btnGeneral.BeginInvoke
                    (
                        (MethodInvoker)delegate ()
                        {
                            btnGeneral.Enabled = true;
                        }
                    );
                }
                else
                {
                    btnGeneral.Enabled = true;
                }
            }
            else
            {
                if (this.btnEspecialista.InvokeRequired)
                {
                    this.btnEspecialista.BeginInvoke
                    (
                        (MethodInvoker)delegate ()
                        {
                            btnEspecialista.Enabled = true;
                        }
                    );
                }
                else
                {
                    btnEspecialista.Enabled = true;
                }
            }
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            this.AtenderPacientes(this.medicoGeneral);
        }

        private void btnEspecialista_Click(object sender, EventArgs e)
        {
            this.AtenderPacientes(this.medicoEspecialista);
        }
    }
}
