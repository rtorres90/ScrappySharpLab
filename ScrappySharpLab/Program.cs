using System.Globalization;
using CsvHelper;
using HtmlAgilityPack;
using ScrappySharpLab.Models;
using ScrapySharp.Extensions;

HtmlWeb web = new HtmlWeb();

HtmlDocument doc = web.Load("http://quotes.toscrape.com/");

var quotes = doc.DocumentNode.CssSelect(".quote");

var extractedQuotes = new List<Quote>();
foreach (var quote in quotes)
{
    var quoteText = quote.SelectSingleNode("//span[@class='text']").InnerText;
    var currentQuote = new Quote(quoteText);
    currentQuote.tags = quote.CssSelect(".tag").Select(tag => new Tag(tag.InnerText)).ToList();
    extractedQuotes.Add(currentQuote);
}

Console.WriteLine(extractedQuotes);