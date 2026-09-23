using System;
using System.Collections.Generic;

namespace InvoiceDemo.Task3_2
{
    
    public sealed class InvoiceBuilder
    {
        // ---- mandatory fields (no default -> Build() must catch them missing) ----
        private string _invoiceId = null!;
        private string _customerName = null!;
        private string _customerEmail = null!;
        private string _billingStreet = null!;
        private string _billingCity = null!;
        private string _billingZipCode = null!;
        private string _billingCountry = null!;
        private string _shippingStreet = null!;
        private string _shippingCity = null!;
        private string _shippingZipCode = null!;
        private string _shippingCountry = null!;
        private DateTime? _orderDate;
        private string _paymentMethod = null!;
        private string _currency = null!;
        private decimal? _subTotal;
        private decimal? _totalAmount;

        // ---- optional fields (safe defaults) ----
        private string _customerPhone = "";
        private string _billingState = "";
        private string _shippingState = "";
        private decimal _discountAmount = 0m;
        private decimal _taxAmount = 0m;

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

        public InvoiceBuilder WithBillingAddress(string street, string city, string zipCode, string country, string state = "")
        {
            _billingStreet = street;
            _billingCity = city;
            _billingZipCode = zipCode;
            _billingCountry = country;
            _billingState = state;
            return this;
        }

        public InvoiceBuilder WithShippingAddress(string street, string city, string zipCode, string country, string state = "")
        {
            _shippingStreet = street;
            _shippingCity = city;
            _shippingZipCode = zipCode;
            _shippingCountry = country;
            _shippingState = state;
            return this;
        }

        public InvoiceBuilder WithOrderDate(DateTime orderDate)
        {
            _orderDate = orderDate;
            return this;
        }

        public InvoiceBuilder WithPaymentMethod(string paymentMethod)
        {
            _paymentMethod = paymentMethod;
            return this;
        }

        public InvoiceBuilder WithCurrency(string currency)
        {
            _currency = currency;
            return this;
        }

        public InvoiceBuilder WithAmounts(decimal subTotal, decimal totalAmount, decimal discountAmount = 0m, decimal taxAmount = 0m)
        {
            _subTotal = subTotal;
            _totalAmount = totalAmount;
            _discountAmount = discountAmount;
            _taxAmount = taxAmount;
            return this;
        }

        public Invoice Build()
        {
            // Fail fast: the caller gets one clear, immediate exception instead
            // of a silently-broken Invoice with nulls/zeros discovered later.
            var missing = new List<string>();
            if (string.IsNullOrWhiteSpace(_invoiceId)) missing.Add(nameof(_invoiceId));
            if (string.IsNullOrWhiteSpace(_customerName)) missing.Add(nameof(_customerName));
            if (string.IsNullOrWhiteSpace(_customerEmail)) missing.Add(nameof(_customerEmail));
            if (string.IsNullOrWhiteSpace(_billingStreet)) missing.Add(nameof(_billingStreet));
            if (string.IsNullOrWhiteSpace(_billingCity)) missing.Add(nameof(_billingCity));
            if (string.IsNullOrWhiteSpace(_billingZipCode)) missing.Add(nameof(_billingZipCode));
            if (string.IsNullOrWhiteSpace(_billingCountry)) missing.Add(nameof(_billingCountry));
            if (string.IsNullOrWhiteSpace(_shippingStreet)) missing.Add(nameof(_shippingStreet));
            if (string.IsNullOrWhiteSpace(_shippingCity)) missing.Add(nameof(_shippingCity));
            if (string.IsNullOrWhiteSpace(_shippingZipCode)) missing.Add(nameof(_shippingZipCode));
            if (string.IsNullOrWhiteSpace(_shippingCountry)) missing.Add(nameof(_shippingCountry));
            if (_orderDate is null) missing.Add(nameof(_orderDate));
            if (string.IsNullOrWhiteSpace(_paymentMethod)) missing.Add(nameof(_paymentMethod));
            if (string.IsNullOrWhiteSpace(_currency)) missing.Add(nameof(_currency));
            if (_subTotal is null) missing.Add(nameof(_subTotal));
            if (_totalAmount is null) missing.Add(nameof(_totalAmount));

            if (missing.Count > 0)
            {
                throw new InvalidOperationException(
                    $"Cannot build Invoice, missing mandatory field(s): {string.Join(", ", missing)}");
            }

            return new Invoice(
                _invoiceId, _customerName, _customerEmail, _customerPhone,
                _billingStreet, _billingCity, _billingState, _billingZipCode, _billingCountry,
                _shippingStreet, _shippingCity, _shippingState, _shippingZipCode, _shippingCountry,
                _orderDate.Value, _paymentMethod, _currency,
                _subTotal.Value, _discountAmount, _taxAmount, _totalAmount.Value);
        }
    }
}