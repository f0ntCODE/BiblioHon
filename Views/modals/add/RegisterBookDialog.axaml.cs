using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BiblioHon.ViewModels;

namespace BiblioHon.Views.modals.add;

public partial class RegisterBookDialog : Window
{
    public RegisterBookDialog(BookViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}