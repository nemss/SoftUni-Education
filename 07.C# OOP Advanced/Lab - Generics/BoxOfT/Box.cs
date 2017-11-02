using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    public Box()
    {
        this.elements = new List<T>();
    }

    private IList<T> elements;
    public int Count => this.elements.Count;

    public void Add(T element)
    {
        this.elements.Add(element);
    }

    public T Remove()
    {
        var last = elements.LastOrDefault();
        elements.RemoveAt(elements.Count - 1);
        return last;
    }
}