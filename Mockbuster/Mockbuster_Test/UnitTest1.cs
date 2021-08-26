using System;
using Xunit;
using Mockbuster;
using System.Collections.Generic;

namespace Mockbuster_Test
{
    public class MovieRepoTest
    {
        // todo Get this list test working
        [Fact]
        public void MoviesRepo_Test()
        {
            List<Movie> actualList = MoviesRepo.GetMovieList();
            int actual = actualList.Count;
            int expected = 5;
            Assert.Equal(expected, actual);
        }
    }
    public class UserClassTests
    {
        [Fact]
        public void FilterMovieNameContains_Test()
        {
            List<Movie> Movies = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            Movies.Add(m1);
            Movie m2 = new Movie("6 Underground", "Ryan Reynolds", "Thriller", "Michael Bay");
            Movies.Add(m2);
            Movie m3 = new Movie("Seven Samurai", "Toshiro Mifune", "Drama", "Akira Kurosawana");
            Movies.Add(m3);
            List<Movie> actual = User.FilterMovieName(Movies, "6 Underground");
            Assert.Contains(m2, actual);
        }
        [Fact]
        public void FilterMovieNameDoesNotContain_Test()
        {
            List<Movie> Movies = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            Movies.Add(m1);
            Movie m2 = new Movie("6 Underground", "Ryan Reynolds", "Thriller", "Michael Bay");
            Movies.Add(m2);
            Movie m3 = new Movie("Seven Samurai", "Toshiro Mifune", "Drama", "Akira Kurosawana");
            Movies.Add(m3);
            List<Movie> actual = User.FilterMovieName(Movies, "6 Underground");
            Assert.DoesNotContain(m1, actual);
        }
        [Fact]
        public void FilterMovieNameDoesNotContain_Test2()
        {
            List<Movie> Movies = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            Movies.Add(m1);
            Movie m2 = new Movie("6 Underground", "Ryan Reynolds", "Thriller", "Michael Bay");
            Movies.Add(m2);
            Movie m3 = new Movie("Seven Samurai", "Toshiro Mifune", "Drama", "Akira Kurosawana");
            Movies.Add(m3);
            List<Movie> actual = User.FilterMovieName(Movies, "6 Underground");
            Assert.DoesNotContain(m3, actual);
        }
        [Fact]
        public void FilterMainActorContains_Test()
        {
            List<Movie> Movies = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            Movies.Add(m1);
            Movie m2 = new Movie("6 Underground", "Ryan Reynolds", "Thriller", "Michael Bay");
            Movies.Add(m2);
            Movie m3 = new Movie("Seven Samurai", "Toshiro Mifune", "Drama", "Akira Kurosawana");
            Movies.Add(m3);
            List<Movie> actual = User.FilterMainActors(Movies, "Nicolas Cage");
            Assert.Contains(m1, actual);
        }
        [Fact]
        public void FilterMainActorDoesNotContain_Test()
        {
            List<Movie> Movies = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            Movies.Add(m1);
            Movie m2 = new Movie("6 Underground", "Ryan Reynolds", "Thriller", "Michael Bay");
            Movies.Add(m2);
            Movie m3 = new Movie("Seven Samurai", "Toshiro Mifune", "Drama", "Akira Kurosawana");
            Movies.Add(m3);
            List<Movie> actual = User.FilterMainActors(Movies, "Nicolas Cage");
            Assert.DoesNotContain(m3, actual);
        }
        [Fact]
        public void FilterGenreContains_Test()
        {
            List<Movie> Movies = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            Movies.Add(m1);
            Movie m2 = new Movie("6 Underground", "Ryan Reynolds", "Thriller", "Michael Bay");
            Movies.Add(m2);
            Movie m3 = new Movie("Seven Samurai", "Toshiro Mifune", "Drama", "Akira Kurosawana");
            Movies.Add(m3);
            List<Movie> actual = User.FilterGenre(Movies, "Drama");
            Assert.Contains(m3, actual);
        }
        [Fact]
        public void FilterGenreDoesNotContain_Test()
        {
            List<Movie> Movies = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            Movies.Add(m1);
            Movie m2 = new Movie("6 Underground", "Ryan Reynolds", "Thriller", "Michael Bay");
            Movies.Add(m2);
            Movie m3 = new Movie("Seven Samurai", "Toshiro Mifune", "Drama", "Akira Kurosawana");
            Movies.Add(m3);
            List<Movie> actual = User.FilterGenre(Movies, "Drama");
            Assert.DoesNotContain(m2, actual);
        }
        [Fact]
        public void FilterDirectorContains_Test()
        {
            List<Movie> Movies = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            Movies.Add(m1);
            Movie m2 = new Movie("6 Underground", "Ryan Reynolds", "Thriller", "Michael Bay");
            Movies.Add(m2);
            Movie m3 = new Movie("Seven Samurai", "Toshiro Mifune", "Drama", "Akira Kurosawana");
            Movies.Add(m3);
            List<Movie> actual = User.FilterDirector(Movies, "Michael Bay");
            Assert.Contains(m2, actual);
        }
        [Fact]
        public void FilterDirectorDoesNotContain_Test()
        {
            List<Movie> Movies = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            Movies.Add(m1);
            Movie m2 = new Movie("6 Underground", "Ryan Reynolds", "Thriller", "Michael Bay");
            Movies.Add(m2);
            Movie m3 = new Movie("Seven Samurai", "Toshiro Mifune", "Drama", "Akira Kurosawana");
            Movies.Add(m3);
            List<Movie> actual = User.FilterDirector(Movies, "Michael Bay");
            Assert.DoesNotContain(m3, actual);
        }
    }
    public class AdminClassTests
    {
        [Fact]
        public void AddMovie_Test()
        {
            List<Movie> movieList = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            Admin.AddMovie(movieList, m1);
            Assert.Contains(m1, movieList);
        }
        [Fact]
        public void RemoveMovie_Test()
        {
            List<Movie> Movies = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            Movies.Add(m1);
            Movie m2 = new Movie("6 Underground", "Ryan Reynolds", "Thriller", "Michael Bay");
            Movies.Add(m2);
            Movie m3 = new Movie("Seven Samurai", "Toshiro Mifune", "Drama", "Akira Kurosawana");
            Movies.Add(m3);
            Admin.RemoveMovie(Movies, 1);
            Assert.DoesNotContain(m2, Movies);
        }
        // todo Figure Out Unit Testing Updating, This will break
        [Fact]
        public void EditMovie_Test()
        {
            List<Movie> movieList = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            movieList.Add(m1);
            string newName = "6 Underground";
            string newMainActor = "Ryan Reynolds";
            string newGenre = "Thriller";
            string newDirector = "Michael Bay";
            Admin.EditMovie(m1, newName, newMainActor, newGenre, newDirector);
        }
    }
}
