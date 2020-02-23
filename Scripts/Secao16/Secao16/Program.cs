using System;
using System.IO;
using System.Linq;
using Secao16.Entities;
using System.Globalization;
using System.Collections.Generic;

namespace Secao16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            Console.Write("Enter Salary: ");
            double limit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
            List<Employee> employees = new List<Employee>();
            
            try
            {

                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(',');
                        string name = fields[0];
                        string email = fields[1];
                        double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                        employees.Add(new Employee(name, email, salary));
                    }
                }
                
                var emails = employees.Where(e => e.Salary >= limit).OrderBy(e => e.Name).Select(e => e.Email);

                var sum = employees.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);

                Console.WriteLine($"\nE-mail of people whose salary is more than ${limit}:");
                foreach (var email in emails)
                {
                    Console.WriteLine(email);
                }

                Console.WriteLine($"\nSum of salary of people whose name starts with 'M': ${sum.ToString("F2", CultureInfo.InvariantCulture)}");
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occured");
                Console.WriteLine(e.Message);
            }
        }
    }
}
