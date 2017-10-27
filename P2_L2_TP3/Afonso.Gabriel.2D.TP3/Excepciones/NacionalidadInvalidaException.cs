using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        #region Constructor
        public NacionalidadInvalidaException()
            : base("La nacionalidad no se condice con el nº de DNI") { }

        public NacionalidadInvalidaException(string message)
            : base(message) { }
        #endregion
    }
}
