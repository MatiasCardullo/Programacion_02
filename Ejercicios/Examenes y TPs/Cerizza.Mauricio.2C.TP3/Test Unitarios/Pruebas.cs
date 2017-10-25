using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;
using Excepciones;
using System.Collections.Generic;

namespace Test_Unitarios
{
    [TestClass]
    public class Pruebas
    {
        /// <summary>
        /// Testea que se lance la excepción SinProfesorException 
        /// cuando no hay un profesor que de esa clase.
        /// </summary>
        [TestMethod]
        public void TestSinProfesorException()
        {
            //Genero una universidad.
            Universidad u = new Universidad();

            //Genero dos profesores y los agrego a la lista de la universidad.
            Profesor p1 = new Profesor(1, "Federico", "Davila", "12.345.678", Persona.ENacionalidad.Argentino);
            Profesor p2 = new Profesor(2, "Mauricio", "Davila", "87.654.321", Persona.ENacionalidad.Argentino);
            u += p1;
            u += p2;

            //Le asigno a los profesores la lista de materias que dan.
            List<Universidad.EClases> listaDeMaterias = new List<Universidad.EClases>();
            listaDeMaterias.Add(Universidad.EClases.Laboratorio);
            listaDeMaterias.Add(Universidad.EClases.Programacion);
            //En este momento la listaDeMaterias solo tiene Laboratorio y Programación. 
            //Por lo tanto los profesores sólo darán esas materias.
            p1.ClasesDelDía = listaDeMaterias;
            p2.ClasesDelDía = listaDeMaterias;

            //Genero una nueva jornada de la clase de Legislación.
            try
            {
                u += Universidad.EClases.Legislacion;
                //Debe lanzar la excepción ya que no hay profesores para esa clase.
            }
            catch (SinProfesorException e)
            {
                Assert.IsInstanceOfType(e, typeof(SinProfesorException)); 
            }
        }

        /// <summary>
        /// Testea que se lance la excepción DNIInvalidoException al ingresar un formato de DNI inválido.
        /// </summary>
        [TestMethod]
        public void TestDNIInvalidoException()
        {
            //Letra en DNI. 
            try
            {
                Alumno a = new Alumno(1, "Mauricio", "Cerizza", "36.688.a59", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Assert.Fail(); //Si llegó acá está mal.
            }
            catch (DniInvalidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            //Con comas...
            try
            {
                Alumno a = new Alumno(1, "Mauricio", "Cerizza", "36,688,159", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Assert.Fail(); //Si llegó acá está mal.
            }
            catch (DniInvalidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            //Sin nada...
            try
            {
                Alumno a = new Alumno(1, "Mauricio", "Cerizza", "", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Assert.Fail(); //Si llegó acá está mal.
            }
            catch (DniInvalidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            //Fuera del rango permitido para cualquier nacionalidad.
            try
            {
                Alumno a = new Alumno(1, "Mauricio", "Cerizza", "0", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Assert.Fail(); //Si llegó acá está mal.
            }
            catch (DniInvalidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            try
            {
                Alumno a = new Alumno(1, "Mauricio", "Cerizza", "100000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Assert.Fail(); //Si llegó acá está mal.
            }
            catch (DniInvalidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        /// <summary>
        /// Testea que se lance la excepción NacionalidadInvalidaException al ingresar 
        /// un DNI en el rango incorrecto.
        /// </summary>
        [TestMethod]
        public void TestNacionalidadInvalidaException()
        {
            //Argentino fuera de rango.
            try
            {
                Alumno a = new Alumno(1, "Mauricio", "Cerizza", "90000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Assert.Fail(); //Si llegó acá está mal.
            }
            catch (NacionalidadInvalidaException e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

            //Argentino en rango.
            try
            {
                Random random = new Random();
                int dni = random.Next(1, 90000000);
                Alumno a = new Alumno(1, "Mauricio", "Cerizza", dni.ToString(), Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);                
            }
            catch (NacionalidadInvalidaException e)
            {
                Assert.Fail(); //Si llegó acá está mal.
            }

            //Extranjero fuera de rango.
            try
            {
                Alumno a = new Alumno(1, "Mauricio", "Cerizza", "89999999", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
                Assert.Fail(); //Si llegó acá está mal.
            }
            catch (NacionalidadInvalidaException e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

            //Extranjero en rango.
            try
            {
                Random random = new Random();
                int dni = random.Next(90000000, 99999999);
                Alumno a = new Alumno(1, "Mauricio", "Cerizza", dni.ToString(), Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            }
            catch (NacionalidadInvalidaException e)
            {
                Assert.Fail(); //Si llegó acá está mal.
            }
        }

        /// <summary>
        /// Testea que el valor de los DNI se cargue correctamente.
        /// </summary>
        [TestMethod]
        public void TestDNI()
        {
            Alumno a = new Alumno(1, "Mauricio", "Cerizza", "36.688.159", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.IsTrue(36688159 == a.DNI);

            Alumno b = new Alumno(2, "Mariano", "Burgos", "12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Assert.IsTrue(12345678 == b.DNI);

            Profesor p = new Profesor(1, "Juan", "Perez", "90.654.321", Persona.ENacionalidad.Extranjero);
            Assert.IsTrue(90654321 == p.DNI);
        }

        /// <summary>
        /// Testea que al generar un profesor, su atributo clasesDelDia no sea NULL.
        /// </summary>
        [TestMethod]
        public void TestClasesDelDiaNoEsNull()
        {
            Profesor p1 = new Profesor(1, "Federico", "Davila", "12.345.678", Persona.ENacionalidad.Argentino);

            Assert.IsNotNull(p1.ClasesDelDía);
        }
    }
}
