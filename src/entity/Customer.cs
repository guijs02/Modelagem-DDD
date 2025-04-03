using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.entity
{
    public class Customer
    {

        public Customer(int id, string name, string age, Address address)
        {
            Id = id;
            Name = name;
            Age = age;
            Address = address;

            Validate();
        }

        public int Id { get;  private set; }
        public string Name { get; private set; }
        public string Age { get;  private set; }
        public Address Address { get; private set; }

        public void UpdateName(string name)
        {
            Name = name;
        }
        public void UpdateAge(string age)
        {
            Age = age;
        }

        public void Validate()
        {
            if (Id == 0)
                throw new Exception("Id is required.");

            if (string.IsNullOrEmpty(Name))
                throw new Exception("Name is required.");

            if (string.IsNullOrEmpty(Age))
                throw new Exception("Age is required.");
            
            if(Address == null)
                throw new Exception("Address is required.");
        }
    }
    public class Address
    {
        public Address(string street, string city, string state, string zipCode)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;

            Validate();
        }

        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            var address = obj as Address;

            return Street == address.Street &&
                   City == address.City &&
                   State == address.State &&
                   ZipCode == address.ZipCode;
        }
        public void Validate()
        {
            if (string.IsNullOrEmpty(Street))
                throw new Exception("Street is required.");

            if (string.IsNullOrEmpty(City))
                throw new Exception("City is required.");

            if (string.IsNullOrEmpty(State))
                throw new Exception("State is required.");

            if (string.IsNullOrEmpty(ZipCode))
                throw new Exception("ZipCode is required.");
        }
        
        public override string ToString()
        {
            return $"{Street}, {City}, {State}, {ZipCode}";
        }
    }
}