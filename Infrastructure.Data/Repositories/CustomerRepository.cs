using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {

        private readonly FlixmovieDbContext _dbContext;
        public CustomerRepository(FlixmovieDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Customer> FullTextSearch(string searchTerm)
        {
            return _dbContext.Customers.AsEnumerable().Where(b => b.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
               || b.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
               || b.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        public Customer GetCustomerWithLoanMovies(Guid id)
        {
            var customer = _dbContext.Customers.Include(x => x.LoanedMovies).First(customer => customer.Id == id);
            return customer;
        }
    }
}
