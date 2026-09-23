using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class Order
    {
        public Guid Id { get; }
        public DateOnly OrderDate { get; init; }
        public bool IsPaid { get; private set; }

        public Customer Customer { get; }

        private List<OrderLine> _orderLines = [];

        public Order(Customer customer, DateOnly orderDate)
        {
            ArgumentNullException.ThrowIfNull(customer);

            Id = Guid.NewGuid();
            Customer = customer;
            OrderDate = orderDate;
        }

        public void AddItem(Product product, int quantity)
        {
            ArgumentNullException.ThrowIfNull(product);

            if (quantity <= 0)
                throw new ArgumentOutOfRangeException("Quantity must be greater than zero.");

            if (quantity > product.Stock)
                throw new ArgumentOutOfRangeException("Quantity cannot be greater than stock.");

            var orderLine = new OrderLine(product, quantity);
            _orderLines.Add(orderLine);

            product.ReduceStock(quantity);
        }

        public double CalculateTotal()
        {
            double total = 0;

            foreach (var orderLine in _orderLines)
            {
                total += orderLine.Line;
            }

            if (Customer.IsVip)
                total *= 0.90;

            return total;
        }

        public void Pay()
        {
            if (_orderLines.Count == 0)
                throw new InvalidOperationException("Cannot pay for an empty order.");

            IsPaid = true;
        }
        public void Print()
        {
            Console.WriteLine("\n========== ORDER ==========");
            Console.WriteLine($"Order ID : {Id}");
            Console.WriteLine($"Date     : {OrderDate}");
            Console.WriteLine($"Customer : {Customer.Name}");
            Console.WriteLine($"Email    : {Customer.Email}");
            Console.WriteLine($"VIP      : {(Customer.IsVip ? "Yes" : "No")}");
            Console.WriteLine($"Paid     : {(IsPaid ? "Yes" : "No")}");

            Console.WriteLine("\n---------- ITEMS ----------");

            foreach (var orderLine in _orderLines)
            {
                Console.WriteLine(
                    $"{orderLine.Product.Name,-20} " +
                    $"x {orderLine.Quantity,-3} " +
                    $"@ {orderLine.Product.Price,8:F2} " +
                    $"= {orderLine.Line,8:F2}");
            }

            Console.WriteLine("---------------------------");
            Console.WriteLine($"TOTAL    : {CalculateTotal(),8:F2}");
            Console.WriteLine("===========================\n");
        }
    }
}
