using System;
using System.Collections.Generic;

namespace InvoiceDemo.Task3_3
{
    /// <summary>
    /// Owns ONE thing only: producing a valid Address.
    /// It knows nothing about invoices, orders, or money - and it can
    /// guarantee a complete address entirely on its own.
    /// The SAME instance type is reused for both billing and shipping.
    /// </summary>
    public sealed class AddressBuilder
    {
        private string _street = null!;
        private string _city = null!;
        private string _zipCode = null!;
        private string _country = null!;
        private string _state = ""; // optional

        public AddressBuilder WithStreet(string street) { _street = street; return this; }
        public AddressBuilder WithCity(string city) { _city = city; return this; }
        public AddressBuilder WithZipCode(string zipCode) { _zipCode = zipCode; return this; }
        public AddressBuilder WithCountry(string country) { _country = country; return this; }
        public AddressBuilder WithState(string state) { _state = state; return this; }

        public Address Build()
        {
            var missing = new List<string>();
            if (string.IsNullOrWhiteSpace(_street)) missing.Add(nameof(_street));
            if (string.IsNullOrWhiteSpace(_city)) missing.Add(nameof(_city));
            if (string.IsNullOrWhiteSpace(_zipCode)) missing.Add(nameof(_zipCode));
            if (string.IsNullOrWhiteSpace(_country)) missing.Add(nameof(_country));

            if (missing.Count > 0)
            {
                throw new InvalidOperationException(
                    $"Cannot build Address, missing mandatory field(s): {string.Join(", ", missing)}");
            }

            return new Address(_street, _city, _state, _zipCode, _country);
        }
    }
}