using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_Practico_01
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            cmbOperacion.SelectedIndex = 0;
        }
        
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text == "" || txtNumero2.Text == "") //Si no se ingresaron valores para los operandos
            {
                MessageBox.Show("¡Debe ingresar el valor de los operandos!", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Object selectedItem = cmbOperacion.SelectedItem;
                string operador = selectedItem.ToString();
                Numero numero1 = new Numero(txtNumero1.Text);
                Numero numero2 = new Numero(txtNumero2.Text);
                double resultado = Calculadora.operar(numero1, numero2, operador);
                lblResultado.Text = resultado.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperacion.SelectedIndex = 0;
        }
    }
}
