using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region Atributos
        static string _mensajeBase = "DNI invalido";
        #endregion

        #region Constructor
        public DniInvalidoException()
            : base(_mensajeBase) { }

        public DniInvalidoException(Exception e)
            : base(_mensajeBase, e) { }

        public DniInvalidoException(string message)
            : base(message) { }

        public DniInvalidoException(string message, Exception e)
            : base(message, e) { }
        #endregion
    }
}
