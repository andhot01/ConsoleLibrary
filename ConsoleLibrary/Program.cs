﻿using System.Text.Json;
using ConsoleLibrary;

class Program
{
    static void Main(string[] args)
    {
        string json = File.ReadAllText("json.json");
        List<Book> books = JsonSerializer.Deserialize<List<Book>>(json);
        bool exit = false;

        while (!exit)
        {
            MenuOptions();

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
            
            Console.WriteLine("Enter the title of the book: ");
            newBook.Title = Console.ReadLine();
            Console.WriteLine("Enter the author of the book: ");
            newBook.Author = Console.ReadLine();
            Console.WriteLine("Enter the year of publication: ");
            newBook.PublishYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the isbn of the book: ");
            newBook.ISBN = Console.ReadLine();
            
            books.Add(newBook);
            
            Serialize();
            
            Console.WriteLine("Book added");
        }

        void DelBook()
        {
            Console.WriteLine("Enter the ISBN of the book you want to delete: ");
            string isbnDelBook = Console.ReadLine();
            
            Book bookToDel = books.Find(b => b.ISBN == isbnDelBook);
            books.Remove(bookToDel);
            
            Serialize();
            
            Console.WriteLine("Book deleted");
        }

        void EditBook()
        {
            Console.WriteLine("Enter the ISBN of the book you want to edit: ");
            string isbnEditBook = Console.ReadLine();
            
            Book bookToEdit = books.Find(b => b.ISBN == isbnEditBook);
            
            Console.WriteLine("Edit the title of the book: ");
            bookToEdit.Title = Console.ReadLine();
            Console.WriteLine("Edit the author of the book: ");
            bookToEdit.Author = Console.ReadLine();
            Console.WriteLine("Edit the year of publication: ");
            bookToEdit.PublishYear = Convert.ToInt32(Console.ReadLine());
            
            Serialize();
            
            Console.WriteLine("Book edited");
        }

        void LoanBook()
        {
            Console.WriteLine("Enter the ISBN of the book you want to loan: ");
            string isbnLoanBook = Console.ReadLine();
            
            Book bookToLoan = books.Find(b => b.ISBN == isbnLoanBook);
            bookToLoan.IsLoaned = true;
            
            Serialize();
            
            Console.WriteLine("Book loaned");
        }

        void Serialize()
        {
            json = JsonSerializer.Serialize(books, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
            File.WriteAllText("json.json", json);
        }

        void MenuOptions()
        {
            Console.WriteLine("Library Menu");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Delete a book");
            Console.WriteLine("3. Edit a book");
            Console.WriteLine("4. Loan a book");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
        }
    }
}