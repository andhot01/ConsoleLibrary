using System.Text.Json;

namespace ConsoleLibrary;

public class Menu
{
     static string json = File.ReadAllText("json.json");
     List<Book> books = JsonSerializer.Deserialize<List<Book>>(json);
        
     Book librarian = new();
     LibraryKeeping system = new();

        public void BookMenu()
        {
            bool exit = false;
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
                        librarian.LoanBook(books);
                        break;
                    case "5":
                        system.ShowBooks(books);
                        break;
                    case "6":
                        system.ShowLoanedBooks(books);
                        break;
                    case "7":
                        exit = true;
                        Console.WriteLine("Exiting library");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

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

        public void UserMenu()
        {
            bool exit = false;
            while (!exit)
            {
                UserMenuOptions();

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        system.ShowBooks(books);
                        break;
                    case "2":
                        system.ShowLoanedBooks(books);
                        break;
                    case "3":
                        exit = true;
                        Console.WriteLine("Exiting library");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        
        void UserMenuOptions()
        {
            Console.WriteLine("Library Menu");
            Console.WriteLine("1. Show books in library");
            Console.WriteLine("2. Show loaned books");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
        }
}