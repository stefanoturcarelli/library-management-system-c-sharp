# Library Management System

## Report
A brief report explaining your design decisions, data structures used, algorithms implemented, challenges faced, and how you overcame them.

### Design Decisions

I chose to create a class called BookOperation, aiming to centralize all the methods linked to the Library Management System.

To enhance the system testing, I added an option to the menu that allows for the addition of sample books. This feature serves as a convenient way to populate the library with predefined books, facilitating the testing process and ensuring that the system performs as expected under various scenarios. The inclusion of this option demonstrates a proactive approach to testing and refining the system's functionality.

Inside the BookOperation Class you will find the following methods: 
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

I recognized handling user input can be tricky, so I implemented input validation using try-catch blocks. This is a good practice as it helps prevent unexpected errors due to invalid user input. 

User-Friendly Menu Design:

Designing a user-friendly menu system and ensuring a logical flow of user interactions was a challenge. From the structure of my code, I've modularized menu-related functionality and used a loop to handle user choices. 

Testing and Debugging:

Verifying that the code works as intended and debugging issues have been time-consuming but crucial. I've developed an approach to handling potential issues by incorporating try-catch blocks and providing informative error messages. Additionally, I took the time to thoroughly test my program, including edge cases.

## Test Cases
Documented test cases that demonstrate the functionality and robustness of your application.

Type an option from 0 to 6 and then press Enter.

![image](https://github.com/stefanoturcarelli/LibraryManagementSystem/assets/67341828/df0d1691-9d09-4a92-b466-6ba6c8138ba3)

Typing the menu option 1 and pressing enter allows you to register a new book. Enter the Book's Title, Author, Publication Year, and Genre, and Press Enter after each time to continue.

![image](https://github.com/stefanoturcarelli/LibraryManagementSystem/assets/67341828/0ccd6be3-5d7d-484d-8a00-9b471069385d)


