using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using BiblioHon.ViewModels;

namespace BiblioHon.Views.modals.edit;

public partial class EditBookView : Window
{
    public EditBookView()
    {
        InitializeComponent();
    }

    public EditBookView(BookViewModel viewModel) : this()
    {
        DataContext = viewModel;
    }

    private async void Save_Click(object? sender, RoutedEventArgs e)
    {
        if (DataContext is not BookViewModel viewModel) return;
        await viewModel.SaveBookEditsCommand.ExecuteAsync(null);
        Close(true);
    }

    private void Close_Click(object? sender, RoutedEventArgs e)
    {
        Close(false);
    }
}
