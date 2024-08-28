using Microsoft.EntityFrameworkCore;

namespace ConsoleLibrary.DataAccess;

public class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=EASV-DB4.easv.dk;Database=Andra_ConsoleLibrary;User Id=CSe2023t_t_3;Password=CSe2023tT3#23; TrustServerCert:True;");
    }
}