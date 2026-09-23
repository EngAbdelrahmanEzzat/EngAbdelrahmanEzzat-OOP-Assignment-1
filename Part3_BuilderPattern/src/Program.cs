using System;
using T2 = InvoiceDemo.Task3_2;
using T3 = InvoiceDemo.Task3_3;

namespace InvoiceDemo
{
    public static class Program
    {
        public static void Main()
        {
            // ---------------------------------------------------------------
            // Task 3.2: single builder, still owns all ~20 flat fields.
            // ---------------------------------------------------------------
            var invoice32 = new T2.InvoiceBuilder()
                .WithInvoiceId("INV-1001")
                .WithCustomer("Ahmed Ali", "ahmed@example.com", "+20-100-000-0000")
                .WithBillingAddress("12 Tahrir St", "Cairo", "11511", "Egypt")
                .WithShippingAddress("5 Nile Corniche", "Giza", "12511", "Egypt")
                .WithOrderDate(DateTime.Today)
                .WithPaymentMethod("Visa")
                .WithCurrency("EGP")
                .WithAmounts(subTotal: 1000m, totalAmount: 1100m, taxAmount: 100m)
                .Build();

            Console.WriteLine($"[3.2] {invoice32.InvoiceId} total={invoice32.TotalAmount} {invoice32.Currency}");

            // ---------------------------------------------------------------
            // Task 3.3: composed builders - AddressBuilder reused twice, plus OrderBuilder.
            // ---------------------------------------------------------------
            var billing = new T3.AddressBuilder()
                .WithStreet("12 Tahrir St")
                .WithCity("Cairo")
                .WithZipCode("11511")
                .WithCountry("Egypt")
                .Build();

            var shipping = new T3.AddressBuilder()
                .WithStreet("5 Nile Corniche")
                .WithCity("Giza")
                .WithZipCode("12511")
                .WithCountry("Egypt")
                .Build();

            var order = new T3.OrderBuilder()
                .WithOrderDate(DateTime.Today)
                .WithPaymentMethod("Visa")
                .WithCurrency("EGP")
                .WithSubTotal(1000m)
                .WithTaxAmount(100m)
                .WithTotalAmount(1100m)
                .Build();

            var invoice33 = new T3.InvoiceBuilder()
                .WithInvoiceId("INV-1001")
                .WithCustomer("Ahmed Ali", "ahmed@example.com", "+20-100-000-0000")
                .WithBillingAddress(billing)
                .WithShippingAddress(shipping)
                .WithOrder(order)
                .Build();

            Console.WriteLine($"[3.3] {invoice33.InvoiceId} total={invoice33.Order.TotalAmount} {invoice33.Order.Currency}");

            // ---------------------------------------------------------------
            // Missing mandatory field -> immediate, clear error (not a silent bug).
            // ---------------------------------------------------------------
            try
            {
                new T3.AddressBuilder().WithStreet("Only street").Build();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Expected failure: {ex.Message}");
            }
        }
    }
}