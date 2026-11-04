using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using BiblioHon.ViewModels;

namespace BiblioHon.Views.modals.add;

public partial class AddBookView : Window
{
    public AddBookView()
    {
        InitializeComponent();
    }

    public AddBookView(BookViewModel bookViewModel) : this()
    {
        DataContext = bookViewModel;
    
    }

    private async void Confirm_Click(object? sender, RoutedEventArgs e)
    {
        if (DataContext is not BookViewModel viewModel) return;
        if (!viewModel.RegisterBookCommand.CanExecute(null)) return;
        await viewModel.RegisterBookCommand.ExecuteAsync(null);
        Close(true);
    }

    private void Close_Click(object? sender, RoutedEventArgs e)
    {
        Close(false);
    }


}
