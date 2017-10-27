using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Enumerados
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region Atributos
        List<Alumno> _alumnos;
        List<Jornada> _jornada;
        List<Profesor> _profesores;
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

        public List<Jornada> Jornadas
        {
            get
            {
                return this._jornada;
            }
            set
            {
                this._jornada = value;
            }
        }

        public List<Profesor> Instructores
        {
            get
            {
                return this._profesores;
            }
            set
            {
                this._profesores = value;
            }
        }
        /// <summary>
        /// Accede a una Jornada específica a través de un indexador.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                return this._jornada[i];
            }
            set
            {
                this._jornada[i] = value;
            }
        }
        #endregion

        #region Constructores
        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._profesores = new List<Profesor>();
            this._jornada = new List<Jornada>();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Serializa los datos de un Universidad en un XML, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Guardar("Universidad.xml", gim);
            return true;
        }
        /// <summary>
        /// Retorna un Universidad con todos los datos previamente serializados.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Universidad gim;
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer("Universidad.xml", out gim);
            return gim;
        }

        static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            foreach (Jornada j in gim.Jornadas)
            {
                sb.Append(j.ToString());
                sb.AppendLine("*---*---*---*---*---*---*---*---*---*---*");
            }
            
            return sb.ToString();
        }
        #endregion

        #region Sobreescritura
        /// <summary>
        /// Hce públicos los datos de un Universidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion

        #region Sobrecarga

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g._alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Agrega un Alumno, validando que no esté previamente cargado.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g._alumnos.Add(a);
                return g;
            }
            else
                throw new AlumnoRepetidoException();
        }

        /// <summary>
        /// Retorna el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            return (g == clase);
        }

        /// <summary>
        /// Retorna el primer Profesor capaz de dar esa clase. Sino, lanza la Excepción SinProfesorException.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
       
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor p in g._profesores)
            {
                if (p == clase)
                    return p;
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Agrega una clase a un Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor = (g == clase);
            Jornada nuevaJornada = new Jornada(clase, profesor);
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                    nuevaJornada += alumno;
            }
            g._jornada.Add(nuevaJornada);
            return g;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor p in g._profesores)
            {
                if (p == i)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Agrega un Profesor, validando que no esté previamente cargado.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
                g._profesores.Add(i);
            return g;
        }
        #endregion
    }
}
