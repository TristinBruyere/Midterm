using System;
using System.Collections.Generic;
using System.Text;

namespace Mockbuster
{
    public class Admin : User
    {
        public static void AddMovie(List<Movie> movieList, Movie movieToBeAdded)
        {
            movieList.Add(movieToBeAdded);
        }
        public static void RemoveMovie(List<Movie> movieList, int movieIndex)
        {
            movieList.RemoveAt(movieIndex);
        }
        public static void EditMovie(Movie movie, string _newName, string _newActor, string _newGenre, string newDirector)
        {
            movie.Update(_newName, _newActor, _newGenre, newDirector);
        }
        public static void EditMovieName(Movie movie, string _name)
        {
            movie.SetMovieName(_name);
        }
        public static void EditMovieMainActor(Movie movie, string _name)
        {
            movie.SetMainActor(_name);
        }
        public static void EditMovieGenre(Movie movie, string _genre)
        {
            movie.SetGenre(_genre);
        }
        public static void EditMovieDirector(Movie movie, string _director)
        {
            movie.SetDirector(_director);
        }
    }
}
