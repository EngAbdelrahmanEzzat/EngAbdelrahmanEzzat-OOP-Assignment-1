using System;

namespace InvoiceDemo.Task3_3
{
    /// <summary>
    /// Immutable value object representing the order/payment side of an invoice.
    /// </summary>
    public sealed class OrderInfo
    {
        public DateTime OrderDate { get; }
        public string PaymentMethod { get; }
        public string Currency { get; }
        public decimal SubTotal { get; }
        public decimal DiscountAmount { get; }
        public decimal TaxAmount { get; }
        public decimal TotalAmount { get; }

        internal OrderInfo(DateTime orderDate, string paymentMethod, string currency,
                            decimal subTotal, decimal discountAmount, decimal taxAmount, decimal totalAmount)
        {
            OrderDate = orderDate;
            PaymentMethod = paymentMethod;
            Currency = currency;
            SubTotal = subTotal;
            DiscountAmount = discountAmount;
            TaxAmount = taxAmount;
            TotalAmount = totalAmount;
        }
    }
}