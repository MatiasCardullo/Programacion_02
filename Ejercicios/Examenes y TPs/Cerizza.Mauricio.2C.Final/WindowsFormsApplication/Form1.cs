using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesPP;

namespace WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        private List<Base> listaElementos;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Final - Mauricio Cerizza";
            listaElementos = new List<Base>();
        }

        private void btnPunto1_Click(object sender, EventArgs e)
        {
            Base derUno1 = new DerivadaUno(10, 11, 12);
            DerivadaUno derUno2 = new DerivadaUno(1, 2, 3);
            Base derDos1 = new DerivadaDos();

            listaElementos.Add(derUno1);
            listaElementos.Add(derUno2);
            listaElementos.Add(derDos1);

            // Generar el código para obtener todos los datos de los elementos de la lista y luego utilizar CargarRichTextBox para mostrarlos
            string auxiliar = "";
            foreach(Base b in this.listaElementos)
            {
                auxiliar += b.VersionFull + "\n";
            }
            this.CargarRichTextBox(auxiliar);
        }

        private void btnPunto2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para primer parcial", "Para primer parcial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnPunto3_Click(object sender, EventArgs e)
        {

        }

        private void btnPunto4_Click(object sender, EventArgs e)
        {

        }

        private void btnPunto5_Click(object sender, EventArgs e)
        {
            
        }

        delegate void CargarRichTextBoxCallback(string datos);
        private void CargarRichTextBox(string datos)
        {
            if (rtbTextoSalida.InvokeRequired)
            {
                CargarRichTextBoxCallback d = new CargarRichTextBoxCallback(CargarRichTextBox);
                this.Invoke(d, new object[] { datos });
            }
            else
            {
                rtbTextoSalida.Text = datos;
            }
        }


        
    }
}
