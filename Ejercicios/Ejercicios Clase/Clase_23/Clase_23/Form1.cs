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

namespace Clase_23
{
    public partial class Form1 : Form
    {

        RelojThread rt;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rt = new RelojThread();
            
            rt.Segundero += MostrarHora;

            rt.Thread.Start();
        }

        public void MostrarHora(string message)
        {
            if (this.label1.InvokeRequired)
            {
                this.label1.BeginInvoke(
                    (MethodInvoker)delegate ()
                    {
                        label1.Text = message;
                    }
                );
            }
            else
            {
                label1.Text = message;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(rt.Thread.IsAlive)
            {
                rt.Thread.Abort();
            }
        }
    }
}
