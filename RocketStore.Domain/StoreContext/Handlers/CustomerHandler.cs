using System;
using FluentValidator;
using RocketStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using RocketStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using RocketStore.Domain.StoreContext.Entities;
using RocketStore.Domain.StoreContext.Repositories;
using RocketStore.Domain.StoreContext.Services;
using RocketStore.Domain.StoreContext.ValueObjects;
using RocketStore.Shared.Commands;

namespace RocketStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            if(_repository.CheckDocument(command.Document))
                AddNotification("Document", "This CPF is already in use");

            if(_repository.CheckEmail(command.Email))
                AddNotification("Email", "This E-mail is already in use");    

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            var customer = new Customer(name, document, email, command.Phone);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if(Invalid)
                return null;

            _repository.Save(customer);

            _emailService.Send(email.Address, "rsjlcarvalho@gmail.com", "Welcome", "Welcome to the Rocket Store!");

            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}