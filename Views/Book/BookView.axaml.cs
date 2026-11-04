using Avalonia.Controls;
using Avalonia.Interactivity;
using BiblioHon.ViewModels;
using BiblioHon.Views.modals.add;
using BiblioHon.Views.modals.edit;
using BiblioHon.Models;

namespace BiblioHon.Views;

public partial class BookView : Window
{

    public BookView()
    {
        InitializeComponent();
    }

    public BookView(BookViewModel viewModel) : this()
    {
        DataContext = viewModel;
        Opened += async (_, _) => await viewModel.ListBooksAsync();
    }

    private async void Edit_Click(object? sender, RoutedEventArgs e)
    {
        if (DataContext is not BookViewModel viewModel || sender is not Control { DataContext: Book book }) return;
        viewModel.LoadBookForEditing(book);
        var editView = new EditBookView(viewModel);
        await editView.ShowDialog<bool>(this);
        await viewModel.ListBooksAsync();
    }

    private async void AddBook_Click(object? sender, RoutedEventArgs e)
    {
    
        if (DataContext is not BookViewModel viewModel) return;
        viewModel.ClearBookFields();
        var addBook = new AddBookView(viewModel);
        await addBook.ShowDialog<bool>(this);
        
    }
}
