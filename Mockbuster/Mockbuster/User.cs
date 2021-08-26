﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mockbuster
{
    public class User
    {
        public static List<Movie> FilterMovieName(List<Movie> movieList, string searchInput)
        {
            List<Movie> filteredMovieList = new List<Movie>();
            foreach (Movie movie in movieList)
            {
                if (movie.GetMovieName() == searchInput)
                {
                    filteredMovieList.Add(movie);
                }
            }
            return filteredMovieList;
        }
        public static List<Movie> FilterMainActors(List<Movie> movieList, string searchInput)
        {
            List<Movie> filteredMovieList = new List<Movie>();
            foreach (Movie movie in movieList)
            {
                if (movie.GetMainActor() == searchInput)
                {
                    filteredMovieList.Add(movie);
                }
            }
            return filteredMovieList;
        }
        public static List<Movie> FilterGenre(List<Movie> movieList, string searchInput)
        {
            List<Movie> filteredMovieList = new List<Movie>();
            foreach (Movie movie in movieList)
            {
                if (movie.GetGenre() == searchInput)
                {
                    filteredMovieList.Add(movie);
                }
            }
            return filteredMovieList;
        }
        public static List<Movie> FilterDirector(List<Movie> movieList, string searchInput)
        {
            List<Movie> filteredMovieList = new List<Movie>();
            foreach (Movie movie in movieList)
            {
                if (movie.GetDirector() == searchInput)
                {
                    filteredMovieList.Add(movie);
                }
            }
            return filteredMovieList;
        }
        public static List<Movie> UserInterface(List<Movie> movieList, string userInput)
        {
            List<Movie> filteredList = new List<Movie>();
            switch (userInput)
            {
                case "1":
                    Console.Write("Enter the name of the movie you are looking for: ");
                    string searchName = Console.ReadLine();
                    filteredList = User.FilterMovieName(movieList, searchName);
                    if (filteredList.Count == 0)
                    {
                        Console.WriteLine("No movies with that name were found.");
                        return filteredList;
                    }
                    else
                    {
                        Console.WriteLine("That movie was found!");
                        return filteredList;
                    }
                case "2":
                    Console.Write("Enter the main actor whos movies you are looking for: ");
                    string searchMainActor = Console.ReadLine();
                    filteredList = User.FilterMainActors(movieList, searchMainActor);
                    if (filteredList.Count == 0)
                    {
                        Console.WriteLine("No movies with that main actor were found.");
                        return filteredList;
                    }
                    else
                    {
                        Console.WriteLine("Movie(s) with that main actor found!");
                        return filteredList;
                    }
                case "3":
                    Console.Write("Enter the genre you are looking for: ");
                    string searchGenre = Console.ReadLine();
                    filteredList = User.FilterGenre(movieList, searchGenre);
                    if (filteredList.Count == 0)
                    {
                        Console.WriteLine("No movies with that main actor were found.");
                        return filteredList;
                    }
                    else
                    {
                        Console.WriteLine("Movie(s) of that genre found!");
                        return filteredList;
                    }
                case "4":
                    Console.Write("Enter the director whos movies you are looking for: ");
                    string searchDirector = Console.ReadLine();
                    filteredList = User.FilterDirector(movieList, searchDirector);
                    if (filteredList.Count == 0)
                    {
                        Console.WriteLine("No movies with that director were found.");
                        return filteredList;
                    }
                    else
                    {
                        Console.WriteLine("Movie(s) with that director found!");
                        return filteredList;
                    }
                default:
                    return filteredList;
            }
        }
    }
}
