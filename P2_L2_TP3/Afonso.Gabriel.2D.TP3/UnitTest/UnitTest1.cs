using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using EntidadesAbstractas;
using ClasesInstanciables;
using Excepciones;


namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Crea un profesor con un Dni invalido y verifica que tire la excepción correcta
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ComprobarExcepcionDniInvalido()
        {
            Profesor uno = new Profesor(2, "Roberto", "Juarez", "-5", Persona.ENacionalidad.Argentino);
        }

        /// <summary>
        /// Crea un alumno con un Dni que no corresponde con su nacionalidad y verifica que tire la excepción correcta
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void ComprobarExcepcionNacionalidadInvalida()
        {
            Alumno uno = new Alumno(2, "Juana", "Martinez", "12234458", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
        }

        /// <summary>
        /// Intenta crear una clase sin profesor que pueda darla
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void ComprobarExcepcionSinProfesor()
        {
            Universidad uni = new Universidad();
            uni += Universidad.EClases.Programacion;
        }
        
        /// <summary>
        /// Testea la excepción AlumnoRepetidoException en caso de que se repita un Alumno
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void Alumno_Repetido()
        {
            Universidad g = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            Alumno a2 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);

            g += a1;
            g += a2;
        }

        /// <summary>
        /// Testea que las propiedades de una Universidad no sean null.
        /// </summary>
        [TestMethod]
        public void Universidad_Propiedades_NotNull()
        {
            Universidad g = new Universidad();
            //g.Instructores = null; //Ejemplo en el que la test fallaría

            if ((g.Alumnos == null) || (g.Jornadas == null) || (g.Instructores == null))
                Assert.Fail();
        }
    }
}
