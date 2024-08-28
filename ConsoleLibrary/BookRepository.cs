using ConsoleLibrary.DataAccess;

namespace ConsoleLibrary;

public class BookRepository
{
    public List<Book> GetBooks()
    {
        using (LibraryContext context = new())
        {
            return context.Books.ToList();
        }
    }
}