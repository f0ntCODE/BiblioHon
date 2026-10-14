using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BiblioHon.Models;
using BiblioHon.Services;

namespace BiblioHon.ViewModels;

public partial class BookViewModel : ObservableObject
{

    private readonly BookService _bookService;

    [ObservableProperty]
    private string _bookName = string.Empty;
    
    [ObservableProperty]
    private string _author = string.Empty;
    
    [ObservableProperty]
    private string _publisher = string.Empty;
    
    [ObservableProperty]
    private string _genre = string.Empty;
    
    [ObservableProperty]
    private int? _isbn;
    
    [ObservableProperty]
    private int? _publicationYear;
    

    public BookViewModel()
    {
        
        _bookService = new BookService();

    }

    [RelayCommand]
    public void RegisterBook()
    {
        Book book = new Book(
            BookName,
            Author,
            Publisher,
            Isbn,
            PublicationYear,
            Genre
        );

        _bookService.RegisterNewBook(book);
        
    }

    [RelayCommand]
    public void ListBooks()
    {
        _bookService.ListAllBooksOnConsole();
    }

}
