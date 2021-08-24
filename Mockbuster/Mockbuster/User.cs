using System;
using System.Collections.Generic;
using System.Text;

namespace Mockbuster
{
    class User
    {
        public static List<Movie> FilterGenre(string searchInput)
        {
            List<Movie> movieList = new List<Movie>();
            foreach (Movie movie in MoviesRepo.MovieList())
            {
                if (movie.GetGenre() == searchInput)
                {
                    movieList.Add(movie);
                }
            }
            return movieList;
        }
        public static List<Movie> FilterMovieName(string searchInput)
        {
            List<Movie> movieList = new List<Movie>();
            foreach (Movie movie in MoviesRepo.MovieList())
            {
                if (movie.GetMovieName() == searchInput)
                {
                    movieList.Add(movie);
                }
            }
            return movieList;
        }
        public static List<Movie> FilterMainActors(string searchInput)
        {
            List<Movie> movieList = new List<Movie>();
            foreach (Movie movie in MoviesRepo.MovieList())
            {
                if (movie.GetMainActor() == searchInput)
                {
                    movieList.Add(movie);
                }
            }
            return movieList;
        }
        public static List<Movie> FilterDirector(string searchInput)
        {
            List<Movie> movieList = new List<Movie>();
            foreach (Movie movie in MoviesRepo.MovieList())
            {
                if (movie.GetDirector() == searchInput)
                {
                    movieList.Add(movie);
                }
            }
            return movieList;
        }
    }
}
