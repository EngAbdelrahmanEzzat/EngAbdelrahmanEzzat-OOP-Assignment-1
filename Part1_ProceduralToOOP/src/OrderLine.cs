using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class OrderLine
    {

        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        public double Line => Quantity * Product.Price;

        public OrderLine(Product product, int quantity)
        {
            if (product is null)
                throw new NullReferenceException("The product is null");
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException("The quantity must be greater thene zero");

            Product = product;
            Quantity = quantity;
        }




    }
}
