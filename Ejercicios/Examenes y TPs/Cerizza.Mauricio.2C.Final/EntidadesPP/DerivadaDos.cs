using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesPP
{
    public class DerivadaDos : Base
    {
        public override string VersionFull
        {
            get
            {
                return this.MostrarVersion();
            }
        }

        public DerivadaDos()
            :base(1,0)
        {

        }

        protected override string MostrarVersion()
        {
            return String.Format("{0}", base.MostrarVersion());
        }
    }
}
