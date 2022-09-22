using System.Globalization;
using CsvHelper;
using HtmlAgilityPack;
using ScrappySharpLab.Context;
using ScrappySharpLab.Models;
using ScrapySharp.Extensions;

HtmlWeb web = new HtmlWeb();
HtmlDocument doc = web.Load("http://quotes.toscrape.com/");

var quotes = doc.DocumentNode.CssSelect(".quote");

using var db = new QuoteContext();
Console.WriteLine($"Database path: {db.DbPath}.");

var extractedQuotes = new List<Quote>();
foreach (var quote in quotes)
{
    var quoteText = quote.SelectSingleNode(".//span[@class='text']").InnerText;
    Console.WriteLine(quoteText);
    Quote foundQuote = db.Quotes.FirstOrDefault(q => q.Text == quoteText);
    if (foundQuote == null)
    {
        var currentQuote = new Quote {Text = quoteText};
        List<Tag> tags = quote.CssSelect(".tag").Select(tag => new Tag {Name = tag.InnerText}).ToList();
        foreach (var tag in tags)
        {
            Tag foundTag = db.Tags.FirstOrDefault(t => t.Name == tag.Name);
            Console.WriteLine(foundTag.Name);
            if (foundTag == null)
            {
                foundTag = new Tag();
                foundTag.Name = tag.Name;
                db.Tags.Add(foundTag);
                db.SaveChanges();
            }

            currentQuote.Tags.Add(foundTag);
        }

        extractedQuotes.Add(currentQuote);
        db.Quotes.Add(currentQuote);
        Console.WriteLine(currentQuote.Text);
        db.SaveChanges();
    }
}