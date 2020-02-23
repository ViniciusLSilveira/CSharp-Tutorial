using System;
using System.Globalization;
using Secao14.Entities;
using Secao14.Services;

namespace Secao14
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Contract value: 600.00
            Enter number of installments: 3
            Installments:
            25/07/2018 - 206.04
            25/08/2018 - 208.08
            25/09/2018 - 210.12
            */

            Console.WriteLine("Enter contract data");

            Console.Write("Number: ");
            int contractNumber = int.Parse(Console.ReadLine());
            
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime contractDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Contract value: ");
            double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine());

            Contract contract = new Contract(contractNumber, contractDate, contractValue);

            ContractService contractService = new ContractService(new PaypalService());

            contractService.ProcessContract(contract, months);

            Console.WriteLine("Installments:");
            Console.WriteLine(contract.ToString());
        }
    }
}
