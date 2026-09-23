namespace InvoiceDemo.Task3_3
{
    /// <summary>
    /// Immutable value object representing a physical address.
    /// The SAME class is reused for both Billing and Shipping addresses -
    /// which is exactly why it deserves its own type instead of being
    /// 5 loose fields duplicated with "Billing"/"Shipping" prefixes.
    /// </summary>
    public sealed class Address
    {
        public string Street { get; }
        public string City { get; }
        public string State { get; }      // optional: not every country has "states"
        public string ZipCode { get; }
        public string Country { get; }

        internal Address(string street, string city, string state, string zipCode, string country)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
        }

        public override string ToString() =>
            $"{Street}, {City}{(string.IsNullOrEmpty(State) ? "" : ", " + State)} {ZipCode}, {Country}";
    }
}