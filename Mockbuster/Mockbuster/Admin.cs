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
        public static void EditMovie(Movie movie, string _newName, string _newActor, string _newGenre, string newDirector)
        {
            movie.Update(_newName, _newActor, _newGenre, newDirector);
        }
        public static void RemoveMovie(List<Movie> movieList, int movieIndex)
        {
            movieList.RemoveAt(movieIndex);
        }
    }
}
