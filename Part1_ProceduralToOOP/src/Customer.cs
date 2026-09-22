using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{

    public class Customer
    {

        public int Id { get; }
        public string Email { get; private set; }

        public string City { get; set; }

        public string Name { get; private set; }

        public bool IsVip { get; private set; }

        public Customer(int id, string email, string city, string name, bool isVip)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("id must be greater than zero");
            if (string.IsNullOrWhiteSpace(email))
                throw new NullReferenceException("email cannot be empt");
            if (string.IsNullOrWhiteSpace(name))
                throw new NullReferenceException("name cannot be empt");
            if (string.IsNullOrWhiteSpace(city))
                throw new NullReferenceException("city cannot be empty");
            Id = id;
            Email = email;
            City = city;
            Name = name;
            IsVip = isVip;
        }




    }

}