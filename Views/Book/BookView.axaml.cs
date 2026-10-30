using Avalonia.Controls;
using Avalonia.Interactivity;
using BiblioHon.ViewModels;
using BiblioHon.Views.modals;

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
        var editView = new EditBookView();
        await editView.ShowDialog<bool>(this);        
    }
}
