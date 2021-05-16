﻿using Domain.Events.Persons.Customers;
using Domain.Interfaces.Persons.Customers;
using Domain.Models.Persons.Customers;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Persons.Customers
{
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCustomerCommand, ValidationResult>,
        IRequestHandler<UpdateCustomerCommand, ValidationResult>,
        IRequestHandler<RemoveCustomerCommand, ValidationResult>
    {
        //Injeção de dependencia
        private readonly ICustomerRepository _customerRepository;

        //Construtor parametrizado
        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //Métodos 
        public async Task<ValidationResult> Handle(RegisterNewCustomerCommand message, CancellationToken cancellationToken)
        {

            if (!message.IsValid()) return message.ValidationResult;

            var customer = new Customer(Guid.NewGuid(), message.Name, message.Email, message.BirthDate);


            if (await _customerRepository.GetByEmail(customer.Email) != null)
            {
                AddError("The customer e-mail has already been taken.");
                return ValidationResult;
            }

            customer.AddDomainEvent(new CustomerRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));

            _customerRepository.Add(customer);

            return await Commit(_customerRepository.UnitOfWork);

        }

        public async Task<ValidationResult> Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
        {

            if (!message.IsValid()) return message.ValidationResult;

            var customer = new Customer(message.Id, message.Name, message.Email, message.BirthDate);
            var existingCustomer = await _customerRepository.GetByEmail(customer.Email);

            if (existingCustomer != null && existingCustomer.Id != customer.Id)
            {
                if (!existingCustomer.Equals(customer))
                {
                    AddError("The customer e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            customer.AddDomainEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));

            _customerRepository.Update(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveCustomerCommand message, CancellationToken cancellationToken)
        {

            if (!message.IsValid()) return message.ValidationResult;

            var customer = await _customerRepository.GetById(message.Id);

            if (customer is null)
            {
                AddError("The customer doesn't exists.");
                return ValidationResult;
            }

            customer.AddDomainEvent(new CustomerRemovedEvent(message.Id));

            _customerRepository.Remove(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}
