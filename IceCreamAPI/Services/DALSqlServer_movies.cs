using Dapper;
using Microsoft.Extensions.Configuration;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Services
{
    public class DALSqlServer_movies : IDAL_movies
    {
        private string connectionString;

        public DALSqlServer_movies(IConfiguration config)
        {
            connectionString = config.GetConnectionString("moviesDB");
        }

        public IEnumerable<Movie> GetMoviesAll()
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Movies";
            IEnumerable<Movie> Movies = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Movies = connection.Query<Movie>(queryString);
            }
            //catch (Exception e)
            //{
            //    //log the error--get details from e
            //}
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            return Movies;
        }

        public IEnumerable<Movie> GetMoviesByCategory(string category)
        {
            SqlConnection connection = null;
            string queryString = "Select * FROM Movies WHERE Category =@cat";
            IEnumerable<Movie> Movies = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Movies = connection.Query<Movie>(queryString, new { cat = category });
            }
            //catch (Exception e)
            //{
            //    //log the error--get details from e
            //}
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            return Movies;
        }
    }
}