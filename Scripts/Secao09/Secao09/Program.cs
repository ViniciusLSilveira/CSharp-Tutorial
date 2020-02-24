using System;
using System.Globalization;
using Secao09.Entities;
using Secao09.Entities.Enums;

namespace Secao09
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDay = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = (OrderStatus)Enum.Parse(typeof(OrderStatus), Console.ReadLine());

            Client client = new Client(name, email, birthDay);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string prodName = Console.ReadLine();

                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(prodName, price);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem(quantity, price, product);

                order.AddItem(orderItem);
            }

            Console.WriteLine("\nORDER SUMMARY: ");
            Console.WriteLine(order.ToString());

        }
    }
}
