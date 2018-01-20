using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesPP
{
    public sealed class DerivadaUno : Base
    {
        private static int revision;

        public override string VersionFull
        {
            get 
            {
                return this.MostrarVersion();
            }
        }

        static DerivadaUno()
        {
                
        }

        public DerivadaUno(int version, int subversion, int revision)
            :base(version,subversion)
        {
            DerivadaUno.revision = revision;
        }

        protected override string MostrarVersion()
        {
            return String.Format("{0}.{1}", base.MostrarVersion(), DerivadaUno.revision);
        }



    }
}
