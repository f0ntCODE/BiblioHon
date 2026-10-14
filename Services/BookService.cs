using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BiblioHon.Models;
using BiblioHon.repositories;

namespace BiblioHon.Services;

public class BookService
{
    private readonly BookRepo _bookRepo;
    public BookService()
    {
        _bookRepo = new BookRepo();
        
    }

    public Book RegisterNewBook(Book book)
    {

        if (book.ISBN <= 0)
        {
            throw new ArgumentException("Book's ISBN is invalid");
        }

        bool exist = _bookRepo.IsBookAlreadyRegistered(book);

        if (exist)
        {
            throw new ArgumentException("The book almost exist");
        }

        return _bookRepo.Save(book);

    }

    public void ListAllBooksOnConsole()
    {
        List<Book> books = _bookRepo.ListAllBooks();

        foreach (Book book in books)
        {
            Console.WriteLine(book);
            
        }
    }

}