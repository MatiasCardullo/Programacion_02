using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanastaListaInstanciada()
        {
            Canasta<Fruta> c = new Canasta<Fruta>(2);
            Fruta f = new Fruta((float)2.5, ReinoVegetal.Gusto.Dulce, ConsoleColor.Black);

            try
            {
                c += f;
            }
            catch (NullReferenceException)
            {
                Assert.Fail();
            }

        }

        [TestMethod]
        public void ConstructorReinoVegetal()
        {
            ReinoVegetal r = new ClasePrueba(ReinoVegetal.Gusto.Dulce);
            Assert.IsTrue(((ClasePrueba)r).Valor >= 1 && ((ClasePrueba)r).Valor <= 100);            
        }
    }
}
