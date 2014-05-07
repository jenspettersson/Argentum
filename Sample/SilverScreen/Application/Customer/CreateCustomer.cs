using Argentum.Core;
using SilverScreen.Domain;
using SilverScreen.Infrastructure;

namespace SilverScreen.Application.Customer
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
        private readonly IDomainRepository _repository;

        public CreateCustomerHandler(IDomainRepository repository)
        {
            _repository = repository;
        }

        public void HandleCommand(CreateCustomer command)
        {
            var customer = Domain.Customer.Create(command.Name, command.Adress);

            _repository.Save(customer);
        }
    }

    public class CustomerCreatedHandler : IHandleEvent<CustomerCreated>
    {
        public void HandleEvent(CustomerCreated evt)
        {
            
        }
    }
}