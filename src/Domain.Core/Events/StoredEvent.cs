using NetDevPack.Messaging;
using System;

namespace Domain.Core.Events
{
    public class StoredEvent : Event
    {
        //Contrutor parametrizado
        public StoredEvent(Event theEvent, string data, string user)
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = data;
            User = user;
        }

        //Construtor vazio para o EF
        protected StoredEvent() {}

        //Métodos 
        public Guid Id { get; private set; }

        public string Data { get; private set; }

        public string User { get; private set; }
    }
}
