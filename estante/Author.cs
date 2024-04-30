public class Author
{
    string name;

    public Author(string name)
    {
        this.name = name;
    }

    public string GetName() { return name; }

    public void SetName(string name) { this.name = name; }
}