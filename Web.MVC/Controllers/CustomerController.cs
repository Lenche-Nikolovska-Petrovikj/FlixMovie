using Application.Interfaces;
using Application.ViewModels.Customer;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Web.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            var model = _customerService.GetCustomers();
            return View(model);
        }

        public IActionResult AddOrEdit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return View();
            }

            var readerViewModel = _customerService.GetCustomerById(id);
            return View(readerViewModel);
        }
        [HttpPost]
        public IActionResult AddOrEdit(CustomerViewModel customerViewModel)
        {
            if (customerViewModel.Id == Guid.Empty)
            {
                _customerService.AddCustomer(customerViewModel);
            }
            else
            {
                _customerService.EditCustomer(customerViewModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult LoanMovie(Guid id)
        {
            LoanMovieViewModel model = _customerService.GetCustomerWithLoanMovies(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult LoanMovie(Guid readerId, Guid bookId)
        {
            _customerService.LoanMovie(readerId, bookId);

            var model = _customerService.GetCustomerWithLoanMovies(readerId);

            return View(model);

        }

        public IActionResult ReturnMovie(Guid customerId, Guid movieId)
        {
            _customerService.ReturnMovie(customerId, movieId);

            return RedirectToAction("LoanMovie", new { id = customerId });
        }

        public IActionResult SearchByFullName(string searchTerm)
        {
            var model = _customerService.FullTextSearch(searchTerm);

            return Json(model.Customers);
        }
    }
}
