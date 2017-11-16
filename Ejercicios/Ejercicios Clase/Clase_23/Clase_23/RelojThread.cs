using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clase_23
{
    class RelojThread
    {
        public delegate void EventHandler(string s);
        public event EventHandler Segundero;
        Thread thread;

        public Thread Thread
        {
            get
            {
                return this.thread;
            }
        }

        public RelojThread()
        {
            thread = new Thread(DispararSegundero);
        }

        public void DispararSegundero()
        {
            while (true)
            {
                Segundero(DateTime.Now.ToString("HH : mm : ss"));
                Thread.Sleep(1000);
            }
        }
    }
}
