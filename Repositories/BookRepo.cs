using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiblioHon.Models;
using BiblioHon.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BiblioHon.repositories;

// O repositório concentra as consultas e gravações no SQLite.
public class BookRepo(BibliohonDbContext context)
{
    public async Task<Book> SaveAsync(Book book)
    {
        context.Books.Add(book);
        await context.SaveChangesAsync();
        return book;
    }

    public Task<bool> IsIsbnRegisteredAsync(int isbn) =>
        context.Books.AnyAsync(book => book.ISBN == isbn);

    public Task<List<Book>> ListAllBooksAsync() =>
        context.Books.AsNoTracking().OrderBy(book => book.BookName).ToListAsync();

    public async Task<bool> UpdateAsync(Book book)
    {
        if (!await context.Books.AnyAsync(existing => existing.Id == book.Id))
            return false;

        context.Books.Update(book);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var book = await context.Books.FindAsync(id);
        if (book is null)
            return false;

        context.Books.Remove(book);
        await context.SaveChangesAsync();
        return true;
    }
}
