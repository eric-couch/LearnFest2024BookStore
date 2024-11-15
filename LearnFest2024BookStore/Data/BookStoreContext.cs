using LearnFest2024BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnFest2024BookStore.Data;

public class BookStoreContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LearnFest2024BookStore;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .HasMany(a => a.Books)
            .WithMany(b => b.Authors)
            .UsingEntity<Dictionary<string, object>>(
                "AuthorBook",   // name of join table
                j => j.HasOne<Book>()
                    .WithMany()
                    .HasForeignKey("BookId"),
                j => j.HasOne<Author>().WithMany().HasForeignKey("AuthorId"),
                j =>
                {
                    j.HasKey("AuthorId", "BookId");
                    j.ToTable("AuthorBook");
                }
            );
    }
}
