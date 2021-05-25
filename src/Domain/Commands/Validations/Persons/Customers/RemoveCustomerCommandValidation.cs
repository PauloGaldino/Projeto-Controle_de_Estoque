using Domain.Commands.Persons.Customers;

namespace Domain.Commands.Validations.Persons.Customers
{
    public class RemoveCustomerCommandValidation : CustomerValidation<RemoveCustomerCommand>
    {
        public RemoveCustomerCommandValidation()
        {
            ValidateId();
        }
    }
}
