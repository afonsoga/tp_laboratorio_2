using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos
        List<Alumno> _alumnos;
        Universidad.EClases _clase;
        Profesor _instructor;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }
            set
            {
                this._alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this._clase;
            }
            set
            {
                this._clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this._instructor;
            }
            set
            {
                this._instructor = value;
            }
        }
        #endregion

        #region Constructores
        Jornada()
            : base()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Guarda los datos de la Jornada en un archivo de texto. 
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();
            return txt.Guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Retorna los datos de la Jornada como texto. 
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto txt = new Texto();
            string datos = "";
            txt.Leer("Jornada.txt", out datos);
            return datos;
        }
        #endregion

        #region Sobreescritura
        /// <summary>
        /// Muestra todos los datos de la Jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE: {0} DICTADA POR {1}", this.Clase.ToString(), this.Instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno a in this._alumnos)
            {
                sb.AppendLine(a.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region Sobrecarga
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j._alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados. Caso contrario, se lanza la excepción AlumnoRepetidoException.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j._alumnos.Add(a);
                return j;
            }
            else
                throw new AlumnoRepetidoException();
        }
        #endregion
    }
}
