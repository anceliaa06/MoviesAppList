using System;
using System.Collections.Generic;

namespace MoviesAppWithList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = Serialization.DeserializeData();
            MovieStore movieStore = new MovieStore(movies);

            bool exit = false;

            Console.WriteLine("WELCOME TO THE MOVIE STORE");

            while (!exit)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. Display Movies");
                Console.WriteLine("3. Find Movie by ID");
                Console.WriteLine("4. Remove Movie by ID");
                Console.WriteLine("5. Clear Movies");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                try
                {
                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("INVALID INPUT FORMAT");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            Movie movie = new Movie();

                            Console.Write("ENTER MOVIE ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int id))
                            {
                                Console.WriteLine("Invalid ID format.");
                                break;
                            }
                            movie.Id = id;

                            Console.Write("ENTER MOVIE NAME: ");
                            movie.Name = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(movie.Name))
                            {
                                Console.WriteLine("Movie name cannot be empty.");
                                break;
                            }

                            Console.Write("ENTER YEAR OF RELEASE: ");
                            if (!int.TryParse(Console.ReadLine(), out int year))
                            {
                                Console.WriteLine("Invalid year format.");
                                break;
                            }
                            movie.YearOfRelease = year;

                            Console.Write("ENTER GENRE: ");
                            movie.Genre = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(movie.Genre))
                            {
                                Console.WriteLine("Genre cannot be empty.");
                                break;
                            }

                            movieStore.AddMovie(movie);
                            Serialization.SerializeData(movieStore.GetMovies());
                            break;

                        case 2:
                            movieStore.DisplayMovies();
                            break;

                        case 3:
                            Console.Write("ENTER MOVIE ID TO FIND: ");
                            if (!int.TryParse(Console.ReadLine(), out int findId))
                            {
                                Console.WriteLine("Invalid ID format.");
                                break;
                            }
                            Movie found = movieStore.FindMovieById(findId);
                            if (found != null)
                                Console.WriteLine($"Found Movie: {found}");
                            else
                                Console.WriteLine("Movie not found.");
                            break;

                        case 4:
                            Console.Write("ENTER MOVIE ID TO REMOVE: ");
                            if (!int.TryParse(Console.ReadLine(), out int removeId))
                            {
                                Console.WriteLine("Invalid ID format.");
                                break;
                            }
                            Movie removed = movieStore.RemoveMovieById(removeId);
                            if (removed != null)
                            {
                                Serialization.SerializeData(movieStore.GetMovies());
                                Console.WriteLine("Movie removed successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Movie not found.");
                            }
                            break;

                        case 5:
                            Console.Write("Are you sure you want to clear all movies? (y/n): ");
                            string confirm = Console.ReadLine();
                            if (confirm?.Trim().ToLower() == "y")
                            {
                                movieStore.ClearMovies();
                                Serialization.SerializeData(movieStore.GetMovies());
                                Console.WriteLine("All movies cleared.");
                            }
                            else
                            {
                                Console.WriteLine("Clear movies cancelled.");
                            }
                            break;

                       

                        case 6:
                            Console.WriteLine("Exiting the application. Goodbye!");
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input format. Please enter a valid number.");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Input cannot be null. Please provide a valid value.");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("An error occurred while processing your request: " + ex.Message);
                }
                catch (InvalidIDException ex)
                {
                    Console.WriteLine("Invalid ID: " + ex.Message);
                }
                catch (MaxMoviesException ex)
                {
                    Console.WriteLine("Maximum number of movies reached: " + ex.Message);
                }
                catch (ClearMoviesException ex)
                {
                    Console.WriteLine("Error clearing movies: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
