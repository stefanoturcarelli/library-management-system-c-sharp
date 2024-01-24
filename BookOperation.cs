using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static FinalProjectLibraryMSStefanoTurcarelli.Program;

namespace FinalProjectLibraryMSStefanoTurcarelli
{
    public class BookOperation
    {
        // Display Menu
        public void DisplayMenu()
        {
            Console.WriteLine("------- MENU --------");
            Console.WriteLine("[1] - Add Books");
            Console.WriteLine("[2] - View Books");
            Console.WriteLine("[3] - Search Books");
            Console.WriteLine("[4] - Borrow Book");
            Console.WriteLine("[5] - Return Book");
            Console.WriteLine("[0] - Exit");
            Console.WriteLine("----------------------\n");
            Console.WriteLine("Enter your choice and press Enter:\n");
        }

        // Add Books
        public void AddBook(Dictionary<int, List<string>> libraryDictionary, ref int currentKey)
        {
            Console.Clear();

            // Increment the currentKey to get a unique key for the new book
            currentKey++;

            // Initialize variables
            string bookTitle;
            string bookAuthor;
            string bookYear;
            string bookGenre;
            string availableStatus = "Available";

            List<string> bookEntry = new List<string>() { null, null, null, null, null };

            // Prompt the user to input Book's Title, Author, Year Published, and Genre.
            Console.WriteLine("\nType The Book Title and press Enter:\n");
            bookTitle = Console.ReadLine();
            bookEntry.Insert(0, bookTitle);

            Console.WriteLine("\nType the Book's Author and press Enter:\n");
            bookAuthor = Console.ReadLine();
            bookEntry.Insert(1, bookAuthor);

            Console.WriteLine("\nType the Publication Year and press Enter:\n");
            bookYear = Console.ReadLine();
            bookEntry.Insert(2, bookYear);

            Console.WriteLine("\nType the Book's Genre and press Enter:\n");
            bookGenre = Console.ReadLine();
            bookEntry.Insert(3, bookGenre);

            bookEntry.Insert(4, availableStatus);

            libraryDictionary.Add(currentKey, bookEntry);

            Console.WriteLine("\n");
        }

        // View Books method
        public void ViewBooks(Dictionary<int, List<string>> libraryDictionary)
        {
            // Prompt the user to pick between displaying all books or choose by genre
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("[1] - View All Books");
            Console.WriteLine("[2] - View Books by Genre\n");

            // Declare variable to store the user's choice
            int viewChoice;

            if (int.TryParse(Console.ReadLine(), out viewChoice))
            {
                switch (viewChoice)
                {
                    case 1:
                        DisplayAllBooks(libraryDictionary);
                        break;

                    case 2:
                        DisplayBooksByGenre(libraryDictionary);
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice. Returning to the main menu.\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input. Returning to the main menu.\n");
            }
        }

        // Display all books
        private void DisplayAllBooks(Dictionary<int, List<string>> libraryDictionary)
        {
            Console.WriteLine("\nAll Books in the Library:\n");

            foreach (var pair in libraryDictionary)
            {
                Console.WriteLine($"Book ID: {pair.Key}, Title: {pair.Value[0]}, Author: {pair.Value[1]}, Genre: {pair.Value[3]}, Status: {pair.Value[4]}");
            }

            Console.WriteLine("\n");
        }

        // Display Books by genre
        private void DisplayBooksByGenre(Dictionary<int, List<string>> libraryDictionary)
        {
            Console.WriteLine("\nChoose a genre:\n");

            // Extract unique genres from the library
            var genres = libraryDictionary.Values.Select(book => book[3]).Distinct().ToList();

            // Display available genres
            for (int i = 0; i < genres.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] - {genres[i]}");
            }

            // Get user's genre choice
            int genreChoice;
            if (int.TryParse(Console.ReadLine(), out genreChoice) && genreChoice > 0 && genreChoice <= genres.Count)
            {
                string selectedGenre = genres[genreChoice - 1];

                // Filter books by the selected genre
                var booksByGenre = libraryDictionary
                    .Where(pair => pair.Value[3] == selectedGenre)
                    .ToDictionary(pair => pair.Key, pair => pair.Value);

                // Display books in the selected genre
                DisplayAllBooks(booksByGenre);

                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("\nInvalid input. Returning to the main menu.\n");
            }
        }

        // Search Books by ID
        public void SearchBookById(Dictionary<int, List<string>> libraryDictionary)
        {
            Console.WriteLine("\nType the Book ID you want to search:\n");

            int bookID;

            if (int.TryParse(Console.ReadLine(), out bookID))
            {
                if (libraryDictionary.ContainsKey(bookID))
                {
                    List<string> bookEntry = libraryDictionary[bookID];

                    // Display book details
                    DisplayBookDetails(bookID, bookEntry);
                }
                else
                {
                    Console.WriteLine("\nBook not found! No book with the given ID!\n");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input! Please enter a valid Book ID!\n");
            }
        }

        // Display Book Details when searching
        private void DisplayBookDetails(int bookID, List<string> bookEntry)
        {
            Console.WriteLine($"\nBook ID: {bookID}");
            Console.WriteLine($"Title: {bookEntry[0]}");
            Console.WriteLine($"Author: {bookEntry[1]}");
            Console.WriteLine($"Year Published: {bookEntry[2]}");
            Console.WriteLine($"Genre: {bookEntry[3]}");
            Console.WriteLine($"Status: {bookEntry[4]}\n");
        }


        // Borrow Books
        public void BorrowBook(Dictionary<int, List<string>> libraryDictionary)
        {

            int bookID;
            bool inputIsValid = false;

            while (inputIsValid == false)
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
                    break;
                }
                else if (bookEntry[4] == "Borrowed")
                {
                    Console.WriteLine("\nThis book is not available for Borrowing!\n");
                    break;
                }
            }

            //    if (int.TryParse(Console.ReadLine(), out bookID))
            //    {
            //        if (libraryDictionary.ContainsKey(bookID))
            //        {
            //            List<string> bookEntry = libraryDictionary[bookID];

            //            // Check if the book is currently available
            //            if (bookEntry[4] == "Available")
            //            {
            //                // Update the status to "Borrowed"
            //                bookEntry[4] = "Borrowed";
            //                Console.WriteLine("\nBook Borrowed successfully!\n");
            //            }
            //            else
            //            {
            //                Console.WriteLine("\nThis book is not available for Borrowing!\n");
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("\nInvalid Book ID! No book found with the given ID!\n");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("\nInvalid input! Please enter a valid Book ID!\n");
            //    }
            //}


            // Return Books
            //public void ReturnBook(Dictionary<int, List<string>> libraryDictionary)
            //{
            //    Console.WriteLine("\nType the Book ID you want to return:\n");

            //    int bookID;

            //    if (int.TryParse(Console.ReadLine(), out bookID))
            //    {
            //        if (libraryDictionary.ContainsKey(bookID))
            //        {
            //            List<string> bookEntry = libraryDictionary[bookID];

            //            // Check if the book is currently available
            //            if (bookEntry[4] == "Borrowed")
            //            {
            //                // Update the status to "Borrowed"
            //                bookEntry[4] = "Available";
            //                Console.WriteLine("\nBook Returned successfully!\n");
            //            }
            //            else
            //            {
            //                Console.WriteLine("\nThis book is not available for returning!\n");
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("\nInvalid Book ID! No book found with the given ID!\n");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("\nInvalid input! Please enter a valid Book ID!\n");
            //    }
            //}

        }
    }
}
