namespace ScrappySharpLab.Models;

public class Quote
{
    public int Id { get; set; }
    public string Text { get; set; }
    public List<Tag> Tags { get; set; } = new List<Tag>();
}