using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Services
{
    public interface IDAL_movies
    {
        IEnumerable<Movie> GetMoviesAll();
        IEnumerable<Movie> GetMoviesByCategory(string category);
    }
}

