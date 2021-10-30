using Application.ViewModels.Customer;
using Application.ViewModels.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovieService
    {
        MovieListViewModel GetMovies();
        MovieViewModel GetMovieById(Guid id);
        MovieViewModel AddMovie(MovieViewModel movieRequest);
        void EditMovie(MovieViewModel movieRequest);
        void Delete(Guid id);

        MovieListViewModel FullTextSearch(string searchTerm);

        LoanCustomerViewModel GetMovieWithCustomers(Guid id);
     
    }
}
