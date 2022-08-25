namespace ScrappySharpLab.Models;

public class Tag
{
    public int? Id;
    public string Name;

    public Tag(string name)
    {
        this.Name = name;
    }
}