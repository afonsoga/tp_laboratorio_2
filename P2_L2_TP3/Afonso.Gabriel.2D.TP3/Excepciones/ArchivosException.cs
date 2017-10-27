using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        #region Constructor
        public ArchivosException(Exception innerException)
            : base("Error. No se puede acceder al archivo", innerException) { }
        #endregion
    }
}
