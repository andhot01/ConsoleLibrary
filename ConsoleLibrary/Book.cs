using System.Text.Json;

namespace ConsoleLibrary;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearOfPublication { get; set; }
    public string ISBN { get; set; }
    public bool IsLoaned { get; set; }
    public Guid? UserID { get; set; }
    
    public void AddBook(List<Book> books)
    {
        Book newBook = new();
            
        Console.WriteLine("Enter the title of the book: ");
        newBook.Title = Console.ReadLine();
        Console.WriteLine("Enter the author of the book: ");
        newBook.Author = Console.ReadLine();
        Console.WriteLine("Enter the year of publication: ");
        newBook.YearOfPublication = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the isbn of the book: ");
        newBook.ISBN = Console.ReadLine();
            
        books.Add(newBook);
            
        Serialize(books);
            
        Console.WriteLine("Book added");
    }

    public void DelBook(List<Book> books)
    {
        Console.WriteLine("Enter the ISBN of the book you want to delete: ");
        string isbnDelBook = Console.ReadLine();
            
        Book bookToDel = books.Find(b => b.ISBN == isbnDelBook);
        books.Remove(bookToDel);
            
        Serialize(books);
            
        Console.WriteLine("Book deleted");
    }

    public void EditBook(List<Book> books)
    {
        Console.WriteLine("Enter the ISBN of the book you want to edit: ");
        string isbnEditBook = Console.ReadLine();
            
        Book bookToEdit = books.Find(b => b.ISBN == isbnEditBook);
            
        Console.WriteLine("Edit the title of the book: ");
        bookToEdit.Title = Console.ReadLine();
        Console.WriteLine("Edit the author of the book: ");
        bookToEdit.Author = Console.ReadLine();
        Console.WriteLine("Edit the year of publication: ");
        bookToEdit.YearOfPublication = Convert.ToInt32(Console.ReadLine());
            
        Serialize(books);
            
        Console.WriteLine("Book edited");
    }
    
    public void Serialize(List<Book> books)
    {
        string json = JsonSerializer.Serialize(books, new JsonSerializerOptions()
        {
            WriteIndented = true
        });
        File.WriteAllText("json.json", json);
    }
    
    public override string ToString()
    {
        return $"Title: {Title}, Author: {Author}, Year of publication: {YearOfPublication}, ISBN: {ISBN}, Is loaned: {IsLoaned}";
    }
}