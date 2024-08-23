// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text.Json;
using ConsoleLibrary;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Library Menu");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Delete a book");
            Console.WriteLine("3. Edit a book");
            Console.WriteLine("4. Loan a book");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    DelBook();
                    break;
                case "3":
                    EditBook();
                    break;
                case "4":
                    LoanBook();
                    break;
                case "5":
                    exit = true;
                    Console.WriteLine("Goodbye");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        }

        void AddBook()
        {
            Book newBook = new();
            List<Book> books = new();
            string existingJson = File.ReadAllText("json.json");
            books = JsonSerializer.Deserialize<List<Book>>(existingJson);
            
            Console.WriteLine("Enter the title of the book: ");
            newBook.Title = Console.ReadLine();
            Console.WriteLine("Enter the author of the book: ");
            newBook.Author = Console.ReadLine();
            Console.WriteLine("Enter the year of publication: ");
            newBook.PublishYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the isbn of the book: ");
            newBook.ISBN = Console.ReadLine();
            
            books.Add(newBook);
            
            string json = JsonSerializer.Serialize(books, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
            File.WriteAllText("json.json", json);
            
            Console.WriteLine("Book added");
        }

        void DelBook()
        {
            string json = File.ReadAllText("json.json");
            List<Book> books = JsonSerializer.Deserialize<List<Book>>(json);
            
            Console.WriteLine("Enter the ISBN of the book you want to delete: ");
            string isbnDelBook = Console.ReadLine();
            
            Book bookToDel = books.Find(b => b.ISBN == isbnDelBook);
            books.Remove(bookToDel);
            
            json = JsonSerializer.Serialize(books, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
            File.WriteAllText("json.json", json);
            
            Console.WriteLine("Book deleted");
        }

        void EditBook()
        {
            string json = File.ReadAllText("json.json");
            List<Book> books = JsonSerializer.Deserialize<List<Book>>(json);
            
            Console.WriteLine("Enter the ISBN of the book you want to delete: ");
            string isbnEditBook = Console.ReadLine();
            
            Book bookToEdit = books.Find(b => b.ISBN == isbnEditBook);
            
            Console.WriteLine("Edit the title of the book: ");
            bookToEdit.Title = Console.ReadLine();
            Console.WriteLine("Edit the author of the book: ");
            bookToEdit.Author = Console.ReadLine();
            Console.WriteLine("Edit the year of publication: ");
            bookToEdit.PublishYear = Convert.ToInt32(Console.ReadLine());
            
            json = JsonSerializer.Serialize(books, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
            File.WriteAllText("json.json", json);
            
            Console.WriteLine("Book edited");
        }

        void LoanBook()
        {
            string json = File.ReadAllText("json.json");
            List<Book> books = JsonSerializer.Deserialize<List<Book>>(json);
            
            Console.WriteLine("Enter the ISBN of the book you want to loan: ");
            string isbnLoanBook = Console.ReadLine();
            
            Book bookToLoan = books.Find(b => b.ISBN == isbnLoanBook);
            bookToLoan.IsLoaned = true;
            
            json = JsonSerializer.Serialize(books, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
            File.WriteAllText("json.json", json);
            
            Console.WriteLine("Book loaned");
        }
    }
}