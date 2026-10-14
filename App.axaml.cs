using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using BiblioHon.ViewModels;
using BiblioHon.Views;

namespace BiblioHon;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new BookView
            {
                DataContext = new BookViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}