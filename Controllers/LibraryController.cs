using System; 
using System.Collections.Generic;
using CodeMVCLibrary.Services;
using CodeMVCLibrary.Models;

namespace CodeMVCLibrary.Controllers

{
    public class LibraryController
    {
        public LibraryController()
        {
            libraryService = new LibraryService();
        }
        private bool Running { get; set; } = true;

        public LibraryService libraryService { get; set; }

        public void Run()
        {
            Console.Clear();
            while(Running)
            {
                Utils.PrintLogo();
                GetUserInput(); 
            }
        }

        public string GetBooks(bool available)
        {
            List<Book> Books = libraryService.books;
            string list = "";
            for (int i = 0; i < Books.Count; i++)
            {
                var book = Books[i];
                if (book.IsAvailable == available)
                {
                list += $@"
                {i + 1}. {book.Title} by {book.Author}";
                }
            }

            return list;
        }

        private void GetUserInput()
        {
            Console.WriteLine("Welcome to the library!");
            Console.WriteLine("Options:\nAdd, Read, Checkout, Return, Delete, Quit \nWhat would you like to do:");
            string input = Console.ReadLine().ToLower();

            switch(input)
            {
                case "add":
                Add();
                break;
                case "read":
                Read();
                break;
                case "checkout":
                Checkout();
                break;
                case "return":
                Return();
                break;
                case "delete":
                Delete();
                break;
                case "quit":
                Running = false;
                break;
                default:
                Console.WriteLine("Invalid Command");
                break;
            }
        }

        private void Add()
        {
            Console.Clear();

            Console.WriteLine("What's the title of your book?");
            string bookTitle = Console.ReadLine();

            Console.WriteLine("Who's the author of your book?");
            string bookAuthor = Console.ReadLine();

            Console.WriteLine("How would you describe your book?");
            string bookDescription = Console.ReadLine();

            Book newBook = new Book(bookTitle, bookAuthor, bookDescription);

            libraryService.AddBook(newBook);
            Console.WriteLine($"Added {bookTitle} to the library!");

        }

        private void Read()
        {
            Console.Clear();
            System.Console.WriteLine(GetBooks(true));
            System.Console.WriteLine("What book do you want to read?");
            string userInput = Console.ReadLine();
            if(int.TryParse(userInput, out int selection) && selection > 0)
            {
                Console.Clear();
                System.Console.WriteLine(libraryService.Read(selection - 1));
            }
        }
    
        private void Checkout()
        {
            Console.Clear();
            Console.WriteLine(GetBooks(true));
            Console.WriteLine("What Book would you like to check out?");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int selection) && selection > 0)
            {
                Console.Clear();
                System.Console.WriteLine("Success!");
                System.Console.WriteLine(libraryService.Checkout(selection - 1));
            }
        }
    
        private void Return()
        {
            Console.Clear();
            Console.WriteLine(GetBooks(false));
            Console.WriteLine("What book are you returning?");
            string userInput = Console.ReadLine();
            if(int.TryParse(userInput, out int selection) && selection > 0)
            {
                Console.Clear();
                System.Console.WriteLine("Success!");
                System.Console.WriteLine(libraryService.Return(selection - 1));
            }
        
        }
    
        private void Delete()
        {
            Console.Clear();
            System.Console.WriteLine(GetBooks(true));
            System.Console.WriteLine("What book would you like to delete?");
            string userInput = Console.ReadLine();
            if(int.TryParse(userInput, out int selection) && selection > 0)
            {
                Console.Clear();
                System.Console.WriteLine(libraryService.DeleteBook(selection - 1));
            }
        }
  }
}