namespace ScrappySharpLab.Models;

public class Quote
{
    public int Id;
    public string Text;
    public List<Tag> tags = new List<Tag>();
}