using System;
using System.Globalization;

namespace Secao05
{
    class Program
    {
        static void Main(string[] args)
        {

            ContaBancaria cb;

            Console.Write("Entre o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.Write("Entre o titular da conta: ");
            string nomeTitular = Console.ReadLine();

            Console.Write("Haverá depósito inicial (s/n)? ");
            char resp = char.Parse(Console.ReadLine());

            if (resp == 's' || resp == 'S')
            {
                Console.Write("Entre o valor de depósito inicial: ");
                double deposito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                cb = new ContaBancaria(numeroConta, nomeTitular, deposito);
            }
            else
            {
                cb = new ContaBancaria(numeroConta, nomeTitular);
            }

            Console.WriteLine();

            Console.WriteLine("Dados da conta: ");
            Console.WriteLine(cb);

            Console.Write("Entre com um valor para o depósito: ");
            double quantiaDeposito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            cb.Deposito(quantiaDeposito);

            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(cb);

            Console.Write("Entre com um valor para o saque: ");
            double quantiaSaque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            cb.Saque(quantiaSaque);

            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(cb);
        }

    }
}