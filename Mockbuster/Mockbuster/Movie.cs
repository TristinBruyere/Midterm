using System;
using System.Collections.Generic;
using System.Text;

namespace Mockbuster
{
    public class Movie
    {
        private string movieName;
        private string mainActor;
        private string genre;
        private string director;

        public Movie(string _movieName, string _mainActor, string _genre, string _director)
        {
            movieName = _movieName;
            mainActor = _mainActor;
            genre = _genre;
            director = _director;
        }
        public void Update(string _movieName, string _mainActor, string _genre, string _director)
        {
            movieName = _movieName;
            mainActor = _mainActor;
            genre = _genre;
            director = _director;
        }
        public string GetGenre()
        {
            return genre;
        }
        public string GetMovieName()
        {
            return movieName;
        }
        public string GetMainActor()
        {
            return mainActor;
        }
        public string GetDirector()
        {
            return director;
        }
        public override string ToString()
        {
            return $"Movie Name: {movieName}, Main Actor: {mainActor}, Genre: {genre}, Director: {director}";
        }
    }
}
