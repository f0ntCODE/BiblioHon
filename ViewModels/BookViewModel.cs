using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BiblioHon.Models;
using BiblioHon.Services;
using System.Collections.ObjectModel;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;


namespace BiblioHon.ViewModels;

public partial class BookViewModel : ObservableObject
{
    private readonly BookService _bookService;

    [ObservableProperty]
    private ObservableCollection<Book> _books = new();

    [ObservableProperty]
    private Book? _selectedBook;

    [ObservableProperty]
[NotifyCanExecuteChangedFor(nameof(RegisterBookCommand))]
private string _bookName = string.Empty;

[ObservableProperty]
[NotifyCanExecuteChangedFor(nameof(RegisterBookCommand))]
private string _author = string.Empty;

[ObservableProperty]
[NotifyCanExecuteChangedFor(nameof(RegisterBookCommand))]
private string _publisher = string.Empty;

[ObservableProperty]
[NotifyCanExecuteChangedFor(nameof(RegisterBookCommand))]
private string _genre = string.Empty;

[ObservableProperty]
[NotifyCanExecuteChangedFor(nameof(RegisterBookCommand))]
private int? _isbn;

[ObservableProperty]
[NotifyCanExecuteChangedFor(nameof(RegisterBookCommand))]
private int? _publicationYear;

    public BookViewModel(BookService bookService)
    {
      _bookService = bookService;
    } 

    [RelayCommand(CanExecute = nameof(CanRegisterBook))]
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

        await ShowDialog("Success", "Book registered with successfull");
        
        ClearBookFields();
        
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
        if (SelectedBook is null) return;
        SelectedBook.BookName = newBookData.BookName;
        SelectedBook.Author = newBookData.Author;
        SelectedBook.Publisher = newBookData.Publisher;
        SelectedBook.ISBN = newBookData.ISBN;
        SelectedBook.PublicationYear = newBookData.PublicationYear;
        SelectedBook.Genre = newBookData.Genre;
        await _bookService.UpdateBookAsync(SelectedBook);
        SelectedBook = null;
    }

    public void LoadBookForEditing(Book book)
    {
        SelectedBook = book;
        BookName = book.BookName;
        Author = book.Author;
        Publisher = book.Publisher;
        Isbn = book.ISBN;
        PublicationYear = book.PublicationYear;
        Genre = book.Genre;
    }

    public void ClearBookFields()
    {
        BookName = Author = Publisher = Genre = string.Empty;
        Isbn = PublicationYear = null;
    }

    [RelayCommand(CanExecute = nameof(CanRegisterBook))]
    public async Task SaveBookEditsAsync()
    {
        if (SelectedBook is null) return;
        var editedBook = new Book(BookName, Author, Publisher, Isbn, PublicationYear, Genre);
        await EditBookAsync(editedBook);
        
    }

    public async Task ListBooksAsync()
    {
        var bookList = await _bookService.ListAllBooksAsync();
        Books.Clear();
        foreach (var book in bookList)
            Books.Add(book);
    }

    //dialog box message
    private async Task ShowDialog(string title, string text)
    {
        var box = MessageBoxManager.GetMessageBoxStandard(title, 
        text,
        ButtonEnum.Ok);
        
    }

    private bool CanRegisterBook()
{
    return !string.IsNullOrWhiteSpace(BookName)
        && !string.IsNullOrWhiteSpace(Author)
        && !string.IsNullOrWhiteSpace(Publisher)
        && !string.IsNullOrWhiteSpace(Genre)
        && Isbn.HasValue
        && PublicationYear.HasValue;
}

}
