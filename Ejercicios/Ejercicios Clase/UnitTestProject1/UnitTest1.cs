using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clase_16_Library;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Comprobar que la propiedad DNI 
        /// reciba números entre 1 y 99.999.999 Si se carga un DNI con un número distinto a los aceptados, 
        /// se arrojará DniInvalidoException.
        /// </summary>
        [TestMethod]
        public void Comprobar_Propiedad_DNI()
        {
            Persona p = new Persona("Juan", "Perez", Persona.ENacionalidad.Argentino);
            try
            {                
                p.DNI = 999999999;
                Assert.Fail(); //Si llega acá falló. 
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException)); //La excepción lanzada debe ser del tipo DNIInvalidoException. 
            }

            try
            {
                p.DNI = 0;
                Assert.Fail(); //Si llega acá falló. 
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException)); //La excepción lanzada debe ser del tipo DNIInvalidoException. 
            }

            try
            {
                p.DNI = 1;
                
            }
            catch (Exception e)
            {
                Assert.Fail(); //Si llega acá falló. 
            }
        }

        /// <summary>
        /// Si el número está entre 1 y 89.999.999, la nacionalidad debe ser Argentino. Si no, extranjero. 
        /// Si se carga un DNI con un número distinto a los correspondientes según su nacionalidad, se arrojará NacionalidadInvalidaException.
        /// </summary>
        [TestMethod]
        public void Comprobar_Propiedad_DNI()
        {
            Persona p = new Persona("Juan", "Perez", Persona.ENacionalidad.Argentino);
            try
            {
                p.DNI = 999999999;
                Assert.Fail(); //Si llega acá falló. 
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException)); //La excepción lanzada debe ser del tipo DNIInvalidoException. 
            }

            try
            {
                p.DNI = 0;
                Assert.Fail(); //Si llega acá falló. 
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException)); //La excepción lanzada debe ser del tipo DNIInvalidoException. 
            }

            try
            {
                p.DNI = 1;

            }
            catch (Exception e)
            {
                Assert.Fail(); //Si llega acá falló. 
            }
        }
    }
}
