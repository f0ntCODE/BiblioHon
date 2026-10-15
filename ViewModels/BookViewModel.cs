using System;
using System.Threading.Tasks;
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
    

    public BookViewModel(BookService bookService) => _bookService = bookService;

    [RelayCommand]
    public async Task RegisterBookAsync()
    {
        Book book = new Book(
            BookName,
            Author,
            Publisher,
            Isbn,
            PublicationYear,
            Genre
        );

        await _bookService.RegisterNewBookAsync(book);
        
    }

    [RelayCommand]
    public async Task ListBooksAsync()
    {
        var books = await _bookService.ListAllBooksAsync();
        foreach (var book in books)
            Console.WriteLine(book);
    }

}
