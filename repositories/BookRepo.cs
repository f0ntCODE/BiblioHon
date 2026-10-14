using System;
using System.Collections.Generic;
using BiblioHon.Models;

namespace BiblioHon.repositories;

public class BookRepo
{

    private Dictionary<long, Book> _bookDict = new Dictionary<long, Book>();
    private long value = 0L;

    public Book Save(Book book)
    {
        book.Id = ++value;
        _bookDict.Add(value, book);
        Console.WriteLine($"Book {book.BookName} registered succesfully");
        
        return book;
        
    }

    public bool IsBookAlreadyRegistered(Book book)
    {
        if(_bookDict.ContainsValue(book)) return true;

        return false;

    }

    public List<Book> ListAllBooks()
    {
        return new List<Book>(_bookDict.Values);
    }

}
