using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BiblioHon.Models;
using BiblioHon.Services;
using System.Collections.ObjectModel;

namespace BiblioHon.ViewModels;

public partial class BookViewModel : ObservableObject
{
    private readonly BookService _bookService;

    [ObservableProperty]
    private ObservableCollection<Book> _books = new();

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

    public BookViewModel(BookService bookService)
    {
      _bookService = bookService;
    } 

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

        var savedBook = await _bookService.RegisterNewBookAsync(book);
        Books.Add(savedBook);
    }

    [RelayCommand]
    public async Task DeleteBookAsync(Book book)
    {
        await _bookService.DeleteBookAsync(book.Id);
        await ListBooksAsync();
    }

    [RelayCommand]
    public async Task EditBookAsync(Book newBookData)
    {

                
        
    }

    public async Task ListBooksAsync()
    {
        var bookList = await _bookService.ListAllBooksAsync();
        Books.Clear();
        foreach (var book in bookList)
            Books.Add(book);
    }

}
