using System.Collections.Generic;


namespace Application.ViewModels.Movie
{
    public class MovieListViewModel
    {
        public IEnumerable<MovieViewModel> Movies { get; set; }
        public int Total;
    }
}
