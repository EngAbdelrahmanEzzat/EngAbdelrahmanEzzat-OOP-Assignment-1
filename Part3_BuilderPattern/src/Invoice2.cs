namespace InvoiceDemo.Task3_3
{
    /// <summary>
    /// The aggregate root now owns 4 identity/contact fields + 2 Address objects
    /// + 1 OrderInfo object - instead of ~20 flat scalar properties.
    /// It does not know street/zip rules or tax/payment rules; those belong
    /// to Address and OrderInfo respectively.
    /// </summary>
    public sealed class Invoice
    {
        public string InvoiceId { get; }
        public string CustomerName { get; }
        public string CustomerEmail { get; }
        public string CustomerPhone { get; }
        public Address BillingAddress { get; }
        public Address ShippingAddress { get; }
        public OrderInfo Order { get; }

        internal Invoice(string invoiceId, string customerName, string customerEmail, string customerPhone,
                          Address billingAddress, Address shippingAddress, OrderInfo order)
        {
            InvoiceId = invoiceId;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerPhone = customerPhone;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
            Order = order;
        }
    }
}