using Avalonia.Controls;
using BiblioHon.ViewModels;

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


}
