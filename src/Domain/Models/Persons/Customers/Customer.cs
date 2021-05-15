using System;
using NetDevPack.Domain;

namespace Domain.Models.Persons.Customers
{
    public class Customer : Entity, IAggregateRoot
    {
        //COnstrutor parametrizado
        public Customer(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        //Construtor vazio para o Ef
        protected Customer(){}

        //Propriedades
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}
