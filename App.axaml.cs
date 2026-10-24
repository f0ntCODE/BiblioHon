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

/**
    Provedor de serviços:
    -> Fornece instâncias para classes que precisam de DI;
**/
    private ServiceProvider _services = null!;

    public override void OnFrameworkInitializationCompleted(){

        /*
            Start database service
        */

        //Criar nova coleção de serviços
        var services = new ServiceCollection();
        /*
            Criar um caminho para o diretório que vai ficar o banco de dados local.
            Estou dizendo que o caminho para os dados ficarão em minha pasta local do software e vai terminar com "BiblioHon"
        */
        var dataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BiblioHon");
        
        //Criar diretório novo com base no caminho obtido
        Directory.CreateDirectory(dataDirectory);

        //Criar caminho para banco de dados
        var databasePath = Path.Combine(dataDirectory, "bibliohon.db");

        //Configurar contexto do SQLite
        services.AddDbContext<BibliohonDbContext>(options =>
        {
           options.UseSqlite($"Data Source={databasePath}"); 
        });
        /* Registra as camadas para que a janela e o ViewModel usem o mesmo banco.
            Adicionar BookRepo e BookService em mesmo escopo = compartilhar mesmo contexto
        */
        services.AddScoped<BookRepo>();
        services.AddScoped<BookService>();
        
        /* Se terminou um serviço/contexto, renove a instância do BookViewModel */
        services.AddTransient<BookViewModel>();

        /* Terminou a configuração do Serviço -> construir serviço */
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
