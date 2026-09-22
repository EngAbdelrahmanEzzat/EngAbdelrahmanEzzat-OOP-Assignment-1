namespace Part1_ProceduralToOOP;
    public class Program
     {
    static void Main(string[] args)
    {
        // Customers
        Customer customer1 = new Customer(
            1,
            "Cairo",
            "apod@example.com",
            "Apod",
            true);

        Customer customer2 = new Customer(
            2,
            "Alexandria",
            "omar@example.com",
            "Omar",
            false);

        // Products
        Product pen = new Product(101, "Pen", 50, 100);
        Product pad = new Product(102, "Pad", 100, 50);

        // Create Order
        Order order = new Order(customer1, DateOnly.FromDateTime(DateTime.Now));

        // Add items
        order.AddItem(pen, 2);
        order.AddItem(pad, 1);

        // Pay
        order.Pay();

        // Print
        order.Print();

        Console.WriteLine($"Pen Stock: {pen.Stock}");
        Console.WriteLine($"Pad Stock: {pad.Stock}");
    }
}











