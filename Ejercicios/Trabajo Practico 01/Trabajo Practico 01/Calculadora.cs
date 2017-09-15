using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Practico_01
{
    class Calculadora
    {
        /*Recibe 2 objetos de tipo Numero y un string que representa al operador elegido. 
        Realiza la operación indicada entre los dos numeros y devuelve el resultado.
        Valida la división. */
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double retorno = 0;
            double operando1 = numero1.getNumero();
            double operando2 = numero2.getNumero();

            switch(validarOperador(operador)){
                case "+":
                    retorno = operando1 + operando2;
                    break;
                case "-":
                    retorno = operando1 - operando2;
                    break;
                case "*":
                    retorno = operando1 * operando2;
                    break;
                case "/":
                    if(operando2 != 0)
                    {
                        retorno = operando1 / operando2;
                    }
                    else
                    {
                        retorno = 0;
                    }
                    break;
            }
            return retorno;
        }

        //Valida que el operador sea un caracter válido, caso contrario retorna "+"
        public static string validarOperador(string operador)
        {
            string retorno;
            switch (operador)
            {
                case "+":
                    retorno = "+";
                    break;
                case "-":
                    retorno = "-";
                    break;
                case "*":
                    retorno = "*";
                    break;
                case "/":
                    retorno = "/";
                    break;
                default:
                    retorno = "+";
                    break;
            }

            return retorno;
        }
    }
}
