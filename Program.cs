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
            int currentKey = 0; // Initialize currentKey outside of the method


            BookOperation bookOperation = new BookOperation();

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
                            Console.WriteLine("\nAdding a Book\n");
                            // Call AddBook to add a book with a unique key
                            bookOperation.AddBook(libraryDictionary, ref currentKey);
                            break;
                        case 2:
                            Console.WriteLine("\nDisplaying Books\n");
                            bookOperation.ViewBooks(libraryDictionary);
                            break;
                        case 3:
                            Console.WriteLine("\nSearching Books\n");
                            bookOperation.SearchBookById(libraryDictionary);
                            break;
                        case 4:
                            Console.WriteLine("\nBorrow a Book\n");
                            bookOperation.BorrowBook(libraryDictionary);
                            break;
                        case 5:
                            Console.WriteLine("\nReturn a Book\n");
                            //bookOperation.ReturnBook(libraryDictionary);
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