using System.Text.Json;
using ConsoleLibrary;

class Program
{
    static void Main(string[] args)
    {
        BookRepository br = new BookRepository();
        
        List<Book> repBooks = br.GetBooks();
        if (repBooks != null && repBooks.Count > 0)
        {
            foreach (var book in repBooks)
            {
                Console.WriteLine(book.ToString());
            }
        }
        else
        {
            Console.WriteLine("No books in library");
        }
        
        Menu menu = new Menu();
        menu.BookMenu();
    }
}