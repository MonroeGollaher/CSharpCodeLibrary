using System.Collections.Generic;

namespace CodeMVCLibrary.Models
{
    public class Library
    {
        public Library(string name, string location)
        {
            Name = name; 
            Location = location; 
        }
        
        public string Name { get; set; }
        public string Location { get; }
        public List<Book> Books { get; set; } = new List<Book>();

    }
}