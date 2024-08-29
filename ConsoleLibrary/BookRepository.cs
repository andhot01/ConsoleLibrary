using ConsoleLibrary.DataAccess;

namespace ConsoleLibrary;

public class BookRepository
{
    LibraryContext context = new();
    public List<Book> GetBooks()
    {
        return context.Books.ToList();
    }
    
    public void AddBook(Book book)
    {
        context.Books.Add(book);
        context.SaveChanges();
    }
    
    public void DelBook(Book book)
    {
        context.Books.Remove(book);
        context.SaveChanges();
    }
    
    public void EditBook(Book book)
    {
        context.Books.Update(book);
        context.SaveChanges();
    }
}