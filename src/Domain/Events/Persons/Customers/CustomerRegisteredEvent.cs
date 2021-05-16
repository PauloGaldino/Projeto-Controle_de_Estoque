using NetDevPack.Messaging;
using System;

namespace Domain.Events.Persons.Customers
{
    public class CustomerRegisteredEvent : Event
    {
        //Construtor
        public CustomerRegisteredEvent(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        //Propriedades
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
