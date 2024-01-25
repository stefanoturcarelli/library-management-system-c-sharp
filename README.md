# Library Management System

## Report
A brief report explaining your design decisions, data structures used, algorithms implemented, challenges faced, and how you overcame them.

### Design Decisions

I chose to create a class called BookOperation, aiming to centralize all the methods linked to the Library Management System.

To enhance the system testing, I added an option to the menu to add sample books. This feature is a convenient way to populate the library with predefined books, facilitating testing and ensuring that the system performs as expected under various scenarios. Including this option demonstrates a proactive approach to testing and refining the system's functionality.

Inside the BookOperation Class, you will find the following methods: 
- DisplayMenu()
- AddBook()
- GetUniqueGenres()
- ViewBooks()
- DisplayBooksByGenre()
- DisplayAllBooks()
- SearchBookById()
- DisplayBookDetails()
- BorrowBook()
- ReturnBook()

### Data Structures Used

The Data Structures I used in this project are the following:

- Dictionary
- List
- Array

### Algorithms Implemented

- Linear Search: In the SearchBookById method, a linear search through the library dictionary is used to find a book based on its ID.

### Challenges Faced

- Handling user input can be tricky. I've implemented input validation using try-catch blocks.
- Designing a user-friendly menu system and ensuring a logical flow of user interactions was challenging.
- Verifying that the code works as intended and debugging any issues was time-consuming. 

### Overcoming Challenges

Handling User Input:

Handling user input can be tricky, so I implemented input validation using try-catch blocks. This is a good practice as it helps prevent unexpected errors due to invalid user input. 

User-Friendly Menu Design:

Designing a user-friendly menu system and ensuring a logical flow of user interactions was challenging. From the structure of my code, I've modularized menu-related functionality and used a loop to handle user choices. 

Testing and Debugging:

Verifying that the code works as intended and debugging issues have been time-consuming but crucial. I've developed an approach to handling potential problems by incorporating try-catch blocks and providing informative error messages. Additionally, I took the time to test my program thoroughly, including edge cases.

## Test Cases
It documented test cases that demonstrate the functionality and robustness of your application.

Type an option from 0 to 6 and then press Enter.

![image](https://github.com/stefanoturcarelli/LibraryManagementSystem/assets/67341828/df0d1691-9d09-4a92-b466-6ba6c8138ba3)

Typing the menu option 1 and pressing enter allows you to register a new book. Enter the Book's Title, Author, Publication Year, and Genre, and Press Enter after each time to continue.

![image](https://github.com/stefanoturcarelli/LibraryManagementSystem/assets/67341828/0ccd6be3-5d7d-484d-8a00-9b471069385d)

It is not possible to View Books if the library is empty.

![image](https://github.com/stefanoturcarelli/LibraryManagementSystem/assets/67341828/110ba0a3-637b-490a-b999-6bc1726f145c)

It is not possible to Search for Books if the library is empty.

![image](https://github.com/stefanoturcarelli/LibraryManagementSystem/assets/67341828/02411ab1-a518-4e16-93e3-3b53f462d742)

It is not possible to Return Books if the library does not contain Borrowed Books.

![image](https://github.com/stefanoturcarelli/LibraryManagementSystem/assets/67341828/9636c393-e441-49c3-b063-389b628a394d)

Typing the menu option 6 adds sample books to the library for testing purposes.

![image](https://github.com/stefanoturcarelli/LibraryManagementSystem/assets/67341828/30f26222-0799-4a2f-bab1-62afbf72cc73)

Typing the menu option 0 and pressing enter closes the application. 

![image](https://github.com/stefanoturcarelli/LibraryManagementSystem/assets/67341828/69f16ef7-5fc2-49cd-b3da-06b26d1d9bc5)

After adding the sample books to the library, select option 2 to view books. You get a prompt to choose between displaying all books or choosing among the available genres. 

![image](https://github.com/stefanoturcarelli/LibraryManagementSystem/assets/67341828/f6aeaf41-9c8a-4429-a70b-762c8317c417)

By typing option 1 the system displays all books in the library

![image](https://github.com/stefanoturcarelli/LibraryManagementSystem/assets/67341828/ec5397ca-3332-4e82-ac6b-ec44dfeb1250)

By typing option 2 the system prompts you to input the genre you want to display

![image](https://github.com/stefanoturcarelli/LibraryManagementSystem/assets/67341828/79037082-9e52-4cf4-aa39-3face9fc2668)

After typing the genre to display and pressing Enter the system displays each book entry

![image](https://github.com/stefanoturcarelli/LibraryManagementSystem/assets/67341828/ca16d92f-c836-4c64-b4bd-76b1a55af001)

Typing the menu option 4 and pressing Enter, the system requests the Book ID to borrow. After confirming the input, the system shows a confirmation message. 

![image](https://github.com/stefanoturcarelli/LibraryManagementSystem/assets/67341828/fd9e207b-9663-45a3-afbe-a40ffc6a46d3)

And changes the book Status from Available to Borrowed

![image](https://github.com/stefanoturcarelli/LibraryManagementSystem/assets/67341828/9e155725-1912-4bd1-9644-3274277d6ce3)

Typing the menu option 5 and pressing Enter, the system requests display only the Borrowed books. The user can return the book by typing the Book ID. After confirming the input, the system shows a confirmation message. 

![image](https://github.com/stefanoturcarelli/LibraryManagementSystem/assets/67341828/1468e32e-e949-40ec-a3e4-9b1a108f2471)

And changes the book Status back from Borrowed to Available

![image](https://github.com/stefanoturcarelli/LibraryManagementSystem/assets/67341828/2e03f383-8a3b-4cbe-98d4-82b3dfea536f)

If the user tries to add the sample books again, the system shows a message

![image](https://github.com/stefanoturcarelli/LibraryManagementSystem/assets/67341828/76bf444f-7d73-4ee1-843f-e2140eb28766)
