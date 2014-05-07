﻿using Argentum.Core;
using SilverScreen.Domain;

namespace SilverScreen.Application.Customers
{
    public class CreateCustomer : ICommand
    {
        public string Name { get; set; }
        public string Adress { get; set; }

        public CreateCustomer(string name, string adress)
        {
            Name = name;
            Adress = adress;
        }
    }

    public class CreateCustomerHandler : IHandleCommand<CreateCustomer>
    {
        public void HandleCommand(CreateCustomer command)
        {
            Customer.Create(command.Name, command.Adress);
        }
    }

    public class CustomerCreatedHandler : IHandleEvent<CustomerCreated>
    {
        public void HandleEvent(CustomerCreated evt)
        {
            
        }
    }
}