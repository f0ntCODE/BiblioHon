using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BiblioHon.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BiblioHon.ViewModels;

public partial class BookViewModelExample : ObservableObject
{
    public ObservableCollection<Book> Books = new();

    [ObservableProperty]
    private string _bookName = "The Example Book";
    public string Author { get; } = "Sample Author";
    public string Publisher { get; } = "Sample Publisher";
    public int? Isbn { get; } = 123456789;
    public int? PublicationYear { get; } = 1999;
    public string Genre { get; } = "Fiction";

    public BookViewModelExample()
    {
        var books = new List<Book>
        {
            new Book("Example", "An example", "Author", 123, 1999, "Fiction")
        };

        this.Books = new ObservableCollection<Book>(books);
    }

}
