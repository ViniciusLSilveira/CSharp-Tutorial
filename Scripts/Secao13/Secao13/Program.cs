using System;
using System.IO;
using System.Globalization;
using Secao13.Entities;

namespace Secao13
{
    class Program
    {
        static void Main(string[] args)
        {

            // EXERCICIO FIXACAO

            string sourceFilePath = @"C:\Users\vinil\AppData\Local\Temp\__TESTS__\csharp-tutorial\secao13\products.csv";

            try
            {
                string[] lines = File.ReadAllLines(sourceFilePath);

                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                string targetFolderPath = sourceFolderPath + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter sw = File.CreateText(targetFilePath)) {
                     
                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(',');

                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);

                        Product prod = new Product(name, price, quantity);

                        sw.WriteLine(prod.Name + ", " + prod.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error ocurred");
                Console.WriteLine(e.Message);
            }


        }
    }
}
