using Application.Interfaces;
using Application.ViewModels.Customer;
using Application.ViewModels.Movie;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMovieRepository movieRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _movieRepository = movieRepository;
            _mapper = mapper;

        }
        public CustomerViewModel AddCustomer(CustomerViewModel customerRequest)
        {
            var customer = _mapper.Map<Customer>(customerRequest);
            var addedCustomer = _customerRepository.Add(customer);

            return _mapper.Map<CustomerViewModel>(addedCustomer);
        }
        public void EditCustomer(CustomerViewModel customerRequest)
        {
            var customer = _mapper.Map<Customer>(customerRequest);
            _customerRepository.Update(customer);
        }
        public CustomerListViewModel FullTextSearch(string searchTerm)
        {
            var customersVm = new List<CustomerViewModel>();

            var customers = string.IsNullOrEmpty(searchTerm) ? _customerRepository.GetAll() : _customerRepository.FullTextSearch(searchTerm);

            if (customers != null && customers.Any())
            {
                customersVm = _mapper.Map<List<CustomerViewModel>>(customers);
            }

            return new CustomerListViewModel()
            {
                Customers = customersVm
            };
        }
        public CustomerViewModel GetCustomerById(Guid id)
        {
            var customerVm = _mapper.Map<CustomerViewModel>(_customerRepository.GetById(id));

            return customerVm;
        }
        public CustomerListViewModel GetCustomers()
        {
            var customers = _customerRepository.GetAll();
            var customersViewModel = _mapper.Map<IEnumerable<CustomerViewModel>>(customers);

            return new CustomerListViewModel()
            {
                Customers = customersViewModel
            };
        }
        public LoanMovieViewModel GetCustomerWithLoanMovies(Guid id)
        {
            var customer = _customerRepository.GetCustomerWithLoanMovies(id);

            var customerVm = _mapper.Map<CustomerViewModel>(customer);
            var moviesVm = _mapper.Map<IEnumerable<MovieViewModel>>(customer.LoanedMovies);

            var loanMovieViewModel = new LoanMovieViewModel();
            loanMovieViewModel.Customer = customerVm;
            loanMovieViewModel.Movies = moviesVm;

            return loanMovieViewModel;
        }
        public void LoanMovie(Guid customerId, Guid movieId)
        {
            var movie = _movieRepository.GetById(movieId);

            if (movie.InStock == 0)
            {
                throw new Exception($"There is no stock of this book {movie.Title}");
            }

            var customer = _customerRepository.GetById(customerId);

            customer.LoanedMovies = new List<Movie>();
            customer.LoanedMovies.Add(movie);

            --movie.InStock;
            _movieRepository.Update(movie);
        }
        public void ReturnMovie(Guid customerId, Guid movieId)
        {
            var movie = _movieRepository.GetById(movieId);

            var customer = _customerRepository.GetCustomerWithLoanMovies(customerId);

            customer.LoanedMovies.Remove(movie);

            ++movie.InStock;
            _movieRepository.Update(movie);
        }
    }
}
