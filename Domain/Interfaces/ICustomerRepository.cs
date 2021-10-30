using Domain.Interfaces.Base;
using Domain.Models;
using System;
using System.Collections.Generic;


namespace Domain.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Customer GetCustomerWithLoanMovies(Guid id);
        IEnumerable<Customer> FullTextSearch(string searchTerm);
    }
}
