using System;
using System.Collections.Generic;
using CodeMVCLibrary.Models;
using CodeMVCLibrary.Controllers;

namespace CodeMVCLibrary.Services
{
    public class LibraryService
    {
        public List<Book> books { get; set; } = new List<Book>(); 
        Book recipeBook = new Book("Recipe Book", "Gordan Ramsay", "Yummy Food");
        Book lotr = new Book("The Lord of the Rings", "J.R. Tokein", "Adventure");
        Book hp = new Book("Harry Potter", "J.K. Rowling", "Fantasy"); 
        Book perksOfWallflower = new Book("The Perks of Being a Wallflower", "Stephen Chbosky", "Epistolary");
        Book ninteenEightyFour = new Book("1984", "George Orwell", "Science Fiction");


        public LibraryService()
        {
            books.Add(recipeBook);
            books.Add(lotr); 
            books.Add(hp); 
            books.Add(perksOfWallflower);
            books.Add(ninteenEightyFour);
        }
        public void AddBook(Book newBook)
        {
            books.Add(newBook);
        }

        internal string Checkout(int selection)
        {
            var Books = books.FindAll(book => book.IsAvailable == true);
            if (selection <= books.Count)
            {
                books[selection].IsAvailable = false;

                return $"Enjoy reading {books[selection].Title} by {books[selection].Author}";
            }
            else
            {
                return "Invalid input";
            }

        }

        internal string Return(int selection)
        {
            var returnedBook = books.FindAll(book => book.IsAvailable == false);
            if(selection <= books.Count)
            {
                books[selection].IsAvailable = true;
                return $"Thank you for returning {books[selection].Title} by {books[selection].Author}";
            }
            else
            {
                return "Invalid Input";
            }
        }

        internal string DeleteBook(int selection)
        {
            System.Console.WriteLine("Do you really want to delete this? Y/N");
            string userInput = Console.ReadLine().ToLower();
            if(userInput == "y")
            {
                books.RemoveAt(selection);
                return "The book was successfully deleted, come again soon.";
            } else if(userInput == "n")
            {
                return "Okay, it won't be deleted";
            }
            return "Invalid command";
        }

        internal string Read(int selection)
        {
           string bookDescription = books[selection].Description;
           return bookDescription;

        }
    }
}