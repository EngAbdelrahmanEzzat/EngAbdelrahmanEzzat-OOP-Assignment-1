using System;
using System.Collections.Generic;

namespace InvoiceDemo.Task3_3
{
    /// <summary>
    /// Owns ONE thing only: producing a valid OrderInfo (payment/money side).
    /// It knows nothing about addresses or customer identity.
    /// </summary>
    public sealed class OrderBuilder
    {
        private DateTime? _orderDate;
        private string _paymentMethod = null!;
        private string _currency = null!;
        private decimal? _subTotal;
        private decimal? _totalAmount;
        private decimal _discountAmount = 0m; // optional
        private decimal _taxAmount = 0m;       // optional

        public OrderBuilder WithOrderDate(DateTime orderDate) { _orderDate = orderDate; return this; }
        public OrderBuilder WithPaymentMethod(string paymentMethod) { _paymentMethod = paymentMethod; return this; }
        public OrderBuilder WithCurrency(string currency) { _currency = currency; return this; }
        public OrderBuilder WithSubTotal(decimal subTotal) { _subTotal = subTotal; return this; }
        public OrderBuilder WithTotalAmount(decimal totalAmount) { _totalAmount = totalAmount; return this; }
        public OrderBuilder WithDiscountAmount(decimal discountAmount) { _discountAmount = discountAmount; return this; }
        public OrderBuilder WithTaxAmount(decimal taxAmount) { _taxAmount = taxAmount; return this; }

        public OrderInfo Build()
        {
            var missing = new List<string>();
            if (_orderDate is null) missing.Add(nameof(_orderDate));
            if (string.IsNullOrWhiteSpace(_paymentMethod)) missing.Add(nameof(_paymentMethod));
            if (string.IsNullOrWhiteSpace(_currency)) missing.Add(nameof(_currency));
            if (_subTotal is null) missing.Add(nameof(_subTotal));
            if (_totalAmount is null) missing.Add(nameof(_totalAmount));

            if (missing.Count > 0)
            {
                throw new InvalidOperationException(
                    $"Cannot build OrderInfo, missing mandatory field(s): {string.Join(", ", missing)}");
            }

            return new OrderInfo(_orderDate.Value, _paymentMethod, _currency,
                                  _subTotal.Value, _discountAmount, _taxAmount, _totalAmount.Value);
        }
    }
}