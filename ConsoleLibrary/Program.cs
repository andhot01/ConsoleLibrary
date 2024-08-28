using System.Linq.Expressions;
using System.Text.Json;
using ConsoleLibrary;

class Program
{
    static void Main(string[] args)
    {
        string json = File.ReadAllText("json.json");
        List<Book> books = JsonSerializer.Deserialize<List<Book>>(json);
        bool exit = false;
        Book librarian = new Book();
        BookKeeping system = new BookKeeping();

        while (!exit)
        {
            MenuOptions();

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    librarian.AddBook(books);
                    break;
                case "2":
                    librarian.DelBook(books);
                    break;
                case "3":
                    librarian.EditBook(books);
                    break;
                case "4":
                    system.LoanBook(books);
                    break;
                case "5":
                    system.ShowBooks(books);
                    break;
                case "6":
                    system.ShowLoanedBooks(books);
                    break;
                case "7":
                    exit = true;
                    Console.WriteLine("Goodbye");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        }

        void MenuOptions()
        {
            Console.WriteLine("Library Menu");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Delete a book");
            Console.WriteLine("3. Edit a book");
            Console.WriteLine("4. Loan a book");
            Console.WriteLine("5. Show books in library");
            Console.WriteLine("6. Show loaned books");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
        }
    }
}