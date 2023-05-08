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
                Console.Clear();
                Console.WriteLine("Digite a temperatura em Fahrenheit: ");
                phrase = Console.ReadLine();

                phrase = phrase.Replace(".", ",");

                isNumeric = double.TryParse(phrase, out F);

                if (isNumeric)
                {
                    F = double.Parse(phrase); C = (F - 32) * 5 / 9;

                    Console.WriteLine("A temperatura " + F + " F em celsius é igual a: " + C + " C");
                    Console.Read();
                }
                else
                {
                    Console.WriteLine("Deu ruim amigão...");
                    Thread.Sleep(2000);

                }
            }
            while (isNumeric == false);
        }
    }
}
