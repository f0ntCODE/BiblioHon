using Avalonia.Controls;
using BiblioHon.Services;
using BiblioHon.ViewModels;

namespace BiblioHon.Views;

public partial class BookView : Window
{
    public BookView()
    {
        InitializeComponent();
        DataContext = new BookViewModel();
    }
}