using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_L2_TP1
{
    class Calculadora
    {
        /// <summary>
        ///  Opera matemáticamente dos objetos del tipo Numero según el operador indicado.
        /// </summary>
        /// <param name="numero1">Es el primer operando, de tipo Numero</param>
        /// <param name="numero2">Es el segundo operando, de tipo Numero</param>
        /// <param name="operador">Es el operador a utilizar en el cálculo matemático</param>
        /// <returns>Es el resultado de la operación realizada.  Si no puede operar retornará 0.</returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;

            switch (validarOperador(operador))
            {
                case "+": resultado = numero1.getNumero() + numero2.getNumero();
                    break;
                case "-": resultado = numero1.getNumero() - numero2.getNumero();
                    break;
                case "*": resultado = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    if (numero2.getNumero() != 0)
                        resultado = numero1.getNumero() / numero2.getNumero();
                    break;
                default:
                    break;
            }
            return resultado;
        }

        /// <summary>
        ///  Valida que el operador sea un caracter válido.
        /// </summary>
        /// <param name="operador">Es el operador a validar en tipo string</param>
        /// <returns>Es el operador a utilizar en la operación.  Si no puede validarlo retorna "+".</returns>
        public static string validarOperador(string operador)
        {
            string retorno = "+";

            if (operador == "-" || operador == "*" || operador == "/")
                retorno = operador;

            return retorno;
        }

    }
}
