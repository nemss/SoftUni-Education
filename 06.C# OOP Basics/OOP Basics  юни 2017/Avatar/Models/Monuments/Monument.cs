public abstract class Monument
{
    public Monument(string name)
    {
        this.Name = name;
    }

    private string name;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public abstract int GetAffinity();

    public override string ToString()
    {
        var monumentType = this.GetType().Name;
        var typeEnd = monumentType.IndexOf("Monument");
        monumentType = monumentType.Insert(typeEnd, " ");

        return $"{monumentType}: {this.Name}";
    }
}