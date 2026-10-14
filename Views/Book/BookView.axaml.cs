using Avalonia.Controls;
using LibraryDesktopSystem.Services;
using LibraryDesktopSystem.ViewModels;

namespace LibraryDesktopSystem.Views;

public partial class BookView : Window
{
    public BookView()
    {
        InitializeComponent();
        DataContext = new BookViewModel();
    }
}