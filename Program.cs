using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProjectLibraryMSStefanoTurcarelli
{
    internal class Program
    {
        /// <summary>
        /// Library Management System
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int createSampleBooks = 1;

            // Initialize currentKey outside of the method to assign Id dynamically
            int currentKey = 9;

            // Create bookOperation object to call methods from BookOperation class
            BookOperation bookOperation = new BookOperation();

            // Create Dictionary to store book entries
            Dictionary<int, List<string>> libraryDictionary = new Dictionary<int, List<string>>();

            int menuChoice = 0;
            bool exitApp = false;

            while (exitApp == false)
            {
                bookOperation.DisplayMenu();

                try
                {
                    menuChoice = int.Parse(Console.ReadLine());

                    switch (menuChoice)
                    {
                        case 0:
                            Console.WriteLine("\nClosing Application...\n");
                            Thread.Sleep(1000);
                            exitApp = true;
                            break;
                        case 1:
                            // Pass currentKey by reference to recieve the updated value 
                            bookOperation.AddBook(libraryDictionary, ref currentKey);
                            break;
                        case 2:
                            bookOperation.ViewBooks(libraryDictionary);
                            break;
                        case 3:
                            bookOperation.SearchBookById(libraryDictionary);
                            break;
                        case 4:
                            bookOperation.BorrowBook(libraryDictionary);
                            break;
                        case 5:
                            bookOperation.ReturnBook(libraryDictionary);
                            break;

                        case 6:
                            if (createSampleBooks == 1)
                            {
                                // Add sample books to the library
                                libraryDictionary.Add(1, new List<string>() { "The Hobbit", "J.R.R. Tolkien", "1937", "fantasy", "Available" });
                                libraryDictionary.Add(2, new List<string>() { "The Lord of the Rings", "J.R.R. Tolkien", "1954", "fantasy", "Available" });
                                libraryDictionary.Add(3, new List<string>() { "The Silmarillion", "J.R.R. Tolkien", "1977", "fantasy", "Available" });
                                libraryDictionary.Add(4, new List<string>() { "The Great Gatsby", "F. Scott Fitzgerald", "1925", "fiction", "Available" });
                                libraryDictionary.Add(5, new List<string>() { "The Catcher in the Rye", "J.D. Salinger", "1951", "fiction", "Available" });
                                libraryDictionary.Add(6, new List<string>() { "The Grapes of Wrath", "John Steinbeck", "1939", "fiction", "Available" });
                                libraryDictionary.Add(7, new List<string>() { "The Adventures of Tom Sawyer", "Mark Twain", "1876", "fiction", "Available" });
                                libraryDictionary.Add(8, new List<string>() { "Hamlet", "William Shakespeare", "1603", "drama", "Available" });
                                libraryDictionary.Add(9, new List<string>() { "Romeo and Juliet", "William Shakespeare", "1597", "drama", "Available" });

                                createSampleBooks = 0;
                            }
                            else
                            {
                                Console.Clear();

                                Console.WriteLine("\nSample books have already been added to the library\n");

                                Thread.Sleep(1500);

                                Console.Clear();

                                break;
                            }

                            Console.WriteLine("\nSample books have been added to the library\n");

                            break;

                        default:
                            Console.WriteLine("\nInvalid Input\n");
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
            }
        }
    }
}