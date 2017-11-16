using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        public delegate void descargaCompletaEventHandler(string html);
        public event descargaCompletaEventHandler descargaCompletada;

        public delegate void descargaEnProgresoEventHandler(int progreso);
        public event descargaEnProgresoEventHandler descargaEnProgreso;
        

        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;
                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            descargaEnProgreso(e.ProgressPercentage);
        }

        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                descargaCompletada(e.Result);
            }
            catch (Exception)
            {
                descargaCompletada("Error, URL inválida.");
            }                       
        }
    }
}
