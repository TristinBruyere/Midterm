using System;
using System.Linq;
using System.Collections.Generic;

namespace Mockbuster
{
    public class Program
    {
        public static void ListMovies(List<Movie> movieList)
        {
            for (int index = 0; index < movieList.Count; index++)
            {
                Console.WriteLine($"{index + 1}. {movieList[index]}");
            }
        }
        public static int FindMovieIndex(List<Movie> movieList, string searchName)
        {
            int indexOfMovie = -1;
            foreach (Movie movie in movieList)
            {
                string movieName = movie.GetMovieName();
                if (movieName == searchName)
                {
                    indexOfMovie = movieList.IndexOf(movie);
                }
            }
            return indexOfMovie;
        }
        public static bool ContainsMovie(List<Movie> movieList, string searchName)
        {
            foreach (Movie movie in movieList)
            {
                string movieName = movie.GetMovieName();
                if (movieName == searchName)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool ReturnToMenu()
        {
            while (true)
            {
                Console.WriteLine("\nWould you like to return to the menu? (y/n)");
                string response = Console.ReadLine().ToLower();
                if (response == "y" || response == "yes")
                {
                    return true;
                }
                else if (response == "n" || response == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter y or n.");
                }
            }
        }
        static void Main(string[] args)
        {
            List<Movie> movieList = MoviesRepo.GetMovieList();
            List<Movie> filteredList = new List<Movie>();
            bool validLogin;
            bool validUserInput;
            string userOrAdmin;
            string userInput;
            int indexOfMovie;


            Console.WriteLine("Welcome to Mockbuster!\n");
            Console.WriteLine("Here is our current stock:");
            ListMovies(movieList);


            do // Return To Main Menu Do-While statement
            {
                // todo This Shows the updated list after returning to main menu
                Console.WriteLine();
                ListMovies(movieList);
                Console.WriteLine();

                // Login
                do
                {
                    userOrAdmin = "";
                    validLogin = false;
                    Console.Write("Are you a [1] User or [2] Admin?: ");
                    userOrAdmin = Console.ReadLine();
                    if (userOrAdmin == "1" || userOrAdmin == "2")
                    {
                        validLogin = true;
                    }
                    else
                    {
                        Console.WriteLine("That is not valid input.");
                    }
                } while (!validLogin);

                // User Path
                if (userOrAdmin == "1")
                {
                    validUserInput = false;
                    Console.WriteLine("\nHello User!");
                    do
                    {
                        Console.Write("Would you like to search our videos by [1] Name, [2] Main Actor, [3] Genre, or [4] Director: ");
                        userInput = Console.ReadLine();
                        if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4")
                        {
                            validUserInput = true;
                            filteredList = User.UserInterface(movieList, userInput);
                            ListMovies(filteredList);
                        }
                        else
                        {
                            Console.WriteLine("That is not valid input, please try again.");
                        }
                    } while (!validUserInput);
                }

                // Admin Path
                else if (userOrAdmin == "2")
                {
                    validUserInput = false;
                    Console.WriteLine("\nHello Admin!\n");
                    do
                    {
                        Console.Write(" Would you like to search by [1] Name, [2]  Main Actor, [3] Genre, [4] Director, or [5] Add a Movie, [6] Edit a Movie, [7] Remove a Movie (Enter 'Q' to Quit): ");
                        userInput = Console.ReadLine().ToUpper();
                        if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5" || userInput == "6" || userInput == "7")
                        {
                            validUserInput = true;
                        }
                        else if(userInput == "Q")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That is not a valid input.");
                        }
                    } while (!validUserInput);
                    if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4")
                    {
                        filteredList = User.UserInterface(movieList, userInput);
                        ListMovies(filteredList);
                    }
                    // Adding Movie
                    else if (userInput == "5") 
                    {
                        string newMovieName;
                        do
                        {
                            Console.Write("\nEnter the name of the movie (Enter 'Q' to quit): ");
                            newMovieName = Console.ReadLine();
                            if (ContainsMovie(movieList, newMovieName))
                            {
                                Console.WriteLine("That movie already exists in the inventory.");
                            }
                        } while (ContainsMovie(movieList, newMovieName));
                        Console.Write("Enter the name the main actor: ");
                        string newMovieMainActor = Console.ReadLine();
                        Console.Write("Enter the genre of the movie: ");
                        string newMovieGenre = Console.ReadLine();
                        Console.Write("Enter the director of the movie: ");
                        string newMovieDirector = Console.ReadLine();
                        Movie newMovie = new Movie(newMovieName, newMovieDirector, newMovieGenre, newMovieMainActor);
                        Admin.AddMovie(movieList, newMovie);
                        Console.WriteLine($"\nYour movie has been added! Here are the details:\n{newMovie}");
                    }
                    // Editing Movie
                    else if (userInput == "6")
                    {
                        do
                        {
                            Console.Write("Enter the name of the movie you want to edit: ");
                            string searchName = Console.ReadLine();
                            indexOfMovie = FindMovieIndex(movieList, searchName);
                            if (indexOfMovie == -1)
                            {
                                Console.WriteLine("That movie name is not available.");
                            }
                        } while (indexOfMovie == -1);
                        Movie movieToEdit = movieList[indexOfMovie];
                        Console.WriteLine("Here is the movie you are editing.");
                        Console.WriteLine(movieToEdit);
                        Console.Write("New movie name: ");
                        string newName = Console.ReadLine();
                        Console.Write("New main actor: ");
                        string newActor = Console.ReadLine();
                        Console.Write("New genre: ");
                        string newGenre = Console.ReadLine();
                        Console.Write("New director: ");
                        string newDirector = Console.ReadLine();
                        Admin.EditMovie(movieToEdit, newName, newActor, newGenre, newGenre);
                    }
                    // Removing Movie
                    else if (userInput == "7") 
                    {
                        do
                        {
                            Console.Write("Enter the name of the movie you want to delete: ");
                            string searchName = Console.ReadLine();
                            indexOfMovie = FindMovieIndex(movieList, searchName);
                            if (indexOfMovie == -1)
                            {
                                Console.WriteLine("That movie name is not available.");
                            }
                        } while (indexOfMovie == -1);
                        Console.WriteLine("\nHere is the video you are going to delete:");
                        Console.WriteLine(movieList[indexOfMovie]);
                        Console.Write("\nAre you sure you want to delete this movie? (y/n) ");
                        string entry = Console.ReadLine();
                        if (entry == "y" || entry == "Y")
                        {
                            Admin.RemoveMovie(movieList, indexOfMovie);
                        }
                    } 
                }
            } while (ReturnToMenu());
            Console.WriteLine("Thank you for coming to MockBuster!");
        }
    }
}
