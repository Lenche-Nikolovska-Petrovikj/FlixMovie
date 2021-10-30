using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private readonly DbSet<Movie> _movies;
        public MovieRepository(FlixmovieDbContext dbContext) : base(dbContext)
        {
            _movies = dbContext.Set<Movie>();
        }

        public IEnumerable<Movie> FullTextSearch(string searchTerm)
        {
            return _movies.AsEnumerable().Where(m => (m.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
             || m.Genre.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
             || m.Director.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) && m.InStock > 0);
        }

        public Movie GetMovieWithCustomers(Guid id)
        {
            var movie = _movies.Include(x => x.Customers).First(movie => movie.Id == id);
            return movie;
        }
    }
}
