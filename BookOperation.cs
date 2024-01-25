using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static FinalProjectLibraryMSStefanoTurcarelli.Program;

namespace FinalProjectLibraryMSStefanoTurcarelli
{
    public class BookOperation
    {
        /// <summary>
        /// Displays the menu in the user interface
        /// </summary>
        public void DisplayMenu()
        {   
            Thread.Sleep(1000);

            Console.WriteLine("------- MENU --------");
            Console.WriteLine("[1] - Add Books");
            Console.WriteLine("[2] - View Books");
            Console.WriteLine("[3] - Search Books");
            Console.WriteLine("[4] - Borrow Book");
            Console.WriteLine("[5] - Return Book");
            Console.WriteLine("[6] - Add Sample Books (Press only once)");
            Console.WriteLine("[0] - Exit");
            Console.WriteLine("----------------------\n");
            Console.WriteLine("Enter the number of your choice and press Enter:\n");
        }

        /// <summary>
        /// Add books to the Library Management System
        /// Requests user inputs and loads the book into the dictionary
        /// </summary>
        /// <param name="libraryDictionary"></param>
        /// <param name="currentKey"></param>
        public void AddBook(Dictionary<int, List<string>> libraryDictionary, ref int currentKey)
        {
            Console.Clear();

            List<string> bookEntry = new List<string>() { null, null, null, null, null };

            // Increment the currentKey to get a unique key for the new book
            currentKey++;

            // Initialize variables
            string bookTitle;
            string bookAuthor;
            string bookYear;
            string bookGenre;
            string availableStatus = "Available";

            // Prompt the user to input Book's Title, Author, Year Published, and Genre.
            Console.WriteLine("\nType The Book Title and press Enter:\n");
            bookTitle = Console.ReadLine().Trim();
            bookEntry.Insert(0, bookTitle);

            Console.WriteLine("\nType the Book's Author and press Enter:\n");
            bookAuthor = Console.ReadLine().Trim();
            bookEntry.Insert(1, bookAuthor);

            Console.WriteLine("\nType the Publication Year and press Enter:\n");
            bookYear = Console.ReadLine().Trim();
            bookEntry.Insert(2, bookYear);

            Console.WriteLine("\nType the Book's Genre and press Enter:\n");
            bookGenre = Console.ReadLine().ToLower().Trim();
            bookEntry.Insert(3, bookGenre);

            bookEntry.Insert(4, availableStatus);

            libraryDictionary.Add(currentKey, bookEntry);

            Console.Clear();

            Console.WriteLine("\nBook Added Successfully!\n");

            Thread.Sleep(1500);

            Console.Clear();

            Console.WriteLine("\n");
        }

        public List<string> GetUniqueGenres(Dictionary<int, List<string>> libraryDictionary)
        {
            // Create a Hashtable to store unique genres
            Hashtable uniqueGenres = new Hashtable();

            // Iterate through the books in the libraryDictionary
            foreach (var bookEntry in libraryDictionary.Values)
            {
                // Add the genre to the Hashtable with a true value
                uniqueGenres[bookEntry[3]] = true;
            }

            // Convert the keys of the Hashtable to a List and return
            return uniqueGenres.Keys.Cast<string>().ToList();
        }


        /// <summary>
        /// View books
        /// Prompts the user to select to display all books or choose a genre
        /// </summary>
        /// <param name="libraryDictionary"></param>
        public void ViewBooks(Dictionary<int, List<string>> libraryDictionary)
        {
            int viewChoice;
            bool viewChoiceIsValid = false;

            if (libraryDictionary.Count == 0)
            {
                Console.WriteLine("\nNo books found in the library!\n");
                return;
            }

            while (viewChoiceIsValid == false)
            {
                try
                {
                    Console.WriteLine("\nChoose an option:");
                    Console.WriteLine("[1] - View All Books");
                    Console.WriteLine("[2] - View Books by Genre\n");

                    viewChoice = int.Parse(Console.ReadLine());

                    switch (viewChoice)
                    {
                        case 1:
                            Console.WriteLine("\n");
                            DisplayAllBooks(libraryDictionary);
                            viewChoiceIsValid = true;
                            break;

                        case 2:
                            Console.WriteLine("\n");
                            List<string> uniqueGenresList = GetUniqueGenres(libraryDictionary);
                            List<string> uniqueGenres = GetUniqueGenres(libraryDictionary);

                            if (uniqueGenresList.Count == 0)
                            {
                                Console.WriteLine("\nNo books found in the library!\n");
                                viewChoiceIsValid = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nPlease Type the Genre and press Enter:");

                                Console.WriteLine("Available Genres\n");

                                foreach (var genre in uniqueGenresList)
                                {
                                    Console.WriteLine($"Genre: [{char.ToUpper(genre[0]) + genre.Substring(1)}]");
                                }

                                Console.WriteLine("\n");

                                string selectedGenre;
                                selectedGenre = Console.ReadLine().ToLower().Trim();

                                if (uniqueGenresList.Contains(selectedGenre))
                                {
                                    Console.Clear();
                                    DisplayBooksByGenre(libraryDictionary, selectedGenre);
                                    viewChoiceIsValid = true;
                                }
                                else
                                {
                                    Console.WriteLine($"\nInvalid genre: {selectedGenre}. Returning to the main menu...\n");
                                    viewChoiceIsValid = true;
                                }
                            }

                            viewChoiceIsValid = true;
                            break;

                        default:
                            Console.WriteLine("\nInvalid choice. Returning to the main menu...\n");
                            viewChoiceIsValid = true;
                            break;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine("\nInvalid input. Returning to the main menu...\n");
                    break;
                }
            }
        }

        public void DisplayBooksByGenre(Dictionary<int, List<string>> libraryDictionary, string selectedGenre)
        {
            Console.WriteLine($"\nBooks in Genre: {selectedGenre}\n");

            // Iterate through the libraryDictionary
            foreach (var bookEntry in libraryDictionary)
            {
                // Check if the bookEntry list has a genre at index 3
                if (bookEntry.Value.Count > 3 && bookEntry.Value[3] == selectedGenre)
                {
                    // Print details of the book
                    Console.WriteLine($"Book ID: {bookEntry.Key}");
                    Console.WriteLine($"Title: {bookEntry.Value[0]}");
                    Console.WriteLine($"Author: {bookEntry.Value[1]}");
                    Console.WriteLine($"Year Published: {bookEntry.Value[2]}");
                    Console.WriteLine($"Genre: {bookEntry.Value[3]}");
                    Console.WriteLine($"Status: {bookEntry.Value[4]}\n");
                }
            }
        }


        /// <summary>
        /// Method to display all books in the library
        /// </summary>
        /// <param name="libraryDictionary"></param>
        private void DisplayAllBooks(Dictionary<int, List<string>> libraryDictionary)
        {
            if (libraryDictionary.Count == 0)
            {
                Console.WriteLine("\nNo books found in the library!\n");
                return;
            }
            else
            {
                Console.WriteLine("\nAll Books in the Library:\n");

                foreach (var pair in libraryDictionary)
                {
                    Console.WriteLine($"Book ID: {pair.Key}, Title: {pair.Value[0]}, " +
                        $"Author: {pair.Value[1]}, Genre: {pair.Value[3]}, " +
                        $"Status: {pair.Value[4]}\n");
                }

                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// Search books by ID
        /// This method prompts the user to input a book ID and searches the library dictionary
        /// </summary>
        /// <param name="libraryDictionary"></param>
        public void SearchBookById(Dictionary<int, List<string>> libraryDictionary)
        {

            int bookID;
            bool inputIsValid = false;

            if (libraryDictionary.Count == 0)
            {
                Console.WriteLine("\nNo books found in the library!\n");
                return;
            }
            else
            {
                while (inputIsValid == false)
                {
                    try
                    {
                        Console.WriteLine("\nType the Book ID you want to search:\n");
                        bookID = int.Parse(Console.ReadLine());

                        if (libraryDictionary.ContainsKey(bookID))
                        {
                            List<string> bookEntry = libraryDictionary[bookID];

                            // Display book details
                            DisplayBookDetails(bookID, bookEntry);
                            inputIsValid = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Book ID! No book found with the given ID!\n");
                            inputIsValid = true;
                            break;
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\nInvalid input. Returning to the main menu...\n");
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Display book details
        /// This method displays the details of a book
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="bookEntry"></param>
        private void DisplayBookDetails(int bookID, List<string> bookEntry)
        {
            Console.WriteLine($"\nBook ID: {bookID}");
            Console.WriteLine($"Title: {bookEntry[0]}");
            Console.WriteLine($"Author: {bookEntry[1]}");
            Console.WriteLine($"Year Published: {bookEntry[2]}");
            Console.WriteLine($"Genre: {bookEntry[3]}");
            Console.WriteLine($"Status: {bookEntry[4]}\n");
        }


        /// <summary>
        /// Borrow Books method
        /// This method prompts the user to input a book ID and borrows the book
        /// changing the status to "Borrowed"
        /// </summary>
        /// <param name="libraryDictionary"></param>
        public void BorrowBook(Dictionary<int, List<string>> libraryDictionary)
        {

            int bookID;
            bool inputIsValid = false;

            if (libraryDictionary.Count == 0)
            {
                Console.WriteLine("\nNo books found in the library!\n");
                return;
            }
            else
            {
                while (inputIsValid == false)
                {
                    try
                    {
                        Console.WriteLine("\nType the Book ID you want to Borrow:\n");
                        bookID = int.Parse(Console.ReadLine());

                        if (!libraryDictionary.ContainsKey(bookID))
                        {
                            Console.WriteLine("\nInvalid Book ID! No book found with the given ID!\n");
                            continue;
                        }

                        List<string> bookEntry = libraryDictionary[bookID];

                        if (bookEntry[4] == "Available")
                        {
                            bookEntry[4] = "Borrowed";
                            Console.WriteLine("\nBook Borrowed successfully!\n");
                            inputIsValid = true;
                            break;
                        }
                        else if (bookEntry[4] == "Borrowed")
                        {
                            Console.WriteLine("\nThis book is not available for Borrowing!\n");
                            inputIsValid = true;
                            break;
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\nInvalid input. Returning to the main menu...\n");
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Return Books method
        /// This method prompts the user to input a book ID and returns the book
        /// by changing the status to "Available"
        /// </summary>
        /// <param name="libraryDictionary"></param>
        public void ReturnBook(Dictionary<int, List<string>> libraryDictionary)
        {
            int bookID;
            bool inputIsValid = false;

            if (libraryDictionary.Count == 0)
            {
                Console.WriteLine("\nNo books found in the library!\n");
                return;
            }
            else
            {
                while (inputIsValid == false)
                {
                    try
                    {

                        // Check if there are borrowed books in the library
                        bool borrowedBooks = false;

                        foreach (var bookEntry in libraryDictionary.Values)
                        {
                            if (bookEntry[4] == "Borrowed")
                            {
                                borrowedBooks = true;
                                break;
                            }
                        }
                        if (borrowedBooks)
                        {
                            Console.WriteLine("\nBorrowed Books:\n");

                            foreach (var pair in libraryDictionary)
                            {
                                if (pair.Value[4] == "Borrowed")
                                {
                                    Console.WriteLine($"Book ID: {pair.Key}, Title: {pair.Value[0]}, " +
                                        $"Author: {pair.Value[1]}, Genre: {pair.Value[3]}, " +
                                        $"Status: {pair.Value[4]}\n");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNo books available to return!\n");
                            return;
                        }

                        Console.WriteLine("\nType the Book ID you want to Return:\n");
                        bookID = int.Parse(Console.ReadLine());

                        if (libraryDictionary.ContainsKey(bookID))
                        {
                            List<string> bookEntry = libraryDictionary[bookID];

                            if (bookEntry[4] == "Borrowed")
                            {
                                bookEntry[4] = "Available";
                                Console.WriteLine("\nBook Returned successfully!\n");
                                inputIsValid = true;
                                break;
                            }
                            else if (bookEntry[4] == "Available")
                            {
                                Console.WriteLine("\nThis book is not available for Returning!\n");
                                inputIsValid = true;
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Book ID! No book found with the given ID!\n");
                            inputIsValid = true;
                            break;
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\nInvalid input. Returning to the main menu...\n");
                        break;
                    }
                }
            }
        }
    }
}

