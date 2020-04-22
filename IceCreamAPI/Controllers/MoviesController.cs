using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MoviesAPI.Models;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private DALSqlServer_movies dal;
        
        public MoviesController(IConfiguration config)
        {
            dal = new DALSqlServer_movies(config);
        }
       


        [HttpGet]
        public IEnumerable<Movie> Get(string category = null)
        {
            if (category == null)
            {
                IEnumerable<Movie> Movies = dal.GetMoviesAll();
                return Movies;
            }
            else
            {
                IEnumerable<Movie> Movies = dal.GetMoviesByCategory(category);
                return Movies;
            }
        }

        [HttpGet]
        [Route("random")]
        public IEnumerable<Movie> GetRandom(string category = null)
        {

            if (category == null)
            {
                Movie[] Movies = dal.GetMoviesAll().ToArray();
                Random rnd = new Random();
                int randomID = rnd.Next(1, Movies.Length);
                yield return Movies[randomID];
            }
            else
            {
                Movie[] Movies = dal.GetMoviesByCategory(category).ToArray();
                Random rnd = new Random();
                int randomID = rnd.Next(0, Movies.Length);
                if(Movies[randomID] != null)
                {
                    yield return Movies[randomID];
                }
                else
                {
                    //yield return Movies[randomID];
                }
            }



           
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}