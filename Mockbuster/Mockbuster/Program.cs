using System;
using System.Collections.Generic;
using System.Threading;

namespace Mockbuster
{
    public class Program
    {
        public static void ListMovies(List<Movie> movieList)
        {
            for (int index = 0; index < movieList.Count; index++)
            {
                Console.WriteLine($"{index + 1}. {movieList[index]}");
                Thread.Sleep(150);
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
                Console.Write("\nWould you like to return to the Main Menu? (y/n): ");
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
        public static bool ReturnToUserMenu()
        {
            while (true)
            {
                Console.Write("\nWould you like to return to the User Menu? (y/n): ");
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
        public static bool ReturnToAdminMenu()
        {
            while (true)
            {
                Console.Write("\nWould you like to return to the Admin Menu? (y/n): ");
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
        public static bool ContinueEditing()
        {
            while (true)
            {
                Console.Write("\nWould you like to continue editing? (y/n): ");
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
            List<Movie> filteredList;
            bool validUserInput;
            bool containsMovie;
            string userOrAdmin = "";
            string userInput;
            int indexOfMovie;

            Console.WriteLine("\n========  Welcome to Mockbuster!  ========");
            Thread.Sleep(500);
            Console.WriteLine("\nHere is our current inventory:");
            Thread.Sleep(500);
            ListMovies(movieList);

            do // Return To Main Menu Do-While statement
            {
                // Login
                bool validLogin = false;
                while (!validLogin)
                {
                    validLogin = false;
                    Console.Write("\nAre you a [1] User or an [2] Admin?: ");
                    userOrAdmin = Console.ReadLine();
                    if (userOrAdmin == "1" || userOrAdmin == "2")
                    {
                        validLogin = true;
                    }
                    else
                    {
                        Console.WriteLine("That is not valid input.");
                    }
                }

                // User Path
                if (userOrAdmin == "1")
                {

                    Console.WriteLine("\n==========  Hello User!  ==========");
                    do
                    {
                        validUserInput = false;
                        Console.Write("\nWould you like to [1] View Full Inventory, Search by [2] Name, [3] Main Actor, [4] Genre, or [5] Director (Enter Q to Quit): ");
                        userInput = Console.ReadLine();
                        if (userInput == "1")
                        {
                            Console.WriteLine("\nHere is our current inventory:");
                            Thread.Sleep(500);
                            ListMovies(movieList);
                        }
                        if (userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5")
                        {
                            validUserInput = true;
                            filteredList = User.UserInterface(movieList, userInput);
                            ListMovies(filteredList);
                        }
                        else if(userInput == "Q" || userInput == "q")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That is not valid input, please try again.");
                        }
                    } while (!validUserInput || ReturnToUserMenu());
                }

                // Admin Path
                else if (userOrAdmin == "2")
                {
                    Console.WriteLine("\n=========  Hello Admin!  =========");
                    do
                    {
                        validUserInput = false;
                        Console.Write("\nWould you like to [1] View Full Inventory, Search by [2] Name, [3]  Main Actor, [4] Genre, [5] Director, or [6] Add a Movie, [7] Edit a Movie, [8] Remove a Movie (Enter 'Q' to Quit): ");
                        userInput = Console.ReadLine().ToUpper();
                        // Validating Input
                        if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5" || userInput == "6" || userInput == "7" || userInput  == "8")
                        {
                            validUserInput = true;
                        }

                        // Giving Admin Access to User Options
                        if (userInput == "1")
                        {
                            Console.WriteLine("\nHere is our current inventory:");
                            Thread.Sleep(500);
                            ListMovies(movieList);
                        }
                        else if (userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5")
                        {
                            filteredList = User.UserInterface(movieList, userInput);
                            ListMovies(filteredList);
                        }

                        // Adding Movie
                        else if (userInput == "6")
                        {
                            string newMovieName;
                            do
                            {
                                Console.Write("\nEnter the name of the movie or 'Q' to quit: ");
                                newMovieName = Console.ReadLine();
                                containsMovie = ContainsMovie(movieList, newMovieName);
                                if (newMovieName == "Q" || newMovieName == "q")
                                {
                                    break;
                                }
                                else if (containsMovie)
                                {
                                    Console.WriteLine("That movie already exists in the inventory.");
                                }
                                else
                                {
                                    Console.Write("Enter the name the main actor: ");
                                    string newMovieMainActor = Console.ReadLine();
                                    Console.Write("Enter the genre of the movie: ");
                                    string newMovieGenre = Console.ReadLine();
                                    Console.Write("Enter the director of the movie: ");
                                    string newMovieDirector = Console.ReadLine();
                                    Movie newMovie = new Movie(newMovieName, newMovieDirector, newMovieGenre, newMovieMainActor);
                                    Admin.AddMovie(movieList, newMovie);
                                    Console.WriteLine("\nYour movie has been added! Here are the details:");
                                    Thread.Sleep(300);
                                    Console.WriteLine(newMovie);
                                    break;
                                }
                            } while (containsMovie);
                        }

                        // Editing Movie
                        else if (userInput == "7")
                        {
                            do
                            {
                                Console.Write("\nEnter the name of the movie you want to edit or 'Q' to quit: ");
                                string searchName = Console.ReadLine();
                                containsMovie = ContainsMovie(movieList, searchName);
                                if (searchName == "Q" || searchName == "q")
                                {
                                    break;
                                }
                                else if (!containsMovie)
                                {
                                    Console.WriteLine("That is not valid input.");
                                }
                                else
                                {
                                    indexOfMovie = FindMovieIndex(movieList, searchName);
                                    bool validEditChoice = false;
                                    Movie movieToEdit = movieList[indexOfMovie];
                                    Console.WriteLine("\nHere is the movie you are editing.");
                                    Thread.Sleep(300);
                                    Console.WriteLine(movieToEdit);
                                    while (!validEditChoice)
                                    {
                                        Console.Write("\nWould you like to edit the [1] Name, [2] Main Actor, [3] Genre, [4] Director, or [5] All Feilds: ");
                                        string editChoice = Console.ReadLine();
                                        if (editChoice == "1" || editChoice == "2" || editChoice == "3" || editChoice == "4" || editChoice == "5")
                                        {
                                            validEditChoice = true;
                                        }
                                        switch (editChoice)
                                        {
                                            // Edit name case
                                            case "1":
                                                Console.Write("\nNew movie name: ");
                                                string newName = Console.ReadLine();
                                                Admin.EditMovieName(movieToEdit, newName);
                                                Console.WriteLine("Movie name updated! Here are the movie's details:");
                                                Thread.Sleep(300);
                                                Console.WriteLine(movieToEdit);
                                                break;
                                            // Edit actor case
                                            case "2":
                                                Console.Write("\nNew main actor: ");
                                                string newMainActor = Console.ReadLine();
                                                Admin.EditMovieMainActor(movieToEdit, newMainActor);
                                                Console.WriteLine("Main actor updated! Here are the movie's details:");
                                                Thread.Sleep(300);
                                                Console.WriteLine(movieToEdit);
                                                break;
                                            // Edit genre case
                                            case "3":
                                                Console.Write("\nNew genre: ");
                                                string newGenre = Console.ReadLine();
                                                Admin.EditMovieGenre(movieToEdit, newGenre);
                                                Console.WriteLine("Movie Genre updated! Here are the movie's details:");
                                                Thread.Sleep(300);
                                                Console.WriteLine(movieToEdit);
                                                break;
                                            // Edit director case
                                            case "4":
                                                Console.Write("\nNew director: ");
                                                string newDirector = Console.ReadLine();
                                                Admin.EditMovieDirector(movieToEdit, newDirector);
                                                Console.WriteLine("Movie Genre updated! Here are the movie's details:");
                                                Thread.Sleep(300);
                                                Console.WriteLine(movieToEdit);
                                                break;
                                            // Edit all case
                                            case "5":
                                                Console.Write("\nNew movie name: ");
                                                newName = Console.ReadLine();
                                                Console.Write("New main actor: ");
                                                newMainActor = Console.ReadLine();
                                                Console.Write("New genre: ");
                                                newGenre = Console.ReadLine();
                                                Console.Write("New director: ");
                                                newDirector = Console.ReadLine();
                                                Admin.EditMovie(movieToEdit, newName, newMainActor, newGenre, newDirector);
                                                Console.WriteLine($"\nEdit complete! Here are the updated details.");
                                                Thread.Sleep(300);
                                                Console.WriteLine(movieList[indexOfMovie]);
                                                break;
                                            default:
                                                Console.WriteLine("That is not valid input.");
                                                break;
                                        }
                                    }
                                }
                            } while (!containsMovie || ContinueEditing());
                        }

                        // Removing Movie
                        else if (userInput == "8")
                        {
                            string searchName;
                            do
                            {
                                Console.Write("\nEnter the name of the movie you want to delete or 'Q' to quit: ");
                                searchName = Console.ReadLine();
                                if (!ContainsMovie(movieList, searchName))
                                {
                                    Console.WriteLine("That movie name is not available.");
                                }
                            } while (!ContainsMovie(movieList, searchName));
                            indexOfMovie = FindMovieIndex(movieList, searchName);
                            Console.WriteLine("\nHere is the video you are going to delete:");
                            Thread.Sleep(300);
                            Console.WriteLine(movieList[indexOfMovie]);
                            while (true)
                            { 
                                Console.Write("\nAre you sure you want to delete this movie? (y/n) ");
                                string entry = Console.ReadLine().ToLower();
                                if (entry == "y")
                                {
                                    Admin.RemoveMovie(movieList, indexOfMovie);
                                    Console.WriteLine("That movie has been deleted.");
                                    break;
                                }
                                else if (entry == "n")
                                {
                                    Console.WriteLine("That movie will not be deleted.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("That is not valid input.");
                                }
                            }
                        }
                        else if (userInput == "Q")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That is not a valid input.");
                        }

                    } while (!validUserInput || ReturnToAdminMenu());
                }
            } while (ReturnToMenu());
            Console.WriteLine("\nThank you for coming to MockBuster!");
        }
    }
}
