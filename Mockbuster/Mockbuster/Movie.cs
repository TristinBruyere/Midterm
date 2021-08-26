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
        public void SetGenre(string _genre)
        {
            genre = _genre;
        }
        public string GetGenre()
        {
            return genre;
        }
        public void SetMovieName(string _movieName)
        {
            movieName = _movieName;
        }
        public string GetMovieName()
        {
            return movieName;
        }
        public void SetMainActor(string _mainActor)
        {
            mainActor = _mainActor;
        }
        public string GetMainActor()
        {
            return mainActor;
        }
        public void SetDirector(string _director)
        {
            director = _director;
        }
        public string GetDirector()
        {
            return director;
        }
        public void Update(string _movieName, string _mainActor, string _genre, string _director)
        {
            movieName = _movieName;
            mainActor = _mainActor;
            genre = _genre;
            director = _director;
        }
        public override string ToString()
        {
            return $"Movie Name: {movieName}, Main Actor: {mainActor}, Genre: {genre}, Director: {director}";
        }
    }
}
