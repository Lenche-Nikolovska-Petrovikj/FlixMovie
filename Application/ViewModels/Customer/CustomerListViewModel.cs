using System.Collections.Generic;


namespace Application.ViewModels.Customer
{
    public class CustomerListViewModel
    {
        public IEnumerable<CustomerViewModel> Customers { get; set; }
    }
}
