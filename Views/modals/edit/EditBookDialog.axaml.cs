using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace BiblioHon.Views.modals;

public partial class EditBookView : Window
{
    public EditBookView()
    {
        InitializeComponent();
    }

    private async void Close_Click(object? sender, RoutedEventArgs e)
    {
        Close(false);
    }
}