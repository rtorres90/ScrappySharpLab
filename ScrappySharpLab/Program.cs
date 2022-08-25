using HtmlAgilityPack;
using ScrapySharp.Extensions;

HtmlWeb web = new HtmlWeb();

HtmlDocument doc = web.Load("http://quotes.toscrape.com/");

var quotes = doc.DocumentNode.CssSelect(".quote");

foreach (var quote in quotes)
{
    Console.WriteLine(quote.InnerText);
}