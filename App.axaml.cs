using System;
using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using BiblioHon.Repositories;
using BiblioHon.repositories;
using BiblioHon.Services;
using BiblioHon.ViewModels;
using BiblioHon.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BiblioHon;

public partial class App : Application
{

    private ServiceProvider _services = null!;

    public override void OnFrameworkInitializationCompleted(){

        /*
            Start database service
        */

        var services = new ServiceCollection();
        var dataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BiblioHon");
        Directory.CreateDirectory(dataDirectory);

        var databasePath = Path.Combine(dataDirectory, "bibliohon.db");

        services.AddDbContext<BibliohonDbContext>(options =>
        {
           options.UseSqlite($"Data Source={databasePath}"); 
        });
        // Registra as camadas para que a janela e o ViewModel usem o mesmo banco.
        services.AddScoped<BookRepo>();
        services.AddScoped<BookService>();
        services.AddTransient<BookViewModel>();

        _services = services.BuildServiceProvider();

        // Aplica migrations pendentes antes de abrir a interface.
        using (var scope = _services.CreateScope())
        {
            var database = scope.ServiceProvider.GetRequiredService<BibliohonDbContext>();
            database.Database.Migrate();
        }

        /*
            Initialize BookView window
        */

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new BookView(_services.GetRequiredService<BookViewModel>());
            desktop.Exit += (_, _) => _services.Dispose();
        }

        base.OnFrameworkInitializationCompleted();
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
