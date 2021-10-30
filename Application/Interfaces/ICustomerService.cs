using Application.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICustomerService
    {
        CustomerListViewModel GetCustomers();
        CustomerViewModel GetCustomerById(Guid id);
        CustomerViewModel AddCustomer(CustomerViewModel customerRequest);
        void EditCustomer(CustomerViewModel customerRequest);
        LoanMovieViewModel GetCustomerWithLoanMovies(Guid id);
        void LoanMovie(Guid customerId, Guid movieId);
        void ReturnMovie(Guid customerId, Guid movieId);
        CustomerListViewModel FullTextSearch(string searchTerm);

    }
}
