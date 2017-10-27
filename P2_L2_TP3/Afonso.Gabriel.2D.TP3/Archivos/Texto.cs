using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Métodos
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(archivo);
                sw.Write(datos);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader sr = new StreamReader(archivo);
                if (File.Exists(archivo))
                {
                    datos = sr.ReadToEnd();
                    sr.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            datos = default(string);
            return false;
        }
        #endregion
    }
}
