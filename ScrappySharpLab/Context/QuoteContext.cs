using Microsoft.EntityFrameworkCore;
using ScrappySharpLab.Models;

namespace ScrappySharpLab.Context;

public class QuoteContext : DbContext
{
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public string DbPath { get; }

    public QuoteContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "quotes.db");
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}