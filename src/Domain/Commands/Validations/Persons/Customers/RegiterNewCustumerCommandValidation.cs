using Domain.Commands.Persons.Customers;

namespace Domain.Commands.Validations.Persons.Customers
{
    public class RegiterNewCustumerCommandValidation : CustomerValidation<RegisterNewCustomerCommand>
    {
        public RegiterNewCustumerCommandValidation()
        {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}
