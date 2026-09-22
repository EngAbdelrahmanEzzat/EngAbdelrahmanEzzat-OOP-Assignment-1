using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class Product
    {

        public int Id { get; }
        public string Name { get; private set; }

        public double Price { get; private set; }

        public int Stock { get; private set; }
        public Product(int id, string name, double price, int stock)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("id must be greater than zero");
            if (string.IsNullOrWhiteSpace(name))
                throw new NullReferenceException("name cannot be empt");
            if (price <= 0)
                throw new ArgumentOutOfRangeException("price must be greater than zero");
            if (stock <= 0)
                throw new ArgumentOutOfRangeException("stock must be greater than zero");

            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }
        public void ReduceStock(int quantity)
        {
            if (quantity > Stock)
                throw new InvalidOperationException("Not enough stock.");

            Stock -= quantity;
        }


    }
}
