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
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository,IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public MovieViewModel AddMovie(MovieViewModel movieRequest)
        {
            var movie = _mapper.Map<Movie>(movieRequest);
            var addedMovie = _movieRepository.Add(movie);

            return _mapper.Map<MovieViewModel>(addedMovie);
        }

        public void Delete(Guid id)
        {
            var movie = _mapper.Map<Movie>(_movieRepository.GetById(id));
            _movieRepository.Delete(movie);
        }

        public void EditMovie(MovieViewModel movieRequest)
        {
            var movie = _mapper.Map<Movie>(movieRequest);
            _movieRepository.Update(movie);
        }

        public MovieListViewModel FullTextSearch(string searchTerm)
        {
            var moviesVm = new List<MovieViewModel>();

            var movies = string.IsNullOrEmpty(searchTerm) ? _movieRepository.GetAll() : _movieRepository.FullTextSearch(searchTerm);

            if (movies != null && movies.Any())
            {
                moviesVm = _mapper.Map<List<MovieViewModel>>(movies);
            }

            return new MovieListViewModel()
            {
                Movies = moviesVm
            };
        }

        public MovieViewModel GetMovieById(Guid id)
        {
            var movieVm = _mapper.Map<MovieViewModel>(_movieRepository.GetById(id));

            return movieVm;
        }

        public MovieListViewModel GetMovies()
        {
            var movies = _movieRepository.GetAll();
            var moviesViewModel = _mapper.Map<IEnumerable<MovieViewModel>>(movies);

            return new MovieListViewModel()
            {
                Movies = moviesViewModel,
                Total = moviesViewModel.ToList().Count
            };
        }

        public LoanCustomerViewModel GetMovieWithCustomers(Guid id)
        {
            var movie = _movieRepository.GetMovieWithCustomers(id);

            var movieVm = _mapper.Map<MovieViewModel>(movie);
            var customersVm = _mapper.Map<IEnumerable<CustomerViewModel>>(movie.Customers);

            var loanMovieViewModel = new LoanCustomerViewModel();
            loanMovieViewModel.Customers = customersVm;
            loanMovieViewModel.Movie = movieVm;

            return loanMovieViewModel;
        }
    }
}
