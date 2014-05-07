using System;
using Argentum.Core;

namespace SilverScreen.Domain
{
    public class Customer : AggregateBase<CustomerState>
    {
        public Customer(CustomerState state) : base(state) { }

        private Customer(Guid id, string name, string adress)
        {
            Apply(new CustomerCreated(id, name, adress));
        }

        public static Customer Create(string name, string adress)
        {
            return new Customer(Guid.NewGuid(), name, adress);
        }
        
        public void ChangeName(string name)
        {
            Apply(new CustomerNameChanged(name));
        }

        public void Relocated(string adress)
        {
            Apply(new CustomerRelocated(adress));
        }
    }

    public class CustomerRelocated : IEvent
    {
        public string Adress { get; private set; }

        public CustomerRelocated(string adress)
        {
            Adress = adress;
        }
    }

    public class CustomerNameChanged : IEvent
    {
        public string Name { get; private set; }

        public CustomerNameChanged(string name)
        {
            Name = name;
        }
    }

    public class CustomerCreated : IEvent
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Adress { get; private set; }

        public CustomerCreated(Guid id, string name, string adress)
        {
            Id = id;
            Name = name;
            Adress = adress;
        }
    }

    public class CustomerState : State
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public void When(CustomerCreated evt)
        {
            Name = evt.Name;
            Address = evt.Adress;
        }

        public void When(CustomerNameChanged evt)
        {
            Name = evt.Name;
        }

        public void When(CustomerRelocated evt)
        {
            Address = evt.Adress;
        }
    }
}