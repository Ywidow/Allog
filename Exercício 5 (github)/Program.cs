using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Exercício5{
    internal class Program{
        static void Main(string[] args){
            double F, C;
            string phrase;
            bool isNumeric = false;
            do
            {
                Console.Clear(); //Limpar o console.
                Console.WriteLine("Digite a temperatura em Fahrenheit: ");
                phrase = Console.ReadLine(); //Atribuindo o valor escrito a "phrase".

                phrase = phrase.Replace(".", ","); //Replace para caso tenha utilizado '.' ao invés de ','.

                isNumeric = double.TryParse(phrase, out F); ///Tenta transformar a string "phrase" em um int, caso não consiga, retorna o valor false para "isNumeric".
                                                               
                if (isNumeric) //Condição para caso a conversão seja feita.
                {
                    F = double.Parse(phrase); C = (F - 32) * 5 / 9; //Cálculo pra conversão

                    Console.WriteLine("A temperatura " + F + " F em celsius é igual a: " + C + " C");
                    Console.Read();
                }
                else //Condição para caso a conversão não seja feita.
                {
                    Console.WriteLine("Deu ruim amigão...") 
                    Thread.Sleep(2000); //Descanso de 2s para responder a questão de novo.

                }
            }
            while (isNumeric == false); //Laço para ser necessário a inscrição de um valor conversível.
        }
    }
}
