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
using Entidades;

namespace _20161215_Final
{
    public partial class frmFinal : Form
    {
        public frmFinal()
        {
            InitializeComponent();
        }

        private void btnPunto1_Click(object sender, EventArgs e)
        {
            // TODAS las clases deberán ir en una Biblioteca de Clases llamada Entidades
            // Realizar una clase llamada ReinoVegetal. Debe ser abstracta
            // y poseer los atributos protegidos _valor:float y _gusto:Gusto.
            // Enumerado Gusto contendrá Dulce, Salado y Toxica
            // Generar un constructor que reciba ambos parámetros.
            // Agregar un atributo estático calcularValor:Random. Este atributo sólo se podrá inicializar en un constructor estático.
            // Generar otro constructor que sólo reciba Gusto y asigne en _valor un número aleatorio entre 1 y 100.

            // Generar las clases públicas Fruta, Verdura y Carnibora. Las 3 heredarán de ReinoVegetal.
            // Fruta contendrá el atributo _color:ConsoleColor
            // Verdura contendrá el atributo _tipo:TipoVerdura,
            // siendo los TipoVerdura disponibles: Semilla, Raíz, Tubérculo, Bulbo, Tallo, Hoja, Inflorescencia, Rizoma
            // Carnibora contendrá el atributo _tamanio:int y _tipo:Captura,
            // siendo las Capturas disponibles: Pinzas, Pelos, Caída, Mecánicas, Combinada

            // A las tres clases generarle un constructor que reciba 3 parámetros.
            // A Carnibora generarle otro constructor que reciba 4 parámetros.

            // Descomentar el siguiente código, que deberá funcionar sin modificaciones:
            ReinoVegetal v1 = new Fruta((float)2.5, ReinoVegetal.Gusto.Dulce, ConsoleColor.Red);
            Fruta v2 = new Fruta((float)12.5, ReinoVegetal.Gusto.Dulce, ConsoleColor.Blue);
            Verdura v3 = new Verdura((float)52.5, ReinoVegetal.Gusto.Salado, Verdura.TipoVerdura.Hoja);
            Verdura v4 = new Verdura((float)2.7, ReinoVegetal.Gusto.Toxica, Verdura.TipoVerdura.Raíz);
            Carnibora v5 = new Carnibora((float)14.5, ReinoVegetal.Gusto.Toxica, Carnibora.Captura.Combinada);
            ReinoVegetal v6 = new Carnibora((float)1.2, ReinoVegetal.Gusto.Toxica, Carnibora.Captura.Pelos, 10);
        }

        private void btnPunto2_Click(object sender, EventArgs e)
        {
            // Los atributos de Fruta, Verdura y Carnibora generados en el punto anterior
            // deberán tener propiedades publicas de sólo lectura que expongan sus datos.
            // ReinoVegetal contendrá una conversión explicita a String.
            // Fruta, Verdura y Carnibora contendrá una conversión implicita a String.

            // Descomentar el siguiente código, que deberá funcionar sin modificaciones:
            Fruta v2 = new Fruta((float)12.5, ReinoVegetal.Gusto.Dulce, ConsoleColor.Blue);
            Verdura v4 = new Verdura((float)2.7, ReinoVegetal.Gusto.Toxica, Verdura.TipoVerdura.Raíz);
            Carnibora v5 = new Carnibora((float)1.2, ReinoVegetal.Gusto.Toxica, Carnibora.Captura.Pelos, 10);

            MessageBox.Show(v2);
            MessageBox.Show(v4);
            MessageBox.Show(v5);
        }

        private void btnPunto3_Click(object sender, EventArgs e)
        {
            // Dos elementos del tipo ReinoVegetal serán iguales si son del mismo Tipo (dos frutas, dos verduras o dos carniboras)
            // y tienen el mismo Gusto

            // Descomentar el siguiente código, que deberá funcionar sin modificaciones:
            Fruta v1 = new Fruta((float)2.5, ReinoVegetal.Gusto.Dulce, ConsoleColor.Red);
            Fruta v2 = new Fruta((float)12.5, ReinoVegetal.Gusto.Dulce, ConsoleColor.Blue);
            Verdura v3 = new Verdura((float)52.5, ReinoVegetal.Gusto.Salado, Verdura.TipoVerdura.Hoja);
            Verdura v4 = new Verdura((float)2.7, ReinoVegetal.Gusto.Toxica, Verdura.TipoVerdura.Raíz);
            Carnibora v5 = new Carnibora((float)14.5, ReinoVegetal.Gusto.Toxica, Carnibora.Captura.Combinada);
            Carnibora v6 = new Carnibora((float)1.2, ReinoVegetal.Gusto.Toxica, Carnibora.Captura.Pelos, 10);

            MessageBox.Show("Carnibora y Verdura:" + (v5 == v4));
            MessageBox.Show("Verdura y Verdura:" + (v3 == v4));
            MessageBox.Show("Carnibora y Carnibora:" + (v5 == v6));
        }

        private void btnPunto4_Click(object sender, EventArgs e)
        {
            // Generar la clase Canasta con los atributos _plantas:List del tipo genérico.
            // (este sólo se podrá inicializar en el constructor por defécto, que además será privado)
            // y _capacidad:int (generar un constructor que lo reciba como parámetros).

            // Generar la Excepción propia NoAgregaException con un único constructor que reciba el mensaje a mostrar.

            // Al sumar una canasta con un elemento del ReinoVegetal se deberá a gregar a la lista de _plantas
            // SÓLO si el tipo genérico de la Canasta es igual al elemento del ReinoVegetal (Fruta, Verdura, Carnibora)
            // y aun hay lugar en la canasta.
            // Si no son del mismo tipo, el mensaje deberá ser "El elemento es del tipo {0}. Se esperaba {1}.".
            // ¡Se deberá utilizar Format de String!
            // Si la capacidad está al límite, el mensaje será "Capacidad completa.".
            // Utilizar T aux = (T)Convert.ChangeType(reinoVegetal, typeof(T)); para convertir un ReinoVegetal en T (tipo genérico).

            // Descomentar el siguiente código, que deberá funcionar sin modificaciones:
            Fruta v1 = new Fruta((float)2.5, ReinoVegetal.Gusto.Dulce, ConsoleColor.Red);
            Fruta v2 = new Fruta((float)12.5, ReinoVegetal.Gusto.Dulce, ConsoleColor.Blue);
            Fruta v3 = new Fruta((float)10.2, ReinoVegetal.Gusto.Dulce, ConsoleColor.Green);
            Verdura v4 = new Verdura((float)2.7, ReinoVegetal.Gusto.Toxica, Verdura.TipoVerdura.Raíz);

            Canasta<Fruta> canasta1 = new Canasta<Fruta>(2);

            canasta1 += v1;
            canasta1 = canasta1 + v2;
            try
            {
                canasta1 += v3;
            }
            catch (NoAgregaException ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                canasta1 += v4;
            }
            catch (NoAgregaException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPunto5_Click(object sender, EventArgs e)
        {
            // Generar la interfaz pública IVegetales, con la firma del método MostrarDatos:string.
            // Implementar la interfaz en Fruta, Verdura y Carnibora. Siempre rehutilizar código.
            // Canasta sólo deberá aceptar tipos T que implementen la interfaz.
            // Sobrecargar ToString de canasta para mostrar todos los datos de los elementos de la lista.

            // Descomentar el siguiente código, que deberá funcionar sin modificaciones:
            Fruta v1 = new Fruta((float)2.5, ReinoVegetal.Gusto.Dulce, ConsoleColor.Red);
            Fruta v2 = new Fruta((float)12.5, ReinoVegetal.Gusto.Dulce, ConsoleColor.Blue);

            Canasta<Fruta> canasta1 = new Canasta<Fruta>(2);

            canasta1 += v1;
            canasta1 = canasta1 + v2;
            MessageBox.Show(canasta1.ToString());
        }

        private void btnPunto6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Realizar un Test Unitario que pruebe el constructor de Canasta, corroborando que la lista quede instanciada");
            MessageBox.Show("Realizar otro Test Unitario que pruebe el constructor de ReinoVegental que recibe sólo un parámetro, corroborando el estado de _valor.");
        }             

        private void btnPunto7_Click(object sender, EventArgs e)
        {
            // Generar un método de Extención para la clase Fruta llamado MostrarElemento.
            // El método deberá retornar los datos del objeto, rehutilizando código.

            // Descomentar el siguiente código, que deberá funcionar sin modificaciones:
            Fruta f = new Fruta((float)22.5, ReinoVegetal.Gusto.Dulce, ConsoleColor.DarkYellow);

            MessageBox.Show(f.MostrarElemento()); 
        }

        private void btnPunto8_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Ejecutar mediante un hilo el método ProbarTodo.");
            Thread t = new Thread(ProbarTodo);
            t.Start();
        }

        private void ProbarTodo()
        {
            object sender = this;
            EventArgs e = new EventArgs();

            btnPunto1_Click(sender, e);
            btnPunto2_Click(sender, e);
            btnPunto3_Click(sender, e);
            btnPunto4_Click(sender, e);
            btnPunto5_Click(sender, e);
        }

        
    }
}
