using Application.ViewModels.Customer;
using System.Collections.Generic;
using System.Linq;


namespace Application.ViewModels.Movie
{
    public class LoanCustomerViewModel
    {
        public MovieViewModel Movie { get; set; }
        public IEnumerable<CustomerViewModel> Customers { get; set; } = Enumerable.Empty<CustomerViewModel>();
    }
}
