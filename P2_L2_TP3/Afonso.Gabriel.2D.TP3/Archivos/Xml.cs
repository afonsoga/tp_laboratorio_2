using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region Métodos
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(archivo);
                XmlSerializer xml = new XmlSerializer(typeof(T));
                xml.Serialize(sw, datos);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        public bool Leer(string archivo, out T datos)
        {
            try
            {
                StreamReader sr = new StreamReader(archivo);
                XmlSerializer xml = new XmlSerializer(typeof(T));
                datos = (T)xml.Deserialize(sr);
                sr.Close();
                return true;
            }
            catch (Exception e)
            {
                datos = default(T);
                throw new ArchivosException(e);
            }
        }
        #endregion
    }
}
