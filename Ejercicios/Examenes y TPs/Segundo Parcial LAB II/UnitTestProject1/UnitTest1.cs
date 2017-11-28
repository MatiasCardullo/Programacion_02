using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesHechas;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ListaPaquetesInstanciada()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }

        [TestMethod]
        public void NoCargarDosPaquetesEnLista()
        {
            Correo c = new Correo();
            Paquete p1 = new Paquete("Dirección", "1234");
            Paquete p2 = new Paquete("OtraDirección", "1234");
            try
            {
                c += p1;
                c += p2;
                Assert.Fail(); //Si llegò acà cargò los dos paquetes y està mal.
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e,typeof(TrackingIdRepetidoException));
                //Si llego acà està bien.
            }
        }


    }
}
