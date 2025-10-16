// Translated from CalisthenicsExamples/only-one-dot-per-line.ts
// Demonstrates dot chaining and convenience forwarding methods
using System;

namespace CalisthenicsExamples
{
    public class Address
    {
        private string city;
        public Address(string city)
        {
            this.city = city;
        }
        public string GetCity()
        {
            return this.city;
        }
    }

    public class Customer
    {
        private Address address;
        public Customer(Address address)
        {
            this.address = address;
        }
        public Address GetAddress()
        {
            return this.address;
        }
        public string GetCity()
        {
            return this.address.GetCity();
        }
    }

    public class Order
    {
        private Customer customer;
        public Order(Customer customer)
        {
            this.customer = customer;
        }
        public Customer GetCustomer()
        {
            return this.customer;
        }
        public string GetCity()
        {
            return this.customer.GetCity();
        }
    }
}
