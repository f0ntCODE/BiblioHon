using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BiblioHon.Models;
using BiblioHon.repositories;

namespace BiblioHon.Services;

public class BookService
{
    private readonly BookRepo _bookRepo;
    public BookService(BookRepo bookRepo) => _bookRepo = bookRepo;

    public async Task<Book> RegisterNewBookAsync(Book book)
    {

        if (book.ISBN is null or <= 0)
        {
            throw new ArgumentException("Book's ISBN is invalid");
        }

        bool exist = await _bookRepo.IsIsbnRegisteredAsync(book.ISBN.Value);

        if (exist)
        {
            throw new ArgumentException("The book almost exist");
        }

        return await _bookRepo.SaveAsync(book);

    }

    public Task<List<Book>> ListAllBooksAsync() => _bookRepo.ListAllBooksAsync();

    public Task<bool> UpdateBookAsync(Book book) => _bookRepo.UpdateAsync(book);

    public Task<bool> DeleteBookAsync(long? id) => _bookRepo.DeleteAsync(id);

}
