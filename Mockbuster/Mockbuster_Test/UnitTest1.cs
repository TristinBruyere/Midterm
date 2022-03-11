using System;
using Xunit;
using Mockbuster;
using System.Collections.Generic;

namespace Mockbuster_Test
{
    public class MovieRepoTest
    {
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
        public void FilterMovieName_Test()
        {
            List<Movie> Movies = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            Movies.Add(m1);
            Movie m2 = new Movie("6 Underground", "Ryan Reynolds", "Thriller", "Michael Bay");
            Movies.Add(m2);
            Movie m3 = new Movie("Seven Samurai", "Toshiro Mifune", "Drama", "Akira Kurosawana");
            Movies.Add(m3);
            List<Movie> actual = User.FilterMovieName(Movies, "6 Underground");
            Assert.Contains(m2, actual); // Shows the new actual list contains indicated Movie
            Assert.DoesNotContain(m1, actual);
            Assert.DoesNotContain(m3, actual);
        }

        [Fact]
        public void FilterMainActor_Test()
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
            Assert.DoesNotContain(m2, actual);
            Assert.DoesNotContain(m3, actual);
        }

        [Fact]
        public void FilterGenre_Test()
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
            Assert.DoesNotContain(m1, actual);
            Assert.DoesNotContain(m2, actual);
        }

        [Fact]
        public void FilterDirector_Test()
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
            Assert.DoesNotContain(m1, actual);
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
            List<Movie> movieList = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            movieList.Add(m1);
            Movie m2 = new Movie("6 Underground", "Ryan Reynolds", "Thriller", "Michael Bay");
            movieList.Add(m2);
            Movie m3 = new Movie("Seven Samurai", "Toshiro Mifune", "Drama", "Akira Kurosawana");
            movieList.Add(m3);
            Admin.RemoveMovie(movieList, 1); // Removing movie at index 1
            Assert.DoesNotContain(m2, movieList);
            Assert.Contains(m1, movieList);
            Assert.Contains(m3, movieList);
        }

        [Fact]
        public void EditMovie_Test()
        {
            List<Movie> movieList = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            movieList.Add(m1);
            string newName = "Avatar";
            string newMainActor = "Sam Worthington";
            string newGenre = "Science Fiction";
            string newDirector = "James Cameron";
            Admin.EditMovie(m1, newName, newMainActor, newGenre, newDirector);
            Assert.Equal("Avatar", m1.GetMovieName());
            Assert.Equal("Sam Worthington", m1.GetMainActor());
            Assert.Equal("Science Fiction", m1.GetGenre());
            Assert.Equal("James Cameron", m1.GetDirector());
        }

        [Fact]
        public void EditName_Test()
        {
            List<Movie> movieList = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            movieList.Add(m1);
            string newName = "Avatar";
            Admin.EditMovieName(m1, newName);
            Assert.Equal("Avatar", m1.GetMovieName()); // Here is the change
            Assert.Equal("Nicolas Cage", m1.GetMainActor());
            Assert.Equal("Action", m1.GetGenre());
            Assert.Equal("John Woo", m1.GetDirector());
        }

        [Fact]
        public void EditMainActor_Test()
        {
            List<Movie> movieList = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            movieList.Add(m1);
            string newMainActor = "Sam Worthington";
            Admin.EditMovieMainActor(m1, newMainActor);
            Assert.Equal("Face/Off", m1.GetMovieName()); 
            Assert.Equal("Sam Worthington", m1.GetMainActor()); // Here is the change
            Assert.Equal("Action", m1.GetGenre());
            Assert.Equal("John Woo", m1.GetDirector());
        }

        [Fact]
        public void EditGenre_Test()
        {
            List<Movie> movieList = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            movieList.Add(m1);
            string newGenre = "Science Fiction";
            Admin.EditMovieGenre(m1, newGenre);
            Assert.Equal("Face/Off", m1.GetMovieName());
            Assert.Equal("Nicolas Cage", m1.GetMainActor());
            Assert.Equal("Science Fiction", m1.GetGenre()); // Here is the change
            Assert.Equal("John Woo", m1.GetDirector());
        }

        [Fact]
        public void EditDirector_Test()
        {
            List<Movie> movieList = new List<Movie>();
            Movie m1 = new Movie("Face/Off", "Nicolas Cage", "Action", "John Woo");
            movieList.Add(m1);
            string newDirector = "James Cameron";
            Admin.EditMovieDirector(m1, newDirector);
            Assert.Equal("Face/Off", m1.GetMovieName());
            Assert.Equal("Nicolas Cage", m1.GetMainActor());
            Assert.Equal("Action", m1.GetGenre());
            Assert.Equal("James Cameron", m1.GetDirector()); // Here is the change
        }
    }
}
