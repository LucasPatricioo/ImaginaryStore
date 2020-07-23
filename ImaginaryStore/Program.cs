using ImaginaryStore.Entities;
using ImaginaryStore.Entities.Enums;
using System;
using System.Globalization;

namespace ImaginaryStore
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
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);

            Console.WriteLine("\nEnter order data: ");
            Console.Write("Status: ");
            OrderStatus os = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order(DateTime.Now, os, client);

            Console.Write("How many items to this order? ");
            int n = Convert.ToInt32(Console.ReadLine());



            for (int i = 1; i <= n; i++) {
                Console.WriteLine("Enter #{0} item data:", i);
                Console.Write("Product name: ");
                string prodName = Console.ReadLine();
                Console.Write("Product price: ");
                double prodPrice = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int prodQuant = Convert.ToInt32(Console.ReadLine());

                Product prod = new Product(prodName, prodPrice);
                OrderItem orderItem = new OrderItem(prodQuant, prodPrice, prod);

                order.AddItem(orderItem);
            }

            Console.WriteLine("\nORDER SUMARY:");
            Console.WriteLine(order);

        }
    }
}
