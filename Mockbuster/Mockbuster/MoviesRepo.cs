using System;
using System.Collections.Generic;

namespace Mockbuster
{
    class MoviesRepo
    {
        public static List<Movie> GetMovieList()
        {
            List<Movie> Movies = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            Movies.Add(m1);
            m1 = new Movie("6 Underground", "Ryan Reynolds", "Thriller", "Michael Bay");
            Movies.Add(m1);
            m1 = new Movie("Seven Samurai", "Toshiro Mifune", "Drama", "Akira Kurosawana");
            Movies.Add(m1);
            m1 = new Movie("Talladega Nights", "Will Ferrel", "Comedy", "Adam McKay");
            Movies.Add(m1);
            m1 = new Movie("It", "Jaeden Martell", "Horror", "Andy Muschietti");
            Movies.Add(m1);
            return Movies;
        }
    }
}
