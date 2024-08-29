namespace ConsoleLibrary;

public class BookKeeping
{
    public void ShowBooks(List<Book> books)
    {
        foreach (Book book in books)
        {
            BookDetails(book);
        }
    }

    public void ShowLoanedBooks(List<Book> books)
    {
        foreach (Book book in books)
        {
            if (book.IsLoaned)
            {
                BookDetails(book);
            }
        }
    }

    void BookDetails(Book book)
    {
        Console.WriteLine($"Title: {book.Title}");
        Console.WriteLine($"Author: {book.Author}");
        Console.WriteLine($"Year of publication: {book.YearOfPublication}");
        Console.WriteLine($"ISBN: {book.ISBN}");
        Console.WriteLine($"Is loaned: {book.IsLoaned}");
        Console.WriteLine();
    }
}