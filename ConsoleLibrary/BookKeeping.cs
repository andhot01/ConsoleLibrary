namespace ConsoleLibrary;

public class BookKeeping
{
    Book librarian = new Book();
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
    
    public void LoanBook(List<Book> books)
    {
        Console.WriteLine("Enter the ISBN of the book you want to loan: ");
        string isbnLoanBook = Console.ReadLine();
            
        Book bookToLoan = books.Find(b => b.ISBN == isbnLoanBook);
        bookToLoan.IsLoaned = true;
            
        librarian.Serialize(books);
            
        Console.WriteLine("Book loaned");
    }
}