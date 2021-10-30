using Application.Interfaces;
using Application.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;


namespace Web.MVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICustomerService _customerService;

      

        public MovieController(IMovieService movieService, ICustomerService customerService)
        {
            _movieService = movieService;
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            var movieListViewModel = _movieService.GetMovies();

            return View(movieListViewModel);
        }

        public IActionResult AddOrEdit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return View();
            }

            var editViewMovieModel = _movieService.GetMovieById(id);
            return View(editViewMovieModel);
        }

        [HttpPost]
        public IActionResult AddOrEdit(MovieViewModel movieViewModel)
        {
            if (movieViewModel.Id == Guid.Empty)
            {
                _movieService.AddMovie(movieViewModel);
            }
            else
            {
                _movieService.EditMovie(movieViewModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult SearchByFullName(string searchTerm)
        {
            var model = _movieService.FullTextSearch(searchTerm);

            return Json(model.Movies);
        }

        public IActionResult Loan(Guid id)
        {

            LoanCustomerViewModel model = _movieService.GetMovieWithCustomers(id);

            return View("LoanCustomer", model);
        }

        [HttpPost]
        public IActionResult Loan(Guid customerId, Guid movieId)
        {
            _customerService.LoanMovie(customerId, movieId);

            LoanCustomerViewModel model = _movieService.GetMovieWithCustomers(movieId);

            return View("LoanCustomer", model);

        }

        public IActionResult Return(Guid customerId, Guid movieId)
        {
            _customerService.ReturnMovie(customerId, movieId);

            return RedirectToAction("Loan", new { id = movieId });
        }

        [HttpGet("Movie/getAllMovies")]
        public IActionResult GetAll()
        {
            var moviesListModel = _movieService.GetMovies();
            if (moviesListModel != null)
            {
                string json = JsonConvert.SerializeObject(
                       moviesListModel,
                       Formatting.None,
                       new JsonSerializerSettings()
                       {
                           ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                           NullValueHandling = NullValueHandling.Ignore
                       });
                return Ok(json);
            }
            return NotFound();
        }
    }
}
