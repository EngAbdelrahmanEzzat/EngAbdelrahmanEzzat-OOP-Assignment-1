using System;
using System.Collections.Generic;
using System.Text;
namespace Part1_ProceduralToOOP
{
    public class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer(
                1,
                "apod@example.com",
                "Cairo",
                "Apod",
                true);

            Customer customer2 = new Customer(
                2,
                "omar@example.com",
                "Alexandria",
                "Omar",
                false);

            Product pen = new Product(101, "Pen", 50, 100);
            Product pad = new Product(102, "Pad", 100, 50);

            Order order = new Order(
                customer1,
                DateOnly.FromDateTime(DateTime.Now));

            order.AddItem(pen, 2);
            order.AddItem(pad, 1);

            order.Pay();

            order.Print();

            Console.WriteLine($"Pen Stock: {pen.Stock}");
            Console.WriteLine($"Pad Stock: {pad.Stock}");
        }
    }
}

