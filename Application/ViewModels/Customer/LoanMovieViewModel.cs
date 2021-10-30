using Application.ViewModels.Movie;
using System.Collections.Generic;
using System.Linq;


namespace Application.ViewModels.Customer
{
    public class LoanMovieViewModel
    {
        public CustomerViewModel Customer { get; set; }
        public IEnumerable<MovieViewModel> Movies { get; set; } = Enumerable.Empty<MovieViewModel>();
    }
}
