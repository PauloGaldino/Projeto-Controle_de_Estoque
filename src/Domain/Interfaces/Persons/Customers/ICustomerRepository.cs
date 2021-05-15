using Domain.Models.Persons.Customers;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persons.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        //Métodos custumizados
        Task<Customer> GetById(Guid id);
        Task<Customer> GetByEmail(string email);
        Task<IEnumerable<Customer>> GetAll();

        //Métodos CRUD
        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
    }
}
