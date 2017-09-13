using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_L2_TP1
{
    public class Numero
    {
        private double _numero;

        /// <summary>
        /// Retorna el valor del numero en formato double
        /// </summary>
        /// <returns>Valor del numero</returns>
        public double getNumero()
        {
            return this._numero;
        }

        /// <summary>
        /// Constructor de instancia por defecto
        /// </summary>
        public Numero()
        {
            this._numero = 0;
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="numero">Valor inicial de numero en tipo double</param>
        public Numero(double numero)
        {
            this._numero = numero;
        }

        /// <summary>
        /// Constructor de instancia
        /// Utiliza el método setNumero
        /// </summary>
        /// <param name="numero">Valor inicial de numero en tipo string</param>
        public Numero(string numero)
        { 
            setNumero(numero);
        }

        /// <summary>
        /// Asigna el valor inicial de numero
        /// Utiliza el método validarNumero
        /// </summary>
        /// <param name="numero">Valor inicial de numero en tipo string</param>
        private void setNumero(string numero)
        {
            this._numero = validarNumero(numero);
        }

        /// <summary>
        /// Valida que se pueda parsear el numero en tipo string a doble
        /// </summary>
        /// <param name="numeroString">Es el numero a validar en tipo string</param>
        /// <returns>Es el numero validado en tipo double</returns>
        private static double validarNumero(string numeroString)
        {
            double retorno;
            bool puedeValidar = double.TryParse(numeroString, out retorno);

            if (!puedeValidar)
                retorno = 0;

            return retorno;
       }
    }
}
