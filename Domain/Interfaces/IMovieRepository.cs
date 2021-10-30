using Domain.Interfaces.Base;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        IEnumerable<Movie> FullTextSearch(string searchTerm);
        Movie GetMovieWithCustomers(Guid id);

    }
}
