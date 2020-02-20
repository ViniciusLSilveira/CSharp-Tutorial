using System;
using System.Globalization;

namespace Secao04
{
    class Program
    {
        static void Main(string[] args)
        {

            double dolarCotacao, dolarComprado, real;

            Console.Write("Qual a cotação do dolar? ");
            dolarCotacao = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Quantos dólares você vai comprar? ");
            dolarComprado = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            real = ConversorMoeda.DolarToReal(dolarCotacao, dolarComprado);

            Console.WriteLine("Valor a ser pago em reais: " + real.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
