using InvoiceDemo.Task3_2;
using System;
using System.Collections.Generic;

namespace InvoiceDemo.Task3_3
{
    /// <summary>
    /// TASK 3.3: the composed builder. It no longer knows anything about
    /// street/city/zip rules or subtotal/tax rules - it only composes an
    /// already-validated BillingAddress, ShippingAddress and OrderInfo
    /// together with the customer identity fields.
    /// </summary>
    public sealed class InvoiceBuilder
    {
        private string _invoiceId=null!;
        private string _customerName=null!;
        private string _customerEmail=null!;
        private string _customerPhone = ""; // optional

        private Address _billingAddress;
        private Address _shippingAddress;
        private OrderInfo _order;

        public InvoiceBuilder WithInvoiceId(string invoiceId)
        {
            _invoiceId = invoiceId;
            return this;
        }

        public InvoiceBuilder WithCustomer(string name, string email, string phone = "")
        {
            _customerName = name;
            _customerEmail = email;
            _customerPhone = phone;
            return this;
        }

        // Each address arrives pre-built and pre-validated by its own AddressBuilder.
        public InvoiceBuilder WithBillingAddress(Address billingAddress)
        {
            _billingAddress = billingAddress;
            return this;
        }

        public InvoiceBuilder WithShippingAddress(Address shippingAddress)
        {
            _shippingAddress = shippingAddress;
            return this;
        }

        // The order arrives pre-built and pre-validated by OrderBuilder.
        public InvoiceBuilder WithOrder(OrderInfo order)
        {
            _order = order;
            return this;
        }

        public Invoice Build()
        {
            var missing = new List<string>();
            if (string.IsNullOrWhiteSpace(_invoiceId)) missing.Add(nameof(_invoiceId));
            if (string.IsNullOrWhiteSpace(_customerName)) missing.Add(nameof(_customerName));
            if (string.IsNullOrWhiteSpace(_customerEmail)) missing.Add(nameof(_customerEmail));
            if (_billingAddress is null) missing.Add(nameof(_billingAddress));
            if (_shippingAddress is null) missing.Add(nameof(_shippingAddress));
            if (_order is null) missing.Add(nameof(_order));

            if (missing.Count > 0)
            {
                throw new InvalidOperationException(
                    $"Cannot build Invoice, missing mandatory field(s): {string.Join(", ", missing)}");
            }

            return new Invoice(_invoiceId, _customerName, _customerEmail, _customerPhone,
                                _billingAddress, _shippingAddress, _order);
        }
    }
}