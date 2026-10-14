using System;

namespace LibraryDesktopSystem.Models;

public class Book
{
    private long? _id {get; set;}
    private string _bookName {get; set;} = String.Empty;
    private string _author {get; set;} = String.Empty;
    private string _publisher {get; set;} = String.Empty;
    private int? _ISBN {get; set;}
    private int? _publicationYear {get; set;}
    private string _genre {get; set;} = String.Empty;

    public Book(string BookName, 
    string Author,
    string Publisher,
    int? Isbn,
    int? PublicationYear,
    string Genre
    )
    {
        _bookName = BookName;
        _author = Author;
        _publisher = Publisher;
        _ISBN = Isbn;
        _publicationYear = PublicationYear;
        _genre = Genre;
        
    }
    public string BookName
    {
        get {return _bookName;}
        set {_bookName = value;}
    }

    public int? ISBN
    {
        get {return _ISBN;}
        set {_ISBN = value;}
    }

    public string Author
    {
        get{return _author;}
        set{_author = value;}
    }

    public int? PublicationYear
    {
        get {return _publicationYear;}
        set {_publicationYear = value;}
    }

    public string Genre
    {
        get{return _genre;}
        set{_genre = value;}
    }

    public long? Id
    {
        get{return _id;}
        set{_id = value;}
    }

    public override string ToString()
    {
        return $"""
        Book Id: {_id}
        Book Name: {_bookName};
        Book Author: {_author};
        Book Publisher: {_publisher};
        Book Publication Year: {_publicationYear};
        Book Genre: {_genre}; 
        """;
    }

}
