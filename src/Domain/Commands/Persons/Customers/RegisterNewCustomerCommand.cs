using Domain.Commands.Validations.Persons.Customers;
using System;

namespace Domain.Commands.Persons.Customers
{
    public class RegisterNewCustomerCommand : CustomerCommand
    {
        //Construtor
        public RegisterNewCustomerCommand(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        //Método
        public override bool IsValid()
        {
            ValidationResult = new RegiterNewCustumerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
