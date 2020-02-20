using System;
using System.Globalization;
using System.Collections.Generic;
using Secao10.Polimorfismo.ExercicioResolvido.Entities;
using Secao10.Polimorfismo.ExercicioFixacao.Entities;
using Secao10.Abstratos.ExercicioResolvido.Entities;
using Secao10.Abstratos.ExercicioResolvido.Entities.Enums;
using Secao10.Abstratos.ExercicioFixacao.Entities;

namespace Secao10
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExercicioResolvidoPolimorfismo();
            //ExercicioFixacaoPolimorfismo();
            //ExercicioResolvidoAbstrato();
            ExercicioFixacaoAbstrato();
        }

        static void ExercicioResolvidoPolimorfismo()
        {
            List<Employee> employees = new List<Employee>();

            Console.Write("Enter the number of employees: ");
            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i++)
            {

                Console.WriteLine("\n---------------------------------\n");
                Employee emp;

                Console.WriteLine($"Employee #{i} data: ");
                Console.Write("Outsourced (y/n)? ");
                char outsourced = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Hours: ");
                int hours = int.Parse(Console.ReadLine());

                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (outsourced == 'y' || outsourced == 'Y')
                {
                    Console.Write("Additional charge: ");
                    double additionalCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    emp = new OutsourcedEmployee(name, hours, valuePerHour, additionalCharge);

                }
                else
                {
                    emp = new Employee(name, hours, valuePerHour);
                }

                employees.Add(emp);
            }

            Console.WriteLine("\n---------------------------------\n");

            Console.WriteLine("PAYMENTS: ");
            foreach (Employee e in employees)
            {
                Console.WriteLine(e.ToString());
            }
        }
        
        static void ExercicioFixacaoPolimorfismo()
        {
            List<Product> products = new List<Product>();

            Console.Write("Enter the number of products: ");
            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine($"Product #{i} data: ");
                Console.Write("Common, used or imported (c/u/i)? ");
                char resp = char.Parse(Console.ReadLine());

                if (!(resp == 'c' || resp == 'C' || resp == 'u' || resp == 'U' || resp == 'i' || resp == 'I'))
                {
                    Console.WriteLine("\n------------------------------------");
                    Console.WriteLine("Invalid Answer\nTry Again!");
                    Console.WriteLine("------------------------------------\n");
                    i = i - 1;
                    continue;
                }

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (resp == 'c' || resp == 'C')
                {
                    products.Add(new Product(name, price));
                }
                else if (resp == 'u' || resp == 'U')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                    products.Add(new UsedProduct(name, price, manufactureDate));
                }
                else if (resp == 'i' || resp == 'I')
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    products.Add(new ImportedProduct(name, price, customsFee));
                }
            }

            Console.WriteLine("--------------------------------------------");

            foreach (Product p in products)
            {
                Console.WriteLine(p.PriceTag());
            }
        }

        static void ExercicioResolvidoAbstrato()
        {
            List<Shape> shapes = new List<Shape>();

            Console.Write("Enter the number of shapes: ");
            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine($"Shape #{i} data: ");
                Console.Write("Rectangle or Circle (r/c)? ");
                char shape = char.Parse(Console.ReadLine());

                if (!(shape == 'r' || shape == 'R' || shape == 'c' || shape == 'C'))
                {
                    Console.WriteLine("\n------------------------------------");
                    Console.WriteLine("Invalid Answer\nTry Again!");
                    Console.WriteLine("------------------------------------\n");
                    i = i - 1;
                    continue;
                }

                Console.Write("Color (Black/Blue/Red): ");
                Color color = (Color)Enum.Parse(typeof(Color), Console.ReadLine());

                if(shape == 'r' || shape == 'R')
                {
                    Console.Write("Width: ");
                    double width = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    
                    Console.Write("Height ");
                    double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    shapes.Add(new Rectangle(width, height, color));
                }
                else if (shape == 'c' || shape == 'C')
                {
                    Console.Write("Radius ");
                    double radius = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    shapes.Add(new Circle(radius, color));
                }

            }

            Console.WriteLine("\n--------------------------------------\n");
            Console.WriteLine("SHAPE AREAS: ");

            foreach (Shape s in shapes)
            {
                Console.WriteLine(s.Area().ToString("F2", CultureInfo.InvariantCulture));
            }
        }

        static void ExercicioFixacaoAbstrato()
        {
            List<TaxPayer> taxes = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");

                Console.Write("Individual or company (i/c)? ");
                char resp = char.Parse(Console.ReadLine());

                if(!(resp == 'i' || resp == 'I' || resp == 'c' || resp == 'C'))
                {
                    Console.WriteLine("\n------------------------------------");
                    Console.WriteLine("Invalid Answer\nTry Again!");
                    Console.WriteLine("------------------------------------\n");
                    i = i - 1;
                    continue;
                }

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Annual income: ");
                double annualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(resp == 'i' || resp == 'I')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    taxes.Add(new Individual(name, annualIncome, healthExpenditures));
                }
                else if (resp == 'c' || resp == 'C')
                {
                    Console.Write("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());

                    taxes.Add(new Company(name, annualIncome, numberOfEmployees));
                }

            }

            Console.WriteLine("\n----------------------------------");

            Console.WriteLine("TAXES PAID:");
            double sumTax = 0.0;

            foreach (TaxPayer taxPayer in taxes)
            {
                sumTax += taxPayer.Tax();
                Console.WriteLine(taxPayer.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: $" + sumTax.ToString("F2", CultureInfo.InvariantCulture));
        }

    }
}
