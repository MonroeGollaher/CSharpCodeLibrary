using System;
using CodeMVCLibrary.Controllers;

namespace CodeMVCLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            new LibraryController().Run();
        }
    }
}
