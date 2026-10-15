using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BiblioHon.Repositories;

// O dotnet ef roda fora do ciclo de vida do Avalonia; esta factory fornece
// as mesmas opções SQLite usadas pela aplicação durante migrations.
public sealed class BibliohonDbContextFactory : IDesignTimeDbContextFactory<BibliohonDbContext>
{
    public BibliohonDbContext CreateDbContext(string[] args)
    {
        var dataDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "BiblioHon");
        var databasePath = Path.Combine(dataDirectory, "bibliohon.db");
        var options = new DbContextOptionsBuilder<BibliohonDbContext>()
            .UseSqlite($"Data Source={databasePath}")
            .Options;

        return new BibliohonDbContext(options);
    }
}
