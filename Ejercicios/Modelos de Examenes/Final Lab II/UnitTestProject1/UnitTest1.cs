using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using frmFinal;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConstructoresPaciente()
        {
            Paciente p1 = new Paciente("Nombre", "Apellido"); 
            Paciente p2 = new Paciente("Nombre", "Apellido", 5);
            Paciente p3 = new Paciente("Nombre", "Apellido");

            Assert.IsTrue(p1.Turno == 1);
            Assert.IsTrue(p2.Turno == 5);
            Assert.IsTrue(p3.Turno == 6);
        }
    }
}
