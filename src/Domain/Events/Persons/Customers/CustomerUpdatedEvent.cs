using NetDevPack.Messaging;
using System;

namespace Domain.Events.Persons.Customers
{

    public class CustomerUpdatedEvent : Event
    {
        //Construtor parametrizado
        public CustomerUpdatedEvent(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            AggregateId = id;
        }

        //Proriedades
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}
