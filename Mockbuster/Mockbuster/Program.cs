using System;
using System.Collections.Generic;

namespace Mockbuster
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = MoviesRepo.GetMovieList();
        }
    }
}
