// Program.cs
using System;
using OnlineOrdering;

namespace ProductOrderingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create addresses
            Address usaAddress = new Address("123 Main St", "New York", "NY", "USA");
            Address canadaAddress = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

            // Create customers
            Customer customer1 = new Customer("John Smith", usaAddress);
            Customer customer2 = new Customer("Emma Johnson", canadaAddress);

            // Create products
            Product product1 = new Product("Laptop", "P100", 999.99m, 1);
            Product product2 = new Product("Mouse", "P101", 19.99m, 2);
            Product product3 = new Product("Keyboard", "P102", 49.99m, 1);
            Product product4 = new Product("Monitor", "P103", 199.99m, 2);

            // Create orders
            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);

            Order order2 = new Order(customer2);
            order2.AddProduct(product3);
            order2.AddProduct(product4);
            order2.AddProduct(product2);

            // Display order information
            DisplayOrderDetails(order1);
            DisplayOrderDetails(order2);
        }

        static void DisplayOrderDetails(Order order)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.CalculateTotalCost():0.00}");
            Console.WriteLine("\n========================================\n");
        }
    }
}
