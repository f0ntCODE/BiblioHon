using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using BiblioHon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BiblioHon.Repositories;

public class BibliohonDbContext(DbContextOptions<BibliohonDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books {get; set;}
    public DbSet<Copy> Copies {get; set;}

    //db tables config
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
           entity.ToTable("Books");
           entity.HasKey(book => book.Id);
           entity.Property(book => book.ISBN).IsRequired();
           entity.HasIndex(book => book.ISBN).IsUnique();
           entity.HasMany(book => book.Copies)
           .WithOne(copy => copy.Book)
           .HasForeignKey(copy => copy.BookId);
           
        });

        modelBuilder.Entity<Copy>(entity =>
        {
            entity.ToTable("Copies");
            entity.HasKey(copy => copy.Id);

        });

        base.OnModelCreating(modelBuilder);
    }   

}
