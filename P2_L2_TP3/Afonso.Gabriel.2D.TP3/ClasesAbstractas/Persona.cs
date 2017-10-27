using Excepciones;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enumerados
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Atributos
        string _apellido;
        int _dni;
        ENacionalidad _nacionalidad;
        string _nombre;
        #endregion

        #region Propiedades
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = this.ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = this.ValidarNombreApellido(value);
            }
        }

        public string StringToDni
        {
            set
            {
                this._dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Valida que el DNI sea correcto, teniendo en cuenta su nacionalidad. Caso contrario, se lanza la excepción DniInvalidoException o NacionalidadInvalidaException.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && (dato < 1 || dato > 89999999))
                throw new DniInvalidoException();
            else if (nacionalidad == ENacionalidad.Extranjero && (dato < 90000000))
                throw new NacionalidadInvalidaException();
            else
                return dato;
        }

        /// <summary>
        /// Valida que el DNI sea correcto, teniendo en cuenta su nacionalidad. Caso contrario, se lanza la excepción DniInvalidoException.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            if (int.TryParse(dato, out dni))
                return this.ValidarDni(nacionalidad, dni);
            else
                throw new DniInvalidoException();
        }

        /// <summary>
        /// Valida que los nombres sean cadenas con caracteres válidos para nombres. Caso contrario, no se carga.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        string ValidarNombreApellido(string dato)
        {
            foreach (char c in dato)
            {
                if (char.IsNumber(c) || char.IsWhiteSpace(c))
                    return null;
            }
            return dato;
        }
        #endregion

        #region Sobreescritura
        /// <summary>
        /// Retorna los datos de la Persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.Apellido), CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.Nombre));
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad.ToString());
            sb.Append("DNI: " + this.DNI.ToString());
            return sb.ToString();
        }
        #endregion
    }
}
