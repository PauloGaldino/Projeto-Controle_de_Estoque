using NetDevPack.Messaging;
using System;

namespace Domain.Events.Persons.Customers
{
    public class CustomerRemovedEvent : Event
    {
        //Construtor
        public CustomerRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        //Propriedades
        public Guid Id { get; set; }
    }
}
